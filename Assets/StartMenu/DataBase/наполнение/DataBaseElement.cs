using UnityEngine;


[CreateAssetMenuAttribute(fileName ="newDataBaseElement", menuName="GameLibrary/Database/Element")]
public class DataBaseElement : ScriptableObject {
    public int id=0;
    [Header("Название элемента DataBase")]
    public string Name = "Items";
    public enum Belonging {Персонаж,Локация,Событие,Злодей}
    
    [Space(-10, order = 0)]
    [Header("Выберите к какой базе данных принадлежит элемент",order = 1)]
    
    [SerializeField] public Belonging belonging;
   
    [Space(-10, order = 0)]
    [Header("Вставьте изображение", order = 1)]
    [SerializeField] public Sprite sprite;
    [Space(-10, order = 0)]
     [Header("Добавьте описание", order = 1)]
     [TextArea(2,20)]
    public string description;
   
}
