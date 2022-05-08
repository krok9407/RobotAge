using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapEnabled : MonoBehaviour
{
    public GameObject map;

    public void openMap(){
        map.SetActive(true);
    }
    public void closeMap(){
        map.SetActive(false);
    }
}
