using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionMap : MonoBehaviour
{
    public GameObject btnClose;
    
    public GameObject PanelIcon;
     public GameObject btnChoiceIcon;
   public GameObject Canvas;
   private RectTransform CanvasRT;

   public GameObject miniMap;
   private RectTransform miniMapRT;

   public GameObject map;
  private RectTransform mapRT;

   public GameObject board;
  private RectTransform boardRT;
     public GameObject scroll;
  private RectTransform scrollRT;

    public GameObject fullSizeButton;
  private RectTransform fullSizeButtonRT;

  public float sizePercentMapX;
  public float sizePercentMapY;
  private float heightMap;
  private float widthMap;

  private float heightBoard;
  private float widthBoard;

      private float xBoard;
       private float yBoard;

        private float xButton;
       private float yButton;

       private float widthButton;
       private float heightButton;
     void Start()
    {
      RectTransform btnChoiceIconRT = btnChoiceIcon.GetComponent<RectTransform>();
      RectTransform PanelIconRT = PanelIcon.GetComponent<RectTransform>();
      RectTransform btnCloseRT = btnClose.GetComponent<RectTransform>();
        fullSizeButtonRT=fullSizeButton.GetComponent<RectTransform>();
        scrollRT = scroll.GetComponent<RectTransform>();
        boardRT = board.GetComponent<RectTransform>();
        mapRT = map.GetComponent<RectTransform>();
        miniMapRT = miniMap.GetComponent<RectTransform>();
        CanvasRT = Canvas.GetComponent<RectTransform>();
        miniMapRT.sizeDelta= CanvasRT.sizeDelta;
        
        heightMap = CanvasRT.sizeDelta.y*sizePercentMapY/100;
        widthMap = CanvasRT.sizeDelta.x*sizePercentMapX/100;
        mapRT.sizeDelta=new Vector2(widthMap,heightMap);
        
        heightBoard = heightMap*2.9f;
        widthBoard = widthMap*2.5f;
        boardRT.sizeDelta=new Vector2(widthBoard,heightBoard);
    
        xBoard = -CanvasRT.sizeDelta.x*0.08f-widthBoard/2;
        yBoard = -CanvasRT.sizeDelta.y*0.01f-heightBoard/2;
        boardRT.anchoredPosition = new Vector2(xBoard,yBoard);
        mapRT.anchoredPosition = new Vector2(xBoard,yBoard-yBoard*0.1f);
        scrollRT.anchoredPosition = new Vector2(xBoard+widthBoard*0.44f,yBoard-yBoard*0.1f);
        float p = scrollRT.sizeDelta.y/scrollRT.sizeDelta.x, 
        
        heightScroll=heightBoard*0.76f,
        widthScroll=p*heightScroll;
        scrollRT.sizeDelta = new Vector2(heightScroll,widthScroll);
        heightButton=heightBoard/8;
        widthButton=widthBoard/4;
        xButton=xBoard;
        yButton=yBoard-heightBoard/2+heightButton/2;

    fullSizeButtonRT.sizeDelta=new Vector2(widthButton,heightButton);
    fullSizeButtonRT.anchoredPosition = new Vector2(xButton,yButton);
    
    heightButton=heightBoard*0.18f;
    widthButton=heightButton;
    
    btnCloseRT.sizeDelta=new Vector2(widthButton,heightButton);
  
   xButton=xBoard+widthBoard*0.415f;
   yButton=yBoard+heightBoard*0.42f;
    
   btnCloseRT.anchoredPosition = new Vector2(xButton,yButton);
   
   heightButton=heightBoard*0.2f;
   widthButton=heightButton;

   btnChoiceIconRT.sizeDelta=new Vector2(widthButton,heightButton);

   xButton=xBoard-widthBoard*0.3f;
   yButton=yBoard+heightBoard*0.42f;

   btnChoiceIconRT.anchoredPosition= new Vector2(xButton,yButton);
     
    xButton=xBoard-widthBoard*0.5f;
    yButton=yBoard+heightBoard*0.4f-heightButton/2f;

    PanelIconRT.anchoredPosition= new Vector2(xButton,yBoard+heightBoard/2);
   PanelIconRT.sizeDelta=new Vector2(0,0);


   }
}
