using UnityEditor;
  using UnityEngine;
 using System.Collections.Generic;
 
[CustomEditor(typeof(items))]
public class EditorMoveBehavior : Editor {
 
    //AttackType type;
    items item;
 
    private void OnEnable ()
    {
        item = (items) target;
    }
 
    public override void OnInspectorGUI () // Переопределяем метод который рисует испектор
    {
        EditorGUILayout.BeginVertical (); // Это чтобы элементы были вертикально друг за другом
 
        item.type = (Type)EditorGUILayout.EnumPopup  ("Type", item.type);
 
 
        if (item.type == Type.Оружие) // если air рисуем поле типа float с именем Speed
        {
            item.speed = EditorGUILayout.FloatField ("Урон", item.Damage);
        }
       
 
        EditorGUILayout.EndVertical ();
          EditorUtility.SetDirty(item);
    }
}