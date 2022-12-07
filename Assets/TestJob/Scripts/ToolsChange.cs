using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsChange : MonoBehaviour
{
	[SerializeField]
	private Farmer[] m_farmers;

	public void Action()
	{
		foreach (var item in m_farmers)
		{
			item.ChangeTool();
		}
	}
}
