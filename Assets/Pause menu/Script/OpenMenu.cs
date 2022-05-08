using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : MonoBehaviour
{
   public GameObject PauseMenu;
   public GameObject panel;
  public GameObject ChangeButtonMenu;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)&& PauseMenu.activeSelf==false){
            PauseMenu.SetActive(true);
            panel.SetActive(true);
        }
         else if(Input.GetKeyDown(KeyCode.Escape)&& PauseMenu.activeSelf==true && ChangeButtonMenu.activeSelf==false){
             PauseMenu.SetActive(false);
            panel.SetActive(false);
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && ChangeButtonMenu.activeSelf==true){
            ChangeButtonMenu.SetActive(false);
            panel.SetActive(true);
        }
    }
}
