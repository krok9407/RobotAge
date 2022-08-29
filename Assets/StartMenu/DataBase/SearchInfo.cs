using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchInfo : MonoBehaviour
{
    [SerializeField] private GameObject content;
    [SerializeField]  private List <ElementsDataBase> elements = new List<ElementsDataBase>();
    private InputField inputSearch;
    private void Start() {
        inputSearch = gameObject.GetComponent<InputField>();
    }
    public void GetElements(){
        elements.Clear();
        elements = new List<ElementsDataBase>(content.GetComponentsInChildren<ElementsDataBase>());
    }

    public void FilterElements(){
        string searchingElement = inputSearch.text.ToLower();
            foreach(ElementsDataBase element in elements){
                string nameElement = element.gameObject.name;
                if(!nameElement.StartsWith(searchingElement)){
                    element.gameObject.SetActive(false);
                }
                else{
                    element.gameObject.SetActive(true);
                }
            }
    }
}
