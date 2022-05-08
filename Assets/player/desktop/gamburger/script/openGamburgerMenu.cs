using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class openGamburgerMenu: MonoBehaviour
{
    public GameObject Canvas;
    public GameObject Gamburger;
    public GameObject Panel;
    public GameObject Arrow;
    public bool closeOrOpenCheck=false;

    public float xArrow;
    public float yArrow;
    public float xPanel;
    public float yPanel;
    private RectTransform CanvasRT;
    private RectTransform ArrowRT;
    private RectTransform GamburgerRT;
    private RectTransform PanelRT;
    private float heightPanel;
    private float widthPanel;
    private float heightArrow;
    private float widthArrow;
    private float range=0f;

    public float PercentPositionPanelX;
    public float PercentPositionPanelY;
    public float PercentSizePanelX;
    public float PercentSizePanelY;
    public bool Vertical;

    public GameObject ObjectWithScript;
    // Start is called before the first frame update
    void Start()
    {
        CanvasRT = Canvas.GetComponent<RectTransform>();
        ArrowRT = Arrow.GetComponent<RectTransform>();
        GamburgerRT = Gamburger.GetComponent<RectTransform>();
        PanelRT = Panel.GetComponent<RectTransform>();
      
        GamburgerRT.sizeDelta= CanvasRT.sizeDelta;
      
        heightPanel = CanvasRT.sizeDelta.y*PercentSizePanelY/100;
        widthPanel = CanvasRT.sizeDelta.x*PercentSizePanelX/100;
        xPanel = CanvasRT.sizeDelta.x*PercentPositionPanelX/100;
        yPanel = CanvasRT.sizeDelta.y*PercentPositionPanelY/100;

        PanelRT.sizeDelta = new Vector2(widthPanel,heightPanel);
        PanelRT.anchoredPosition = new Vector2(xPanel,yPanel);
        
        float deltaArrow = 490f/910f;
        heightArrow = CanvasRT.sizeDelta.x*6/100;
        widthArrow = heightArrow*deltaArrow;
        
    if(Vertical){
        xArrow = xPanel-CanvasRT.sizeDelta.x*2/1000;
        yArrow = yPanel-heightPanel/2;
    }
    else
    {
        xArrow = xPanel+widthPanel/2;
        yArrow = yPanel+CanvasRT.sizeDelta.x*2/1000;;
    }    
    
        ArrowRT.sizeDelta = new Vector2(widthArrow,heightArrow);
        ArrowRT.anchoredPosition = new Vector2(xArrow,yArrow);
        
    }

   public void openOrClosePanel(){
             
            StartCoroutine(WaitAndPrint(0.0001f));
            
    }
  private IEnumerator WaitAndPrint(float waitTime)
    {
        
        if(closeOrOpenCheck){
            while (true)
            {   
                if(Vertical){
                xArrow+=CanvasRT.sizeDelta.x*0.003f;
                xPanel+=CanvasRT.sizeDelta.x*0.003f;
                widthPanel-=CanvasRT.sizeDelta.x*0.003f;}
                else{
                
                yArrow-=CanvasRT.sizeDelta.y*0.004f;
                yPanel-=CanvasRT.sizeDelta.y*0.004f;
                ObjectWithScript.GetComponent<spellButton>().yKeyName-=(CanvasRT.sizeDelta.y*0.004f);
                ObjectWithScript.GetComponent<spellButton>().yButtonSpell-=(CanvasRT.sizeDelta.y*0.004f-CanvasRT.sizeDelta.y*0.004f*0.5f);
               
                heightPanel-=CanvasRT.sizeDelta.y*0.004f;
                }
                ArrowRT.anchoredPosition = new Vector2(xArrow,yArrow);
                PanelRT.anchoredPosition = new Vector2(xPanel,yPanel);
                PanelRT.sizeDelta = new Vector2(widthPanel,heightPanel);
         ObjectWithScript.GetComponent<spellButton>().ChangePositionSpell();
                range++; 
            if(range>15){
                
            ObjectWithScript.GetComponent<spellButton>().ChangePositionSpell();
                 if(!Vertical){
                    yArrow-=(heightArrow+heightArrow*0.1f);
                }
                else{
                 xArrow+=(widthArrow*2f);
                }
                ArrowRT.anchoredPosition = new Vector2(xArrow,yArrow);
                ArrowRT.transform.Rotate(0.0f, 0.0f, -180.0f, Space.World);
                closeOrOpenCheck=false;
                range=0;

                break;
                }
                yield return new WaitForSeconds(waitTime);
            }
       
           
        }
        else{ 
            
            while (true)
            {   
                if(Vertical){
                xArrow-=CanvasRT.sizeDelta.x*0.003f;
                xPanel-=CanvasRT.sizeDelta.x*0.003f;
                widthPanel+=CanvasRT.sizeDelta.x*0.003f;
                }
                else
                {
                    yArrow+=CanvasRT.sizeDelta.y*0.004f;
                    yPanel+=CanvasRT.sizeDelta.y*0.004f;
                    ObjectWithScript.GetComponent<spellButton>().yButtonSpell+=(CanvasRT.sizeDelta.y*0.004f-CanvasRT.sizeDelta.y*0.004f*0.5f);
                    ObjectWithScript.GetComponent<spellButton>().yKeyName+=(CanvasRT.sizeDelta.y*0.004f);
                    heightPanel+=CanvasRT.sizeDelta.y*0.004f;  
                }
                
            ObjectWithScript.GetComponent<spellButton>().ChangePositionSpell();
                ArrowRT.anchoredPosition = new Vector2(xArrow,yArrow);
                PanelRT.anchoredPosition = new Vector2(xPanel,yPanel);
                PanelRT.sizeDelta = new Vector2(widthPanel,heightPanel);
        
                range++; 
            if(range>15){
                
            ObjectWithScript.GetComponent<spellButton>().ChangePositionSpell();
                if(!Vertical){
                    yArrow+=(heightArrow+heightArrow*0.1f);
                }
                else{
                 xArrow-=(widthArrow*2f);
                }
                 ArrowRT.anchoredPosition = new Vector2(xArrow,yArrow);
                ArrowRT.transform.Rotate(0.0f, 0.0f, -180.0f, Space.World);
                closeOrOpenCheck=true;
                range=0;

                break;
                }
                yield return new WaitForSeconds(waitTime);
            }
        }
    }

}