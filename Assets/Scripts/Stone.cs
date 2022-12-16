using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class Stone : MonoBehaviour
	{
		[SerializeField]
		private Rigidbody m_rigidbody;

		public bool isAffect { set; get; } = true;

		private void Awake()
		{
			if (m_rigidbody == null)
				m_rigidbody = GetComponent<Rigidbody>();
		}

		private void OnCollisionEnter(Collision other)
		{
			if (other.gameObject.TryGetComponent<Stone>(out var stone))
			{
				GameEvents.onCollisionStones?.Invoke(this, stone);
			}
		}
	}

}