using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class UnitsFitter : MonoBehaviour
{
    public GridLayoutGroup gridLayoutGroup; 
    float gridWidth;
    public float spacing = 10.0f;
    public float padding = 50.0f;
    void Awake()
    {
        gridLayoutGroup = this.gameObject.GetComponent<GridLayoutGroup>();
    }

    
    void Update()
    {
        gridWidth = this.gameObject.GetComponent<RectTransform>().rect.width;
        float cellsize  =(gridWidth -(padding *2 ) - (spacing *3 ) ) /4;
        gridLayoutGroup.cellSize =  new Vector2(cellsize , cellsize );

        
    }
}
