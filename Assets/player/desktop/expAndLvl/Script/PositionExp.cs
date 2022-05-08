using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionExp : MonoBehaviour
{
     public GameObject Canvas;
    public GameObject ExpAndLvl;
    public GameObject PanelExp;
    public GameObject Arrow;
    public GameObject ExpBar;
    public GameObject LedPanel;
    public GameObject GasPanel;
    public List<GameObject> Leds = new List<GameObject>();
    public List<GameObject> Gas = new List<GameObject>();
  
    private RectTransform CanvasRT;
    private RectTransform ExpAndLvlRT;
    private RectTransform PanelExpRT;
    private RectTransform ArrowRT;
    private RectTransform ExpBarRT;
    private RectTransform LedPanelRT;
    private RectTransform GasPanelRT;
    private List<RectTransform> LedsRT = new List<RectTransform>();
    private List<RectTransform> GasRT = new List<RectTransform>();
  
  private float proportionBack;
  private float proportionVolt;
  private float proportionLed;
  private float proportionGas;
    void Start()
    {
        CanvasRT=Canvas.GetComponent<RectTransform>();
        ExpAndLvlRT=ExpAndLvl.GetComponent<RectTransform>();
        PanelExpRT=PanelExp.GetComponent<RectTransform>();
        ArrowRT=Arrow.GetComponent<RectTransform>();
        ExpBarRT=ExpBar.GetComponent<RectTransform>();
        LedPanelRT=LedPanel.GetComponent<RectTransform>();
        GasPanelRT=GasPanel.GetComponent<RectTransform>();
        for(int i=0; i<Leds.Count;i++){
        LedsRT.Add(Leds[i].GetComponent<RectTransform>());
        }
         for(int i=0; i<Gas.Count;i++){
        GasRT.Add(Gas[i].GetComponent<RectTransform>());
        }
        proportionLed=LedsRT[1].sizeDelta.y/LedsRT[1].sizeDelta.x;
        proportionGas=GasRT[1].sizeDelta.y/GasRT[1].sizeDelta.x;
         
          proportionVolt = ExpBarRT.sizeDelta.y/ExpBarRT.sizeDelta.x;
    proportionBack = PanelExpRT.sizeDelta.y/PanelExpRT.sizeDelta.x;
         proportionLed=LedsRT[1].sizeDelta.y/LedsRT[1].sizeDelta.x;
         proportionGas=GasRT[1].sizeDelta.y/GasRT[1].sizeDelta.x;
         proportionVolt = ExpBarRT.sizeDelta.y/ExpBarRT.sizeDelta.x;
  
        ExpAndLvlRT.sizeDelta= CanvasRT.sizeDelta;
        float widthPanel=CanvasRT.sizeDelta.x*0.12f;
        float heightPanel=widthPanel*proportionBack;
        float xPanel=CanvasRT.sizeDelta.x*0.9f;
        float yPanel=CanvasRT.sizeDelta.y*0.23f;

        PanelExpRT.sizeDelta = new Vector2(widthPanel,heightPanel);
        PanelExpRT.anchoredPosition = new Vector2(xPanel,yPanel);
         
        float x=widthPanel*0.58f;
        float y=-widthPanel*0.03f;
        float width=widthPanel*0.4f;
        float height=proportionVolt*width;
           
        ExpBarRT.sizeDelta = new Vector2(width,height);
        ExpBarRT.anchoredPosition = new Vector2(x,y); 

        x=width*0.0058122f;
        y=height*0.0893182f;

        ArrowRT.sizeDelta = new Vector2(width,height);
        ArrowRT.anchoredPosition = new Vector2(x,y); 
    
        width=widthPanel;
        height=widthPanel*0.36f;
        x=0;
        y=-heightPanel+height;
    
        LedPanelRT.sizeDelta = new Vector2(width,height);
        LedPanelRT.anchoredPosition = new Vector2(x,y);  

       var heightGasPanel=heightPanel-height;
        var xGas=0;
        var yGas=0;
    
        GasPanelRT.sizeDelta = new Vector2(width,heightGasPanel);
        GasPanelRT.anchoredPosition = new Vector2(xGas,yGas);  



        for(int i=0; i<LedsRT.Count;i++){
            var widthLed=width*0.195f;
            var heightLed=widthLed*proportionLed;

            x=widthPanel*0.0125f+widthLed*i;
            y=-((height-heightLed)/2);
            
            LedsRT[i].sizeDelta = new Vector2(widthLed,heightLed);
            LedsRT[i].anchoredPosition = new Vector2(x,y);  
        }

          for(int i=0; i<GasRT.Count;i++){
            var widthGas=width*0.17f;
            var heightGas=widthGas*proportionGas;

            x=widthPanel*0.0125f+widthGas*i;
            y=-heightGasPanel+heightGas;
            
            GasRT[i].sizeDelta = new Vector2(widthGas,heightGas);
            GasRT[i].anchoredPosition = new Vector2(x,y);  
        }
           
    }
/*
    void Update()
    {
       
      
    }
   */
}
