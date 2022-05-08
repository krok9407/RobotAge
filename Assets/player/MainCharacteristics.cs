using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacteristics : MonoBehaviour
{
    string classRobot;
    int energy; //основня расходуемая характеристика (хп+мана)
    float capacity; //выносливость
    int motorPower; //сила
    int computingPower; //интеллект
    float range;
    float atackSpeed;
    float chanceHit;
    int quality;  //ловкость
    int damage;
    float KStrange;
    float KIntellect;
    float KStamina;
    float KAgillity;
    // Start is called before the first frame update
    void Start()
    {
        switch(classRobot){
            case "tank":{
                changeEnergy(80);
                break;
                }
            case "engeenire":{
                changeEnergy(60);
                break;
                }
            case "anchorite":{
                changeEnergy(70);
                break;
            }
        }
    }
    void changeCapacity(){
        capacity=capacity*KStamina;
    }
     void changeEnergy(int baseValue){
        energy=baseValue+(int)capacity;
    }
    void changeEnergy(int baseValue, int addItemBonus){
        energy=baseValue+(int)capacity*baseValue+addItemBonus;
    }
   
}
