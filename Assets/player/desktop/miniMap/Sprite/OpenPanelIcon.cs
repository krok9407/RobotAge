using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPanelIcon : MonoBehaviour
{
    public GameObject Board;
    public GameObject PanelIcon;

    public GameObject btn_Class;
    public GameObject btn_Profession;
    public GameObject btn_Vendor;
 
    RectTransform btn_ClassRT;
    RectTransform btn_ProfessionRT;
    RectTransform btn_VendorRT;


    RectTransform BoardRT;
   float x=0;
   float y=0;
   bool open=false;
   bool end=false;
   float width;
   float height;
    RectTransform PanelIconRT;
    private void Start() {
        BoardRT=Board.GetComponent<RectTransform>();
        PanelIconRT=PanelIcon.GetComponent<RectTransform>();
        btn_ClassRT=btn_Class.GetComponent<RectTransform>();
        btn_ProfessionRT=btn_Profession.GetComponent<RectTransform>();
        btn_VendorRT=btn_Vendor.GetComponent<RectTransform>();
        x=PanelIconRT.sizeDelta.x;
        y=10;
        
        width=BoardRT.sizeDelta.x/5;
        height=BoardRT.sizeDelta.y*0.9f;

        resize(btn_ClassRT,16);
        float xBtn = -width*0.1f-(width*0.9f-btn_ClassRT.sizeDelta.x)/2;
        float yBtn = -height*0.1f-(height*0.8f-(btn_ClassRT.sizeDelta.y*3))/4;
        btn_ClassRT.anchoredPosition = new Vector2(xBtn,yBtn);
       
        resize(btn_ProfessionRT,16);
        xBtn = -width*0.1f-(width*0.9f-btn_ProfessionRT.sizeDelta.x)/2;
        yBtn = yBtn-btn_ProfessionRT.sizeDelta.y-(height*0.8f-(btn_ClassRT.sizeDelta.y*3))/4;
        btn_ProfessionRT.anchoredPosition = new Vector2(xBtn,yBtn);
        
        resize(btn_VendorRT,16);
        xBtn = -width*0.1f-(width*0.9f-btn_VendorRT.sizeDelta.x)/2;
        yBtn = yBtn-btn_VendorRT.sizeDelta.y-(height*0.8f-(btn_ClassRT.sizeDelta.y*3))/4;
        btn_VendorRT.anchoredPosition = new Vector2(xBtn,yBtn);
       
                        
    }
   public void OpenPanel(){
       StartCoroutine(scrollDown(0.00001f)); 
   }
   IEnumerator scrollDown(float speed) {
       if(!open){
                while(true){
                        bool flag=false;
                        if(width>x){
                                x+=8;
                            }
                            else{
                                x=width;
                                flag=true;
                            }
                            if(height>y && flag==true){
                                y+=8;
                            }
                            else if (height<=y && flag==true){
                                open=true;
                                y=height;
                                btn_Class.SetActive(true);
                                btn_Profession.SetActive(true);
                                btn_Vendor.SetActive(true);
                                break;
                            }       
                        PanelIconRT.sizeDelta = new Vector2(x,y); 
                        yield return new WaitForSeconds(speed); 
            }  
       }      
   else{
            while(true){
                
                                btn_Class.SetActive(false);
                                btn_Profession.SetActive(false);
                                btn_Vendor.SetActive(false);
                        bool flag=false;
                        if(y>10){
                                y-=8;
                            }
                            else{
                                y=10;
                                flag=true;
                            }
                            if(x>0 && flag==true){
                                x-=8;
                            }
                            else if (x<=0 && flag==true){
                                x=0;
                                open=false;
                                
                                break;
                            }       
                        PanelIconRT.sizeDelta = new Vector2(x,y); 
                        yield return new WaitForSeconds(speed); 
            }  
   }
}

void resize(RectTransform btn, float size){
if(btn.sizeDelta.x>btn.sizeDelta.y)
{
   float k = btn.sizeDelta.x/btn.sizeDelta.y;
   float h = BoardRT.sizeDelta.y*size/100f;
   float w = h*k;
   btn.sizeDelta=new Vector2(w,h);
}
else
{
   float k = btn.sizeDelta.y/btn.sizeDelta.x;
   float h = BoardRT.sizeDelta.y*size/100f;
   float w = h/k;
   btn.sizeDelta=new Vector2(w,h);
}
}
}
