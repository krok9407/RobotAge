using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CreateListElementsDataBase : MonoBehaviour
{   
    public List<DataBaseElement> charectersList = new List<DataBaseElement>();
    public List<DataBaseElement> placesList = new List<DataBaseElement>();
    public List<DataBaseElement> eventsList = new List<DataBaseElement>();
    public List<DataBaseElement> enemysList = new List<DataBaseElement>();
    
    void validationElements(List<DataBaseElement> listElements, DataBaseElement.Belonging type,  string textType){
        List<DataBaseElement> clearElements = new List<DataBaseElement>();
        foreach(DataBaseElement element in listElements){
            if(element.belonging!=type){
                clearElements.Add(element);
            }
        }
        for(int i=0; i<clearElements.Count; i++){
            Debug.LogError(clearElements[i].Name+" не "+textType+". Это - "+clearElements[i].belonging);
            listElements.Remove(clearElements[i]);
        }
        clearElements.Clear();
    }
    void checkDoblications(List<DataBaseElement> listElements){
         List<DataBaseElement> withoutDoubleElements = new HashSet<DataBaseElement>(listElements).ToList();
         if(withoutDoubleElements.Count<listElements.Count){
              Debug.LogError("Вы добавили "+(listElements.Count-withoutDoubleElements.Count)+" лиших элементов");
             listElements.Clear();
             foreach(DataBaseElement element in withoutDoubleElements){
                 listElements.Add(element);
             }
         }
    }
    void OnValidate(){ Debug.ClearDeveloperConsole();

        checkDoblications(charectersList);
        checkDoblications(placesList);
        checkDoblications(eventsList);
        checkDoblications(enemysList);


        validationElements(charectersList, DataBaseElement.Belonging.Персонаж,"персонаж");
        validationElements(placesList, DataBaseElement.Belonging.Локация,"локация");
        validationElements(eventsList, DataBaseElement.Belonging.Событие,"событие");
        validationElements(enemysList, DataBaseElement.Belonging.Злодей,"злодей");
    }
  
}
