using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
	[SerializeField]
	private StoneSpawner m_stoneSpawner;
	private float m_timer = 0f;
	[SerializeField]
	private float m_delay = 1f;

	private void Update()
	{
		m_timer += Time.deltaTime;
		if (m_timer >= m_delay)
		{
			m_stoneSpawner.Spawn();
			m_timer -= m_delay;
		}
	}
}
