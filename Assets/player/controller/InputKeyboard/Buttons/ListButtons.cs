using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace controller{
[CreateAssetMenuAttribute(fileName ="baseInputButton", menuName="Input/baseInputButton")]
    public class ListButtons : ScriptableObject
    {
    public List <controller.Button> Movements = new List<controller.Button>();
    public List <controller.Button> Combat = new List<controller.Button>();
    public List <controller.Button> UserInterfaces = new List<controller.Button>();
    }
}