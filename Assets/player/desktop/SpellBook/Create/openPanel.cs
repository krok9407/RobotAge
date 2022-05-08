using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openPanel : MonoBehaviour
{
        public GameObject mainPanel;
    public GameObject specializationPanel;
    public GameObject professionPanel;


   public void clickMainPanel(){
            mainPanel.SetActive(true);
            specializationPanel.SetActive(false);
            professionPanel.SetActive(false);
}
public void clickSpecializationPanel(){
            mainPanel.SetActive(false);
            specializationPanel.SetActive(true);
            professionPanel.SetActive(false);
}
public void clickProfessionPanel(){
            mainPanel.SetActive(false);
            specializationPanel.SetActive(false);
            professionPanel.SetActive(true);
}
}
