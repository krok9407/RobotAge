using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCam : MonoBehaviour
{
    [SerializeField] private GameObject bag;
    [SerializeField] private GameObject ItemsSlot;
    [SerializeField] private GameObject spellBook;
    private UnityStandardAssets.Cameras.FreeLookCam scriptCam;
    private void Awake() {
        scriptCam= this.GetComponent<UnityStandardAssets.Cameras.FreeLookCam>();
    }
        void Update()
    {
        if(bag.activeSelf || ItemsSlot.activeSelf || spellBook.activeSelf)
        {
           scriptCam.enabled = false;
        }
        else
        {
          scriptCam.enabled = true;
        }

    }
}
