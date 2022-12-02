using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	[SerializeField]
	private StoneSpawner m_spawner;

	public void Update()
	{
		System.Object obj;



		if (Input.GetKeyDown(KeyCode.X))
		{
			Debug.Log("Key X pressed ");

			if (m_spawner)
			{
				m_spawner.Spawn();
			}
			else
			{
				Debug.LogError("m_spawner == null");
			}
		}
	}
}
