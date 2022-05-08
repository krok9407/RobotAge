using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenuAttribute(fileName ="newItem", menuName="GameLibrary/Item")]
public class items : ScriptableObject {
    public int id=0;
      [Header("Название предмета")]
    public string Name = "Items";
    public enum Quality {ржавая,новая,крафтовая,комплектная}
    
    [Space(-10, order = 0)]
    [Header("Выберите качество предмета",order = 1)]
    
    [SerializeField] public Quality quality;
   public enum ItemsType {Оружие,Голова,Руки,Ноги,Тело,Ботинки,Пояс,Плечи}
      
    [Space(-10, order = 0)]
      [Header("Выберите тип предмета", order = 1)]
    [SerializeField] public ItemsType type;
 [Space(-10, order = 0)]
      [Header("Добавьте картинку заклинания", order = 1)]
    public Sprite Icon;
     [Space(-10, order = 0)]
      [Header("Урон", order = 1)]
    public int Damage =0;
    [Space(-10, order = 0)]
      [Header("Ёмкость батареи", order = 1)]
    public int Stats_1 =0;
    
    [Space(-10, order = 0)]
      [Header("Мощность приводов", order = 1)]
    public int Stats_2=0;
    
    [Space(-10, order = 0)]
      [Header("Квалитет качества", order = 1)]
    public int Stats_3=0;
    
    [Space(-10, order = 0)]
      [Header("Вычислительная мощность", order = 1)]
       public int Stats_4=0;
       
    [Space(-10, order = 0)]
      [Header("Разрешение светочувствительных сенсоров", order = 1)]
       public int Stats_5=0;
         [Space(-10, order = 0)]
          [Header("Требуемый уровень", order = 1)]
    public int needLvl = 1;
    [Space(-10, order = 0)]
          [Header("Прочность", order = 1)]
    public int Strength = 60;
    
    [Space(-10, order = 0)]
          [Header("Цена продажи", order = 1)]
    public int Price=1;
    
    [Space(-10, order = 0)]
          [Header("Описание для игрока (ЛОР/Пасхалки)", order = 1)]
    public string Description = "Nice Item, Bro";
    
}
