using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptForNameSpace : MonoBehaviour
{
    public InputField _name;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClearPole(){
        _name.text = null;
    }
}
