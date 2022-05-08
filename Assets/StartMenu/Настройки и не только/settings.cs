using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//Обязательно импортируем для работы с UI


public class settings : MonoBehaviour
{ 

[SerializeField] Scrollbar _scrollbar;
[SerializeField] Text _textBox;
public void changeLvlGraphic()
{
    int lvlGraphic=0;
    if(_scrollbar.value<=0.1f){
        lvlGraphic=0;
        _textBox.text="Very Low";
    }else if(_scrollbar.value>0.1f && _scrollbar.value<0.3f){
        lvlGraphic=1;
        _textBox.text="Low";
    }
    else if(_scrollbar.value>=0.3f && _scrollbar.value<=0.5f){
        lvlGraphic=2;
        _textBox.text="Medium";
    }
    else if(_scrollbar.value>0.5f && _scrollbar.value<0.7f){
        lvlGraphic=3;
        _textBox.text="High";
    }else if(_scrollbar.value>=0.7f && _scrollbar.value<=0.9f){
        lvlGraphic=4;
        _textBox.text="Very High";
    }else if(_scrollbar.value>0.9f){
        lvlGraphic=5;
        _textBox.text="Ultra";
    }
QualitySettings.SetQualityLevel(lvlGraphic, true);//Изменяем уровен графики
}
}

