using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{

	public class GameState : MonoBehaviour
	{
		[SerializeField] private float m_power = 100f;

		[SerializeField]
		private GameController m_gameController;
		[SerializeField]
		private GameSettings m_settings;
		[SerializeField]
		private StoneSpawner m_stoneSpawner;
		[SerializeField]
		private GameObject m_gamePanel;

		private float m_timer = 0f;
		private float m_delay = 0f;
		private float m_maxDelay = 0f;
		private List<GameObject> m_stones = new();

		private void OnEnable()
		{
			GameEvents.onCollisionStones += CheckGameOver;
			m_gamePanel.SetActive(true);

			m_maxDelay = m_settings.maxDelay;

			m_gameController.ResetScore();
			m_gameController.RefreshScore(m_gameController.score);
		}

		private void OnDisable()
		{
			m_gamePanel.SetActive(false);
			ClearStones();
			GameEvents.onCollisionStones -= CheckGameOver;
		}

		private float CalcNextDelay()
		{
			var delay = Random.Range(m_settings.minDelay, m_maxDelay);
			return delay;
		}

		private void ClearStones()
		{
			foreach (GameObject stone in m_stones)
			{
				Destroy(stone);
			}
			m_stones.Clear();
		}

		private void CheckGameOver(Stone stone1, Stone stone2)
		{
			if (stone1.isAffect && stone2.isAffect)
			{
				m_gameController.GameOver();
			}
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
				m_maxDelay = Mathf.Max(m_settings.minDelay, m_maxDelay - m_settings.stepDelay);
			}
		}

		public void OnCollisionStone(Collision collision)
		{
			if (collision.gameObject.TryGetComponent<Stone>(out var stone))
			{
				stone.isAffect = false;
				var contact = collision.contacts[0];

				var stick = contact.thisCollider.GetComponent<Stick>();

				var body = stone.GetComponent<Rigidbody>();
				body.AddForce(stick.dir * m_power, ForceMode.Impulse);

				m_gameController.IncScore();
				m_gameController.RefreshScore(m_gameController.score);

				Physics.IgnoreCollision(contact.thisCollider, contact.otherCollider, true);
			}
		}
	}
}