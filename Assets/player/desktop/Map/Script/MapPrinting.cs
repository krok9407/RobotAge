using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPrinting : MonoBehaviour
{
    public GameObject map;
    public GameObject Canvas;
    private RectTransform CanvasRT;
    public GameObject Board;
    private RectTransform BoardRT;
        public GameObject Button;
    private RectTransform ButtonRT;
    // Start is called before the first frame update
    void Start()
    {
      RectTransform  mapRT=map.GetComponent<RectTransform>();
        CanvasRT = Canvas.GetComponent<RectTransform>();
        BoardRT=Board.GetComponent<RectTransform>();
      ButtonRT=Button.GetComponent<RectTransform>();
      
      //изменить, когда будет квадратный
        mapRT.sizeDelta=new Vector2(CanvasRT.sizeDelta.x*0.92f,CanvasRT.sizeDelta.y*0.7f);
        mapRT.anchoredPosition=new Vector2(0,0);
        
        BoardRT.sizeDelta=CanvasRT.sizeDelta;
        
        ButtonRT.anchoredPosition = new Vector2(BoardRT.anchoredPosition.x,BoardRT.anchoredPosition.y-(BoardRT.sizeDelta.y*0.403f));
        ButtonRT.sizeDelta=new Vector2(CanvasRT.sizeDelta.x*0.45f,CanvasRT.sizeDelta.y*0.07f);
       }
}
