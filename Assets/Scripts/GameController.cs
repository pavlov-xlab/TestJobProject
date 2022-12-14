using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{

	public class GameController : MonoBehaviour
	{
		[SerializeField]
		private StoneSpawner m_stoneSpawner;
		private float m_timer = 0f;
		[SerializeField]
		private float m_delay = 1f;
		[SerializeField] private float m_power = 100f;

		private void Awake()
		{

		}

		private void Start()
		{
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
		}

		private void Update()
		{
			m_timer += Time.deltaTime;
			if (m_timer >= m_delay)
			{
				m_stoneSpawner.Spawn();
				m_timer -= m_delay;
			}
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
				
				Physics.IgnoreCollision(contact.thisCollider, contact.otherCollider, true);
			}
		}

		private void OnDestroy()
		{
			GameEvents.onGameOver -= OnGameOver;
		}
	}
}