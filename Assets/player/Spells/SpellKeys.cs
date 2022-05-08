using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class SpellKeys : MonoBehaviour
{
   public List<GameObject> buttons = new List<GameObject>();
   public List<GameObject> keys = new List<GameObject>();
  public List<Sprite> spritesSpell = new List<Sprite>();
  public List<string> nameSpell = new List<string>();
  public GameObject spellCanvas;
public void changeKeySpell(string keyBind, int position){
    var textKey = keys[position].GetComponent<Text>();
    textKey.text=keyBind; 
}
public void changeSpell(Sprite picSpell, int position, string nameSpell){
    var picButton = buttons[position].GetComponent<Image>();
    picButton.sprite = picSpell;
    buttons[position].name=nameSpell;
}
public void choiceSpell(string name){
    switch(name){
        case "turell":{
            var test = spellCanvas.GetComponentInChildren<turell>();
           test.enabled=true;
            break;
        }
    }
}
}
