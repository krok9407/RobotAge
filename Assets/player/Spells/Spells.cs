using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(fileName ="newSpell", menuName="GameLibrary/Spell")]
public class Spells : ScriptableObject {
    public int id=0;
    [Header("Название заклинания")]
    public string Name = "Введите название заклинания";
    
    [Tooltip("Выберите тип: пассивное или заклинание требующее использования?")]
    public bool passive=false;
    public int damage=0;
    public float range=0;
    [Tooltip("Количество затрачиваемого ресурса")]
    public int spentResources=0;
    public string Info = "Опишите заклинание";
    [Space(-10, order = 0)]
    [Header("Эффекты и анимации заклинания", order = 1)]
    public ParticleSystem effect;
    public Animation animation;
}
