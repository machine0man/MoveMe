using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace machineman.Game
{
    public class HomePanel : MonoBehaviour
    {
        static HomePanel s_Instance;

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
        public void OnBtnClicked_PlayBtn()
        { 
        
        }
    }
}