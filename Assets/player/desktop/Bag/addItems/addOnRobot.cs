using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addOnRobot : MonoBehaviour
{
    public List<items> ItemsOnRobot = new List<items>(); 
    public void AddOnRbotItem(items item){
        ItemsOnRobot.Add(item);
    }
}
