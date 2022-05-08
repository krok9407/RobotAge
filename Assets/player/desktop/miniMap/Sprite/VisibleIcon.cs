using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VisibleIcon : MonoBehaviour
{
    private ColorBlock theColor;
    public Camera cam;
    public Button btn;
    bool visibility=true;
    bool[] mask={true,true,true};
    private void Awake() {
        theColor = GetComponent<Button>().colors;
    }
    public void ChangeVisibility(){
        if(visibility){
        theColor.highlightedColor = Color.grey;
        theColor.normalColor = Color.grey;
        theColor.pressedColor = Color.grey; 
        theColor.selectedColor = Color.grey;
        btn.colors = theColor;
        visibility=false;
        }
        else
        {
        theColor = GetComponent<Button>().colors;
        theColor.highlightedColor = Color.white;
        theColor.normalColor = Color.white;
        theColor.pressedColor = Color.white; 
        theColor.selectedColor = Color.white;
        btn.colors = theColor;
        visibility=true;
        }
    }
    public void VisibleVendor(){
         if(visibility){
            cam.cullingMask &=  ~(1 << LayerMask.NameToLayer("Vendor"));
         }
         else{
            cam.cullingMask |= 1 << LayerMask.NameToLayer("Vendor");
         }
    }
     public void VisibleClass(){
         if(visibility){
           cam.cullingMask &=  ~(1 << LayerMask.NameToLayer("Class_Trainer"));
         }
         else{
            cam.cullingMask |= 1 << LayerMask.NameToLayer("Class_Trainer");
         }
    }
     public void VisibleProfession(){
         if(visibility){
                    cam.cullingMask &=  ~(1 << LayerMask.NameToLayer("Profession"));
         }
         else{
            cam.cullingMask |= 1 << LayerMask.NameToLayer("Profession");
         }
    }
}
