using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace machineman.Game
{
    [CreateAssetMenu(fileName = "ColorConfig", menuName = "Machineman/ColorConfig", order = 1)]
    public class ColorConfig : ScriptableObject
    {
        [SerializeField] List<Color> m_ColorList;
        public List<Color> ColorList => m_ColorList;
    }
}