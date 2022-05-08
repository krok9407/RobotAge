using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addAndDropItems : MonoBehaviour
{
    
    public List<GameObject> ItemsOnRobot = new List<GameObject>(); 
    public List<items> inventoryItems = new List<items>(); 
    public void AddItem(items item){
        inventoryItems.Add(item);
    }
    public void RemoveItem(items item){
        inventoryItems.Remove(item);
    }
    public void AddOnRobotItem(GameObject item){
        ItemsOnRobot.Add(item);
    }
    public void RemoveOnRobotItem(GameObject item){
        ItemsOnRobot.Remove(item);
    }
    public void DropItems(int id){
        for(int i=0; i<inventoryItems.Count;i++){
            if (id==inventoryItems[i].id)
            {
                inventoryItems.Remove(inventoryItems[i]);
            }
        }
    }
}
