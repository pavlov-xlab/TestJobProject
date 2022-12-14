using System.Collections.Generic;
using UnityEngine;

namespace Game
{

	public class GameController : MonoBehaviour
	{
		[SerializeField]
		private StoneSpawner m_stoneSpawner;

		[SerializeField] private float m_power = 100f;

		[SerializeField]
		private UIScorePanel m_scorePanel;
		[SerializeField]
		private GameObject m_mainMenuPanel;
		[SerializeField]
		private GameObject m_gamePanel;
		[SerializeField]
		private GameSettings m_settings;


		private List<GameObject> m_stones = new();
		private int m_score = 0;
		private int m_maxScore = 0;
		private float m_timer = 0f;
		private float m_delay = 0f;
		private float m_maxDelay = 0f;

		private void Start()
		{
			MainMenuState();
		}

		public void MainMenuState()
		{
			ClearStones();

			enabled = false;
			m_mainMenuPanel.SetActive(true);
			m_gamePanel.SetActive(false);
			RefreshScore(m_maxScore);
		}

		private float CalcNextDelay()
		{
			var delay = Random.Range(m_settings.minDelay, m_maxDelay);
			Debug.Log($"CalcNextDelay - delay: {delay} - maxDelay: {m_maxDelay}");
			return delay;
		}

		public void GameState()
		{
			m_delay = CalcNextDelay();
			m_maxDelay = m_settings.maxDelay;

			enabled = true;
			m_mainMenuPanel.SetActive(false);
			m_gamePanel.SetActive(true);
			m_score = 0;
			RefreshScore(m_score);

			StartGame();
		}

		private void StartGame()
		{
			GameEvents.onGameOver += OnGameOver;
		}

		private void OnGameOver()
		{
			GameEvents.onGameOver -= OnGameOver;
			Debug.Log("Game Over");

			MainMenuState();
		}

		private void ClearStones()
		{
			foreach (GameObject stone in m_stones)
			{
				Destroy(stone);
			}
			m_stones.Clear();
		}

		private void Update()
		{
			m_timer += Time.deltaTime;
			if (m_timer >= m_delay)
			{
				var stone = m_stoneSpawner.Spawn();
				m_stones.Add(stone);
				m_timer -= m_delay;

				m_delay = CalcNextDelay();
				m_maxDelay -= m_settings.stepDelay;
			}
		}

		public void RefreshScore(int score)
		{
			m_scorePanel.SetScore(score);
		}

		public void OnCollisionStone(Collision collision)
		{
			if (collision.gameObject.TryGetComponent<Stone>(out var stone))
			{
				stone.SetAffect(false);
				var contact = collision.contacts[0];

				var stick = contact.thisCollider.GetComponent<Stick>();
				
				var body = stone.GetComponent<Rigidbody>();
				body.AddForce(stick.dir * m_power, ForceMode.Impulse);

				m_score++;
				m_maxScore = Mathf.Max(m_score, m_maxScore);
				RefreshScore(m_score);

				Physics.IgnoreCollision(contact.thisCollider, contact.otherCollider, true);
			}
		}

		private void OnDestroy()
		{
			GameEvents.onGameOver -= OnGameOver;
		}
	}
}