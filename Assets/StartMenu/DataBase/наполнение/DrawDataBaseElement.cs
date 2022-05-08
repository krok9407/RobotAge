using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DrawDataBaseElement : CreateListElementsDataBase
{
    [SerializeField]private GameObject infoBox;
    [SerializeField]private Image characterPic;
    [SerializeField]private Image mainPic;
    [SerializeField]private GameObject textCharecter;
    [SerializeField]private GameObject textPlaces;

    public void createCharectersElement(){
        closeDataBase();
        InstantiateElements(charectersList); 
    }
      public void createPlacesElement(){
          closeDataBase();
        InstantiateElements(placesList);
    }
    public void createEventsElement(){
        closeDataBase();
        InstantiateElements(eventsList);
    }
    public void createEnemysElement(){
        closeDataBase();
        InstantiateElements(enemysList);
    }
    public void closeDataBase(){
        for (int i=0; i<transform.childCount; i++){
            Destroy(transform.GetChild(i).gameObject);
        }
    }
    
public void openInfo(DataBaseElement element){
    GameObject infoText=null;
    Image picInfo=null;
    Text descriptionText=null;
    if(element.belonging==DataBaseElement.Belonging.Персонаж || element.belonging==DataBaseElement.Belonging.Злодей){
        picInfo = characterPic;
        textPlaces.SetActive(false);
        infoText= textCharecter;
        descriptionText =  infoText.transform.GetChild(1).GetComponent<Text>();
    }
    else if(element.belonging==DataBaseElement.Belonging.Событие|| element.belonging==DataBaseElement.Belonging.Локация){
        picInfo = mainPic;
        textCharecter.SetActive(false);
        infoText=textPlaces;
        descriptionText =  infoText.transform.GetChild(2).GetComponent<Text>();
    }
        infoText.SetActive(true);
        picInfo.sprite = element.sprite;
        infoText.transform.GetChild(0).GetComponent<Text>().text = element.Name;
        descriptionText.text = element.description;
}
    void InstantiateElements(List<DataBaseElement> listElements){
        int i = 0;
        foreach(DataBaseElement element in listElements){
            
            GameObject newBox = Instantiate(infoBox, transform);
            newBox.name = element.Name;
            newBox.transform.GetChild(1).GetComponent<Text>().text = element.Name;
            newBox.transform.GetChild(0).GetComponent<Image>().sprite = element.sprite;
            newBox.GetComponent<Button>().onClick.AddListener(() => openInfo(element));
            if(i==0){
                newBox.GetComponent<Button>().Select();
                openInfo(element);
            }
            i++;
        }
    }
}
