using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.EventSystems;

public class putOnItem : MonoBehaviour, IPointerClickHandler
{
      private List<RectTransform> Slots = new List<RectTransform>();
     private spawnBag spawnBag ;
     private RectTransform RT;

     void Awake() {
        spawnBag=GameObject.Find("CanvasInterface").GetComponent<spawnBag>();
        RT = GetComponent<RectTransform>();
        Slots = GetComponent<DragDrop>().listOfSlotRC;
    }
     public void OnPointerClick(PointerEventData pointerEventData)
    {
      
       if (pointerEventData.button == PointerEventData.InputButton.Right)
        {
         //Items = GameObject.Find("CanvasInterface").GetComponent<spawnBag>().inventoryItems;
                 items item=GetComponent<ItemComponent>().Item;
                 GetComponent<DragDrop>().ItemOnRobot=true;
                 spawnBag.AddOnRobotItem(gameObject);
                 switch(item.type.ToString())
                 {
                    case "Тело":
                    {
                         if(Slots[5].transform.childCount >0 )
                        {
                            var itemOnRobot = Slots[5].transform.GetChild(0).gameObject;
                            spawnBag.RemoveOnRobotItem(itemOnRobot);
                            itemOnRobot.GetComponent<DragDrop>().ItemOnRobot=false;
                            itemOnRobot.transform.SetParent(gameObject.transform.parent,true);
                            itemOnRobot.GetComponent<RectTransform>().anchoredPosition = new Vector2(RT.anchoredPosition.x,RT.anchoredPosition.y);    
                        }
                        transform.SetParent(Slots[5],true);
                        GetComponent<RectTransform>().anchoredPosition = new Vector2(Slots[5].sizeDelta.x/2,-Slots[5].sizeDelta.y/2);    
                        break;
                    }
                    case "Оружие":{
                        //убрать дублирование потом, а то багует
                        if(Slots[1].transform.childCount <1 ){
                        transform.SetParent(Slots[1],true);
                        GetComponent<RectTransform>().anchoredPosition = new Vector2(Slots[1].sizeDelta.x/2,-Slots[1].sizeDelta.y/2);    
                        
                        var secondWeapon = Instantiate(gameObject, transform.position, Quaternion.identity);    
                        secondWeapon.transform.SetParent(Slots[2],true);
                        var rcItemOnPut = secondWeapon.GetComponent<RectTransform>();
                        rcItemOnPut.localScale= new Vector3(-1f,1f,1f);
                        rcItemOnPut.anchoredPosition = new Vector2(Slots[2].sizeDelta.x/2,-Slots[2].sizeDelta.y/2);    
                        var panelItem=secondWeapon.transform.GetChild(0).gameObject;
                        var imgPanel=panelItem.GetComponent<Image>().color= new Color(1f,1f,1f,0.3960784f);
                        }
                        break;
                    }
                    case "Ботинки":{  
                        if(Slots[7].transform.childCount <1 ){                      
                        transform.SetParent(Slots[7],true);
                        GetComponent<RectTransform>().anchoredPosition = new Vector2(Slots[7].sizeDelta.x/2,-Slots[7].sizeDelta.y/2);    
                        }
                        break;
                    }
                    case "Голова":{  
                        if(Slots[0].transform.childCount <1 ){                      
                        transform.SetParent(Slots[0],true);
                        GetComponent<RectTransform>().anchoredPosition = new Vector2(Slots[0].sizeDelta.x/2,-Slots[0].sizeDelta.y/2);    
                        }
                        break;
                    }
                      case "Руки":{
                          if(Slots[3].transform.childCount <1 ){
                        transform.SetParent(Slots[3],true);
                        GetComponent<RectTransform>().anchoredPosition = new Vector2(Slots[3].sizeDelta.x/2,-Slots[3].sizeDelta.y/2);    
                        
                        var secondArm = Instantiate(gameObject, transform.position, Quaternion.identity);    
                        secondArm.transform.SetParent(Slots[4],true);
                        var rcItemOnPut = secondArm.GetComponent<RectTransform>();
                        rcItemOnPut.localScale= new Vector3(-1f,1f,1f);
                        rcItemOnPut.anchoredPosition = new Vector2(Slots[4].sizeDelta.x/2,-Slots[4].sizeDelta.y/2);    
                        var panelItem=secondArm.transform.GetChild(0).gameObject;
                        var imgPanel=panelItem.GetComponent<Image>().color= new Color(1f,1f,1f,0.3960784f);
                          }
                        break;
                    }
                      case "Ноги":{
                          if(Slots[6].transform.childCount <1 ){
                        transform.SetParent(Slots[6],true);
                        GetComponent<RectTransform>().anchoredPosition = new Vector2(Slots[6].sizeDelta.x/2,-Slots[6].sizeDelta.y/2);    
                          }
                        break;
                    }
                     case "Пояс":{
                         if(Slots[8].transform.childCount >0 )
                        {
                            var itemOnRobot = Slots[8].transform.GetChild(0);
                            itemOnRobot.transform.SetParent(gameObject.transform.parent,true);
                            itemOnRobot.GetComponent<RectTransform>().anchoredPosition = new Vector2(RT.anchoredPosition.x,RT.anchoredPosition.y);    
                        }
                        transform.SetParent(Slots[8],true);
                       RT.anchoredPosition = new Vector2(Slots[8].sizeDelta.x/2,-Slots[8].sizeDelta.y/2);    
                        break;
                    }
                    case "Плечи":{
                        if(Slots[9].transform.childCount <1 ){
                        transform.SetParent(Slots[9],true);
                        GetComponent<RectTransform>().anchoredPosition = new Vector2(Slots[9].sizeDelta.x/2,-Slots[9].sizeDelta.y/2);    
                        
                        var secondShoulder = Instantiate(gameObject, transform.position, Quaternion.identity);    
                        secondShoulder.transform.SetParent(Slots[10],true);
                        var rcItemOnPut = secondShoulder.GetComponent<RectTransform>();
                        rcItemOnPut.localScale= new Vector3(-1f,1f,1f);
                        rcItemOnPut.anchoredPosition = new Vector2(Slots[10].sizeDelta.x/2,-Slots[10].sizeDelta.y/2);    
                        var panelItem=secondShoulder.transform.GetChild(0).gameObject;
                        var imgPanel=panelItem.GetComponent<Image>().color= new Color(1f,1f,1f,0.3960784f);
                        }
                      
                        break;
                    }
                 }
               }
           }    
    }
