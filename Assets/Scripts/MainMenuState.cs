using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{

	public class MainMenuState : MonoBehaviour
	{
		[SerializeField]
		private GameController m_gameController;
		[SerializeField]
		private GameObject m_mainMenuPanel;

		private void OnEnable()
		{
			m_gameController.RefreshScore(m_gameController.maxScore);
			m_mainMenuPanel.SetActive(true);
		}

		private void OnDisable()
		{
			m_mainMenuPanel.SetActive(false);
		}

		public void PlayGame()
		{
			m_gameController.StartGame();
		}
	}

}