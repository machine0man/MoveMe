using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace machineman.Game
{
    public class GamePanel : MonoBehaviour
    {
        static GamePanel s_Instance;

        [SerializeField] Text m_txtCurScore;

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
        public static void SetScore(int score)
        {
            s_Instance.m_txtCurScore.text = score.ToString();
        }
    }
}