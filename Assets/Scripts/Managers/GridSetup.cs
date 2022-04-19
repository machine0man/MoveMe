using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSetup : MonoBehaviour
{
    [SerializeField] GameObject  m_GridPanel;
    GridLayoutGroup m_gridLayoutGroup; 
     
    [SerializeField] float m_Spacing = 10.0f;
    [SerializeField] float m_Padding = 10.0f;
    [SerializeField] int m_gridSize = 4;

    void Start()
    {
        Setup();
    }
    void Setup()
    {
        m_gridLayoutGroup = m_GridPanel.GetComponent<GridLayoutGroup>();
        float l_gridWidth = m_GridPanel.GetComponent<RectTransform>().rect.width;
        float l_cellWidth = (l_gridWidth - (m_Padding * 2) - (m_Spacing * 3)) / (float)m_gridSize;
        //Debug.Log(cellWidth);
        m_gridLayoutGroup.cellSize = new Vector2(l_cellWidth, l_cellWidth);
    }
  
}
