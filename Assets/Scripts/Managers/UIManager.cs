using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace machineman.Game
{
    public class UIManager : MonoBehaviour
    {
        static UIManager s_Instance;


		#region Unity Methods
		void Awake()
		{
			s_Instance = this;
		}
		void OnDestroy()
		{
			s_Instance = null;
		}
		#endregion
		
        public static void UpdateScore(int a_score)
        {
            GamePanel.SetScore(a_score);
        }
        public static void OpenGamePanel()
        {
            s_Instance.HideAllPanels();
            GamePanel.Show();
        }
        public static void OpenHomePanel()
        {
            s_Instance.HideAllPanels();
            HomePanel.Show();
        }
        public static void OpenSettingsPanel()
        {

        }
        public static void OpenBackPanel()
        {

        }
        public static void OnGameOver(int Score)
        {
            s_Instance.Internal_OnGameOver(Score);
        }

		#region Private Methods
		void Internal_OnGameOver(int a_Score)
		{
            GameOverPanel.SetGameOverScore(a_Score);
            GameOverPanel.Show();
		}
		void HideAllPanels()
		{
            HomePanel.Hide();
            GamePanel.Hide();
            GameOverPanel.Hide();
		}
		#endregion


	}
}