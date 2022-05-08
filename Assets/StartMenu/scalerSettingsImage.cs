using UnityEngine;
using UnityEngine.UI;

public class scalerSettingsImage : MonoBehaviour
{
    [SerializeField] GameObject Panel;
   private void Start() {
       var _rtPanel = Panel.GetComponent<RectTransform>();
       var _rectTransform = GetComponent<RectTransform>();
       var prop = _rectTransform.sizeDelta.x/_rectTransform.sizeDelta.y;
       _rectTransform.sizeDelta = new Vector2 (_rtPanel.sizeDelta.y*prop,_rtPanel.sizeDelta.y);
   }
}
