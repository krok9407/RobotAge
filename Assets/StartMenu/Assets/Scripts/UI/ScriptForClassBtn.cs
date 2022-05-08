using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptForClassBtn : MonoBehaviour
{
    public Button _btn;
    public GameObject _menu;
    bool _isWorking = false;
    public GameObject[] _check;
    bool _isClass;
    int i = 0;

    // Start is called before the first frame update
    void Start()
    {       
        _btn.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnClick(){
        switch (_isWorking){
            case true:{
                _isWorking = false;
                _menu.SetActive(false);
                break;
            }
            case false:{
                _isWorking = true;
                _menu.SetActive(true);
                break;
            }
        }
        
        //Debug.Log(_isWorking);
    }

    public void ClearPole(){
        foreach (var item in _check)
        {
            _check[i].SetActive(false);
            i++;
        }
        i = 0;
        _menu.SetActive(false);
    }
}
