using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{

	public class Stick : MonoBehaviour
	{
		[SerializeField]
		private UnityEvent<Collision> onCollisionStone;

		private void OnCollisionEnter(Collision other)
		{
			onCollisionStone.Invoke(other);
		}
	}
}