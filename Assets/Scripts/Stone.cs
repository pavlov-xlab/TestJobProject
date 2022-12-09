using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class Stone : MonoBehaviour
	{
		[SerializeField]
		private Rigidbody m_rigidbody;

		private bool m_isAffect = true;

		public void SetAffect(bool isAffect)
		{
			m_isAffect = isAffect;
		}

		private void Awake()
		{
			if (m_rigidbody == null)
				m_rigidbody = GetComponent<Rigidbody>();
		}

		private void OnCollisionEnter(Collision other)
		{
			if (other.gameObject.TryGetComponent<Stone>(out var stone))
			{
				if (m_isAffect && stone.m_isAffect)
				{
					//LOSE
					GameEvents.onGameOver?.Invoke();
					m_isAffect = false;
				}
			}
		}
	}

}