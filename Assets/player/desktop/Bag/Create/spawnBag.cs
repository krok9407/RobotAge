using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawnBag : startInventar
{
    [HideInInspector]public GameObject Panel;
    public GameObject Bag;
    public int sizeBag;
    public GameObject Button;
    private GameObject newButton;
    public List<GameObject> Buttons;
    public List<GameObject> Items;
    public GameObject bagPanel;
    public GameObject itemPref;
    public GameObject Canvas;
    private bool flag;
    private GameObject newItem;
    public GameObject infoPanel;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        RectTransform bagRT = Bag.GetComponent<RectTransform>();
        RectTransform CanvasRT = Canvas.GetComponent<RectTransform>();
        Panel=Instantiate(bagPanel, transform.position, Quaternion.identity) as GameObject;
        Panel.transform.SetParent(Bag.transform, false);
        RectTransform panelRT = Panel.GetComponent<RectTransform>();
        bagRT.sizeDelta= CanvasRT.sizeDelta;
       
         Bag.SetActive(false);
        
        float heightBag = sizeBag/5*50+10;
        float xButton = Button.transform.localPosition.x;
        float yButton = Button.transform.localPosition.y;
        panelRT.sizeDelta= new Vector2(260,heightBag);
        panelRT.anchoredPosition=new Vector2(bagRT.sizeDelta.x*0.14f,-bagRT.sizeDelta.y*0.5f+panelRT.sizeDelta.y*0.5f);
        
        for(int i=0;i<sizeBag/5;i++)
                {
                    for(int j=0;j<5;j++){
                    newButton = Instantiate(Button, transform.position = new Vector3(xButton+50*j,yButton-50*i,0), Quaternion.identity) as GameObject;
                    newButton.transform.SetParent(Panel.transform, false);
                    Buttons.Add(newButton);
                    }
                }
                PushStartBag();
     DrawItems();
         
             
    }

    void reDrawItems(int id){
        for(int i=0; i<Items.Count;i++)
       {
           if(Items[i].name==id.ToString()){
           Destroy(Items[i]);
           Items.Remove(Items[i]);
           }
           
       }
       
    }
    void DrawItems(){
         for (int i = 0; i < inventoryItems.Count; i++)
        {
            var item = inventoryItems[i];
            RectTransform rc =  Buttons[i].GetComponent<RectTransform>();
            newItem = Instantiate(itemPref, transform.position = new Vector3(rc.anchoredPosition.x,rc.anchoredPosition.y), Quaternion.identity) as GameObject;     
            newItem.GetComponent<RectTransform>().sizeDelta = new Vector2(rc.sizeDelta.x,rc.sizeDelta.y);
            var picItem = newItem.transform.GetChild(1).gameObject;
            picItem.GetComponent<Image>().sprite = item.Icon;
            newItem.transform.SetParent(Panel.transform, false);
            newItem.name = item.id.ToString();
            //узнать зачем тут я это сделал
            newItem.GetComponent<ItemComponent>().Item=item;
            Items.Add(newItem);
            infoPanel = newItem.transform.GetChild(2).gameObject;

            var changeText = infoPanel.transform.GetChild(0).gameObject;   
            changeText.GetComponent<Text>().text=item.Name;

            changeText = infoPanel.transform.GetChild(1).gameObject;
            changeText.GetComponent<Text>().text = item.quality.ToString();
            
            changeText = infoPanel.transform.GetChild(2).gameObject;
            changeText.GetComponent<Text>().text = "Тип предмета: "+item.type.ToString();

            changeText = infoPanel.transform.GetChild(3).gameObject;
            if(item.Stats_1!=0){
            changeText.GetComponent<Text>().text = "+"+item.Stats_1.ToString()+" к ёмкости батареи";
            }
            else{
                Destroy(changeText);
            }
             if(item.Stats_2!=0){
            changeText = infoPanel.transform.GetChild(4).gameObject;
            changeText.GetComponent<Text>().text = "+"+item.Stats_2.ToString()+" к мощности приводов";
             } else{
                Destroy(changeText);
            }
             if(item.Stats_3!=0){
            changeText = infoPanel.transform.GetChild(5).gameObject;
            changeText.GetComponent<Text>().text = "+"+item.Stats_3.ToString()+" к квалитету качества";
             } else{
                Destroy(changeText);
            }
             if(item.Stats_4!=0){
            changeText = infoPanel.transform.GetChild(6).gameObject;
            changeText.GetComponent<Text>().text = "+"+item.Stats_4.ToString()+" к вычислительной мощности";
             } else{
                Destroy(changeText);
            }
             if(item.Stats_5!=0){
            changeText = infoPanel.transform.GetChild(7).gameObject;
            changeText.GetComponent<Text>().text = "+"+item.Stats_5.ToString()+" к разрешению светочувствительных сенсоров";
             } else{
                Destroy(changeText);
            }
            changeText = infoPanel.transform.GetChild(6).gameObject;
            changeText.GetComponent<Text>().text = "Прочность: "+item.Strength.ToString();
            
            changeText = infoPanel.transform.GetChild(7).gameObject;
            changeText.GetComponent<Text>().text =item.Description;
            
            changeText = infoPanel.transform.GetChild(8).gameObject;
            changeText.GetComponent<Text>().text = "Цена: "+item.Price.ToString();
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.C))
        {
       if(Bag.activeSelf){
            Bag.SetActive(false);
            }
            else
            {
               // Draw();
                Bag.SetActive(true); 
            }
    }
     if(Input.GetKeyUp(KeyCode.Q)){
         DropItems(3);
         reDrawItems(3);
         //DrawItems();
     }
}
}