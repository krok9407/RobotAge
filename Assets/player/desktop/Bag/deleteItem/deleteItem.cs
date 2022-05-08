using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class deleteItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private bool hoverItem=false;
    IEnumerator coroutine;
    private void Awake() {
        coroutine=waitDeleteOrExit();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        StartCoroutine(coroutine);
    }
      public void OnPointerExit(PointerEventData eventData)
    {
        StopCoroutine(coroutine);
    }
    IEnumerator waitDeleteOrExit(){
       yield return new WaitUntil(() => Input.GetKeyUp(KeyCode.Delete)); 
        Destroy(gameObject);
        StopCoroutine(coroutine);
    }
}
