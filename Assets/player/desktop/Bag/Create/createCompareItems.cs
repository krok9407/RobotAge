using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createCompareItems : MonoBehaviour
{
    
    public GameObject Button;
    
    [HideInInspector] public GameObject compareItem;
    [HideInInspector] public GameObject compareItemOnRobot;
    // Start is called before the first frame update
    void Start()
    {
            compareItem = Instantiate(Button,transform.position,Quaternion.identity);
             compareItemOnRobot = Instantiate(Button,transform.position,Quaternion.identity);
             
             compareItem.name="compareItemInBag";
             compareItemOnRobot.name="compareItemOnRobot";
           var Panel= GetComponent<spawnBag>().Panel;
           var panelRT = Panel.GetComponent<RectTransform>();
             compareItem.transform.SetParent(Panel.transform.parent,false);
             compareItemOnRobot.transform.SetParent(Panel.transform.parent,false);
             
             compareItem.transform.localScale=new Vector3(1f,1f,1f);
             compareItemOnRobot.transform.localScale=new Vector3(1f,1f,1f);
             
             var compareItemRT=compareItem.GetComponent<RectTransform>();
             var compareItemOnRobotRT=compareItemOnRobot.GetComponent<RectTransform>();
             var infoPanel = GetComponent<spawnBag>().infoPanel;
             var infoPanelRT = infoPanel.GetComponent<RectTransform>();
             float xCompareItem=panelRT.anchoredPosition.x+panelRT.sizeDelta.x+infoPanelRT.sizeDelta.x/2,
                   yCompareItem=panelRT.anchoredPosition.y+compareItemRT.sizeDelta.y/2;

                   compareItemRT.anchoredPosition=new Vector2(xCompareItem,yCompareItem);
                   xCompareItem+=infoPanelRT.sizeDelta.x;
                   compareItemOnRobotRT.anchoredPosition=new Vector2(xCompareItem,yCompareItem);
             
           
      /*
             var compareItemInfo = compareItem.GetComponent<DragDrop>().info;
             var typeCompareItem = gameObject.GetComponent<ItemComponent>().Item.type;
             var itemsOnRobot= spawnBag.ItemsOnRobot;
             
             compareItemInfo.SetActive(true);

           foreach (var item in itemsOnRobot)
           {
               var infoItem = item.GetComponent<ItemComponent>().Item;
               if(!ItemOnRobot && typeCompareItem==infoItem.type)
                {   
                    //не ставить, а заготовить и туда присвоить
                }
           }  
           */
    }
}
