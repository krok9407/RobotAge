using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInfo", menuName = "RobotAge/PlayerInfo", order = 0)]
public class PlayerInfo : ScriptableObject {
   public enum classes 
   {танк,инженер,отшельник};
   public classes classRobot;
   public string nickName;
   public string nameGild;
   public float goldValue;
   public int achivmentValue;
   public int itemsLvlValue;
   public int lvlCount;
   public GameObject modelRobot;
}
