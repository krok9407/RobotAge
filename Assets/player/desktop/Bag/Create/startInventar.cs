using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startInventar : addAndDropItems
{     [SerializeField] List<items> StartItems = new List<items>();
    protected void PushStartBag(){
       for (int i = 0; i < StartItems.Count; i++)
        {
            AddItem(StartItems[i]);
        } 
    }
}
