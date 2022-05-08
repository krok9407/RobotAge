
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private bool SpellOrItem;
public void OnDrop(PointerEventData eventData){
        if(eventData.pointerDrag !=null){
            eventData.pointerDrag.transform.SetParent(this.transform, true);
            var slotSize = GetComponent<RectTransform>().sizeDelta; 
            var item = eventData.pointerDrag.gameObject;
            Debug.Log(item.GetComponent<RectTransform>().anchoredPosition);
            item.GetComponent<RectTransform>().anchoredPosition = new Vector2(slotSize.x/2,-slotSize.y/2);     
         
        if(this.transform.parent.name=="ItemsSlot")
        {
            eventData.pointerDrag.GetComponent<DragDrop>().ItemOnRobot=true;
        }
        else
        {
         eventData.pointerDrag.GetComponent<DragDrop>().ItemOnRobot=false;
        }
    if(SpellOrItem){
        var spell = eventData.pointerDrag;
        var newPicSpell = spell.GetComponent<Image>().sprite;
        var checkSpell = spell.GetComponent<DragDrop>().SpellOrItem;

        if(checkSpell){
            gameObject.GetComponent<Image>().sprite = newPicSpell;
        }
    }
    }
}
}
