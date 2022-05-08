using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
 using UnityEngine.Events;
 using UnityEngine.EventSystems;

public class HighlightedButton : MonoBehaviour,ISelectHandler, IDeselectHandler 
{
    private Text _button;
    public string defaultText;
    void Start()
    {
        _button = GetComponent<Text>();
        defaultText=_button.text;
    }
    public void OnSelect(BaseEventData eventData)
    {
         _button.text=">"+defaultText;
    }
    public void OnDeselect (BaseEventData data) 
    {
         _button.text=defaultText;
    }
}
