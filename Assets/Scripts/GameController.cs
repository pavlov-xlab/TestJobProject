using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	[SerializeField]
	private StoneSpawner m_spawner;

	[SerializeField]
	private CloudController m_cloudController;

	[SerializeField]
	private ToolsChange m_toolsChange;

	public void Update()
	{
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

		if (Input.GetKeyDown(KeyCode.Z))
		{
			Debug.Log("Key Z pressed ");
			m_cloudController.Action();
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			Debug.Log("Key Space pressed ");
			m_toolsChange.Action();
		}
	}
}
