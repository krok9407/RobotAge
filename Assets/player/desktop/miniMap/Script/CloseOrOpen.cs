using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseOrOpen : MonoBehaviour
{
    public GameObject miniMap;
   public void SetActiveMiniMap(){
       if(miniMap.activeSelf==true){
        miniMap.SetActive(false);
       }
       else{
        miniMap.SetActive(true);
       }
   }
}
