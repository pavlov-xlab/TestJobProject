using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField]
	private Transform m_tool;


	public float range = 30f;
	public float speed = 1f;
	private float m_timer = 0f;

	private void Update()
	{
		var angels = m_tool.localEulerAngles;
		m_timer += Time.deltaTime;
		var x = Mathf.Cos(Mathf.PI * m_timer * speed) * range;
		angels.x = x;
		m_tool.localEulerAngles = angels;
	}
}
