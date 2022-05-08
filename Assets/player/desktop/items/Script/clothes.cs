using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clothes : MonoBehaviour
{
    public GameObject items;
    // Start is called before the first frame update
    void Start()
    {
         items.SetActive(false);
    }
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.E))
        {
            if(items.activeSelf){
            items.SetActive(false);
            }
            else
            {
                items.SetActive(true); 
            }
        }
    }
}
