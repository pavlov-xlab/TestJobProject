using System.Collections.Generic;
using UnityEngine;

namespace Game
{

	public class GameController : MonoBehaviour
	{
		[SerializeField]
		private UIScorePanel m_scorePanel;

		private int m_score = 0;
		private int m_maxScore = 0;

		public int maxScore => m_maxScore;
		public int score => m_score;

		[SerializeField] private MainMenuState m_mainMenuState;
		[SerializeField] private GameState m_gameState;

		private void Start()
		{
			MainMenuState();
		}

		private void MainMenuState()
		{
			m_mainMenuState.enabled = true;
			m_gameState.enabled = false;
		}

		private void GameState()
		{
			m_mainMenuState.enabled = false;
			m_gameState.enabled = true;
		}

		public void StartGame()
		{
			GameState();
		}

		public void GameOver()
		{
			MainMenuState();
		}

		public void IncScore()
		{
			m_score++;
			m_maxScore = Mathf.Max(m_score, m_maxScore);
		}

		public void ResetScore()
		{
			m_score = 0;
		}

		public void RefreshScore(int score)
		{
			m_scorePanel.SetScore(score);
		}
	}
}