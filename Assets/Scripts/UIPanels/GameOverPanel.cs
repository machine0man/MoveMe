using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace machineman.Game
{
    public class GameOverPanel : MonoBehaviour
    {
        static GameOverPanel s_Instance;
        [SerializeField] Text m_txtGameOverScore;

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


		public static void Show()
        {
            s_Instance.gameObject.SetActive(true);
        }
        public static void Hide()
        {
            s_Instance.gameObject.SetActive(false);
        }
        public static void SetGameOverScore(int a_Score)
        {
            s_Instance.m_txtGameOverScore.text = a_Score.ToString();
        }
    }
}