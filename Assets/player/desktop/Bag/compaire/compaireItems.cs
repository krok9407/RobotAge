using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

using System.Collections.Generic;

public class compaireItems : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    private GameObject compareItem;
    private GameObject compareItemOnRobot;
    private Image imgPanel;
    private Color panelColor;
    private GameObject canvas;
    private ItemComponent itemsInBag;
    private void Start()
    {

         canvas  = GameObject.Find("CanvasInterface");

        compareItem= canvas.GetComponent<createCompareItems>().compareItem;
        compareItemOnRobot = GameObject.Find("CanvasInterface").GetComponent<createCompareItems>().compareItemOnRobot;

        compareItem.SetActive(false);
        compareItemOnRobot.SetActive(false);

        var panelItem = gameObject.transform.GetChild(0).gameObject;
        imgPanel = panelItem.GetComponent<Image>();
        panelColor = imgPanel.color;

         itemsInBag = gameObject.GetComponent<ItemComponent>();
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        var newColor = new Color(0.22f, 0.82f, 0.96f, 0.8f);
        imgPanel.color = newColor;

        bool ItemOnRobot = GetComponent<DragDrop>().ItemOnRobot;
        showItemInfo(gameObject, ItemOnRobot);
        var slots=canvas.transform.GetChild(2).gameObject.GetComponent<listOfSlotItem>().Slots;
        foreach (var x in slots)
        {
            if(x.transform.childCount>0){
                var itemsOnRobot = x.transform.GetChild(0).gameObject.GetComponent<ItemComponent>();
                if(itemsInBag.Item.type == itemsOnRobot.Item.type && x.transform.GetChild(0).gameObject!=gameObject)
                {
                    showItemInfo(gameObject, false);
                    showItemInfo(x.transform.GetChild(0).gameObject, true);
                }

            }
        }
        
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        imgPanel.color = panelColor;
        compareItem.SetActive(false);
        compareItemOnRobot.SetActive(false);
    }
    void showItemInfo(GameObject item, bool OnRobot)
    {
        GameObject cell;
        if(OnRobot){
            cell=compareItemOnRobot;
        }
        else
        {
             cell=compareItem;
        }
        var picItem = item.transform.GetChild(1).gameObject;
        var spriteItem = picItem.GetComponent<Image>();
        var infoPanel = item.transform.GetChild(2).gameObject;

        var picCell = cell.transform.GetChild(1).gameObject.GetComponent<Image>();
        var cellInfo = cell.transform.GetChild(2).gameObject;
        cell.SetActive(true);
        cellInfo.SetActive(true);
        picCell.sprite = spriteItem.sprite;
        for (int i = 0; i < 8; i++)
        {
            var changeText = infoPanel.transform.GetChild(i).gameObject.GetComponent<Text>();
            var cellText = cellInfo.transform.GetChild(i).gameObject.GetComponent<Text>();
            cellText.text = changeText.text;
        }
    }
}

