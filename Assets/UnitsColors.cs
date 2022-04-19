using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace machineman.Game
{
    public class UnitsColors : MonoBehaviour
    {

        public GameObject gridPanel;
        GameObject[] gridImages;
        int[] unitValues;

        [SerializeField] ColorConfig m_colorConfig;



        //i get this n_units value from ui right now , create a core script later
        int n_units;   //mainscript's n*n

        void Start()
        {
            n_units = gridPanel.transform.childCount;
            gridImages = new GameObject[n_units];
            for (int i = 0; i < n_units; i++)
            {
                gridImages[i] = gridPanel.transform.GetChild(i).gameObject;
            }
        }

        public void ColorAllUnits()
        {
            for (int i = 0; i < n_units; i++)
            {
                gridImages[i].GetComponent<Image>().color = m_colorConfig.ColorList[MainScript.unitValues[i]];
            }
        }




    }
}