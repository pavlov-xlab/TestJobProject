using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class UIScorePanel : MonoBehaviour
	{
		[SerializeField]
		private TMPro.TextMeshProUGUI m_scoreText;

		public void SetScore(int score)
		{
			m_scoreText.text = score.ToString();
		}
	}
}