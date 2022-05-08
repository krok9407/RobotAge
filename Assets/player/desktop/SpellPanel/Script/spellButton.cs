using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spellButton : SpellKeys
{   
     public GameObject Panel;
     private RectTransform PanelRT;
      public int numberOfSpell;
   public GameObject keyName;
   private RectTransform keyNameRT;
   private GameObject newKeyName;
private RectTransform newKeyNameRT;

   public GameObject buttonSpell;
   private RectTransform buttonSpellRT;
   private GameObject newButtonSpell;
private RectTransform newButtonSpellRT;
    public float xKeyName;
    public float yKeyName;
    public float widthKeyName;
    public float heightKeyName;

    public float widthButtonSpell;
    public float heightButtonSpell;
    public float xButtonSpell;
   public float  yButtonSpell;
   private  float marginXButton;
 private Image newButtonSpellImage;
 private float newXButtonSpell;

     void Start(){

      PanelRT = Panel.GetComponent<RectTransform>();
      keyNameRT= keyName.GetComponent<RectTransform>();
      buttonSpellRT= buttonSpell.GetComponent<RectTransform>();
    
        widthKeyName=PanelRT.sizeDelta.y*0.35f;
        heightKeyName=PanelRT.sizeDelta.y*0.35f;

        widthButtonSpell=PanelRT.sizeDelta.y*0.5f;
        heightButtonSpell=PanelRT.sizeDelta.y*0.5f;

        buttonSpellRT.sizeDelta = new Vector2(widthButtonSpell,heightButtonSpell);
       
        keyNameRT.sizeDelta = new Vector2(widthKeyName,heightKeyName);
       
        marginXButton= (PanelRT.sizeDelta.x-(widthButtonSpell*numberOfSpell))/(numberOfSpell+1);
        xButtonSpell=(-PanelRT.sizeDelta.x/2f)+marginXButton;
 
        yKeyName=PanelRT.sizeDelta.y*0.45f-(heightKeyName/2);
        yButtonSpell=-PanelRT.sizeDelta.y*0.45f+(heightButtonSpell/2);
    
    for(int i=0;i<numberOfSpell;i++)
                    {
                       
                        newXButtonSpell =  xButtonSpell+marginXButton*i+widthButtonSpell*i+widthButtonSpell/2f;
                        Vector3 newVectorButton = new Vector3(newXButtonSpell, yButtonSpell);
                        newButtonSpell = Instantiate(buttonSpell, newVectorButton, Quaternion.identity) as GameObject;
                        newButtonSpell.transform.SetParent(Panel.transform, false);
                        newButtonSpell.name=(i+1).ToString()+"buttonSpell";
                        var picNewButtonSpell = newButtonSpell.GetComponent<Image>();
                        picNewButtonSpell.sprite = spritesSpell[i];
                        buttons.Add(newButtonSpell);
                        
                        xKeyName =  newXButtonSpell;
                        Vector3 newVectorKeyName = new Vector3(xKeyName, yKeyName);
                        newKeyName = Instantiate(keyName, newVectorKeyName, Quaternion.identity) as GameObject;
                        newKeyName.transform.SetParent(Panel.transform, false);
                        if(i==9){
                          newKeyName.GetComponent<Text>().text="0";
                        }
                        else{
                        newKeyName.GetComponent<Text>().text=(i+1).ToString();
                        }
                        newKeyName.name=(i+1).ToString();
                        keys.Add(newKeyName);
                     }
                    
    }
    
   public void ChangePositionSpell(){
        PanelRT = Panel.GetComponent<RectTransform>();
        widthButtonSpell=PanelRT.sizeDelta.y*0.5f;
        heightButtonSpell=PanelRT.sizeDelta.y*0.5f;
        
    
        marginXButton= (PanelRT.sizeDelta.x-(widthButtonSpell*numberOfSpell))/(numberOfSpell+1);
        xButtonSpell=(-PanelRT.sizeDelta.x/2f)+marginXButton;
 

 for(int i=0;i<numberOfSpell;i++)
                    {
                     newButtonSpell = buttons[i];
                     newButtonSpellRT=newButtonSpell.GetComponent<RectTransform>();
                     newButtonSpellRT.sizeDelta = new Vector2(widthButtonSpell,heightButtonSpell);
                     newXButtonSpell =  xButtonSpell+marginXButton*i+widthButtonSpell*i+widthButtonSpell/2f;
                     newButtonSpellRT.anchoredPosition = new Vector2(newXButtonSpell,yButtonSpell); 
                    
                  
                     newKeyName = keys[i];
                     newKeyNameRT=newKeyName.GetComponent<RectTransform>();
                     newKeyNameRT.sizeDelta = new Vector2(widthKeyName,heightKeyName);
                     xKeyName =  newXButtonSpell;
                     newKeyNameRT.anchoredPosition = new Vector2(xKeyName,yKeyName); 
                    
                   
                   }

   }     

 private void Update() {
    foreach(var x in keys)
    {
      if(Input.GetKeyDown(x.GetComponent<Text>().text)){
          choiceSpell("turell");
      }
    }  
}
  
}
