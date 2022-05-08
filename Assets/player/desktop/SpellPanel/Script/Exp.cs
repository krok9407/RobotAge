using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Exp : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler

{
    
public GameObject ArrowExp;
private RectTransform ArrowExpRT;

 public float lvl;       
public float experians;
 public List<Sprite> number = new List<Sprite>();
 public List<Sprite> gasLed = new List<Sprite>();
 public List<GameObject> gasObject = new List<GameObject>();
 
 public GameObject oneExp;
 public GameObject tensExp;
 public GameObject hundredsExp;
 public GameObject thousandExp;
 public GameObject tenThousandthExp;
private Vector3 AngleRotation;
void Start(){
     ArrowExpRT = ArrowExp.GetComponent<RectTransform>(); 
defaultPic();
}

    public void OnPointerEnter(PointerEventData eventData)
    {
        var value = experians%10;
        var pic = number[(int)value];
        var ExpImg = oneExp.GetComponent<Image>();
        ExpImg.sprite = pic;

        value = (experians%100-experians%10)/10;
        pic = number[(int)value];
        ExpImg = tensExp.GetComponent<Image>();
        ExpImg.sprite = pic;

        value = (experians%1000 - experians%100)/100;
        pic = number[(int)value];
        ExpImg = hundredsExp.GetComponent<Image>();
        ExpImg.sprite = pic;

        value = (experians%10000 - experians%1000)/1000;
        pic = number[(int)value];
        ExpImg = thousandExp.GetComponent<Image>();
        ExpImg.sprite = pic;

        value = (experians%100000 - experians%10000)/10000;
        pic = number[(int)value];
        ExpImg = tenThousandthExp.GetComponent<Image>();
        ExpImg.sprite = pic;
       }
void defaultPic(){
    var pic = number[10];
        var ExpImg = oneExp.GetComponent<Image>();
        ExpImg.sprite = pic;

        ExpImg = tensExp.GetComponent<Image>();
        ExpImg.sprite = pic;

        ExpImg = hundredsExp.GetComponent<Image>();
        ExpImg.sprite = pic;
        
        ExpImg = thousandExp.GetComponent<Image>();
        ExpImg.sprite = pic;
        
        ExpImg = tenThousandthExp.GetComponent<Image>();
        ExpImg.sprite = pic;
}
   public void OnPointerExit(PointerEventData eventData)
    {
        
        defaultPic();
        }


    // Update is called once per frame
    void Update()
    {
          var valueLvl = lvl%10;
        var picLvl = gasLed[(int)valueLvl];
        var LvlImg = gasObject[2].GetComponent<Image>();
        LvlImg.sprite = picLvl;
        
        valueLvl = (lvl%100-lvl%10)/10;
        picLvl = gasLed[(int)valueLvl];
        LvlImg = gasObject[1].GetComponent<Image>();
        LvlImg.sprite = picLvl;
        
        valueLvl = (lvl%1000 - lvl%100)/100;
        picLvl = gasLed[(int)valueLvl];
        LvlImg = gasObject[0].GetComponent<Image>();
        LvlImg.sprite = picLvl;

        var fromAbs  =  experians - 0;
        var fromMaxAbs = 100000 - 0;      
       
        var normal = fromAbs / fromMaxAbs;
 
        var toMaxAbs = 96 - 0;
        var toAbs = toMaxAbs * normal;
 
        var to = toAbs + 0;

        AngleRotation = ArrowExp.transform.eulerAngles;
        AngleRotation.z = to;
        ArrowExp.transform.eulerAngles = AngleRotation;

    }
}
