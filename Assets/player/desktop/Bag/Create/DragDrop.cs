using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private GameObject Canvas;
    public bool ItemOnRobot = false;
    public GameObject info;
    private RectTransform infoRC;
    private GameObject panel;
    private RectTransform rcPanel;
    private RectTransform rc;
    private CanvasGroup cg;
    public Vector2 lastPosition;
    private GameObject newSpell;
    private Transform parentItem;
    private GameObject panelItem;
    private List<GameObject> listOfSlot = new List<GameObject>();
    [HideInInspector] public List<RectTransform> listOfSlotRC = new List<RectTransform>();
    public bool SpellOrItem;
    private bool flafOnDrag = false;
    private spawnBag spawnBag;
    private void Awake()
    {

        cg = GetComponent<CanvasGroup>();
        rc = GetComponent<RectTransform>();

        infoRC = info.GetComponent<RectTransform>();
        if (!SpellOrItem)
        {
            spawnBag = GameObject.Find("CanvasInterface").GetComponent<spawnBag>();
            panel = spawnBag.Panel;
            var slotsItems = GameObject.Find("itemsSlots").GetComponent<listOfSlotItem>().Slots;
            for (int i = 0; i < slotsItems.Count; i++)
            {
                listOfSlot.Add(slotsItems[i]);
                listOfSlotRC.Add(listOfSlot[i].GetComponent<RectTransform>());
            }
            rcPanel = panel.GetComponent<RectTransform>();
        }
    }
    //начало переноса предмета
    public void OnBeginDrag(PointerEventData eventData)
    {
        parentItem = this.transform.parent;
        cg.alpha = .6f;
        cg.blocksRaycasts = false;
    }
    //нажал на кнопку
    public void OnPointerDown(PointerEventData eventData)
    {
        lastPosition = rc.anchoredPosition;
    }
    //во время переноса
    public void OnDrag(PointerEventData eventData)
    {
        if (SpellOrItem && !flafOnDrag)
        {
            newSpell = Instantiate(gameObject, gameObject.transform.position, Quaternion.identity);
            newSpell.transform.SetParent(parentItem);
            newSpell.transform.localScale = new Vector3(1f, 1f, 1f);
            flafOnDrag = true;
        }
        rc.anchoredPosition += eventData.delta;
    }
    //после переноса
    public void OnEndDrag(PointerEventData eventData)
    {

        bool flag = false;
        if (!SpellOrItem)
        {
            foreach (var x in listOfSlotRC)
            {
                if (RectTransformUtility.RectangleContainsScreenPoint(x, eventData.position, null))
                {
                   
                    flag = true;
                }
            }
            if (RectTransformUtility.RectangleContainsScreenPoint(rcPanel, eventData.position, null))
            {
                this.transform.SetParent(rcPanel, true);
                flag = true;
            }
        }
        if (!flag)
        {
            this.transform.SetParent(parentItem, true);
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = eventData.pointerDrag.GetComponent<DragDrop>().lastPosition;
        }
        cg.alpha = 1f;
        cg.blocksRaycasts = true;
        flafOnDrag = false;
        Destroy(newSpell);
    }
    //принял перенос (на предмет наложили предмет)
    public void OnDrop(PointerEventData eventData)
    {

        if (eventData.pointerDrag != null)
        {
            DragDrop checkOnRobot = eventData.pointerDrag.gameObject.GetComponent<DragDrop>();
            if (!checkOnRobot.ItemOnRobot && ItemOnRobot == true)
            {
                ItemOnRobot = false;
                checkOnRobot.ItemOnRobot = true;
            }
            else if (checkOnRobot.ItemOnRobot && ItemOnRobot == false)
            {
                ItemOnRobot = true;
                checkOnRobot.ItemOnRobot = false;
            }
            GameObject cell = eventData.pointerDrag;
            var parentCell = cell.transform.parent;

            cell.transform.SetParent(this.transform.parent, false);
            cell.GetComponent<RectTransform>().anchoredPosition = rc.anchoredPosition;
            rc.SetParent(parentCell, false);
            rc.anchoredPosition = cell.GetComponent<DragDrop>().lastPosition;
        }
    }
}



