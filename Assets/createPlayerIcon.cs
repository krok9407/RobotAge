using UnityEngine;
using UnityEngine.UI;

public class createPlayerIcon : MonoBehaviour
{
    public PlayerInfo[] players;
    public Transform spawnRobotModel;

    [SerializeField] private GameObject PlayerBox;
    [SerializeField] private Sprite IconEngineer;
    [SerializeField] private Sprite IconTank;
    [SerializeField] private Sprite IconRough;
    [SerializeField] private GameObject InfoLabel;
                      
    
    void Awake()
    {
         GameObject ButtonInGame = InfoLabel.GetComponentInChildren<ButtonInGame>().gameObject;
        
        if(players.Length>0){
             ButtonInGame.SetActive(true);
        Text LabelNickName = InfoLabel.GetComponentInChildren<LabelNickName>().GetComponent<Text>();
        Text LabelLvlCount = InfoLabel.GetComponentInChildren<LabelLvlCount>().GetComponent<Text>();
        Text LabelItemsLvlValue = InfoLabel.GetComponentInChildren<LabelItemsLvlValue>().GetComponent<Text>();
        Text LabelClassRobot= InfoLabel.GetComponentInChildren<LabelClassRobot>().GetComponent<Text>();
        Text LabelAchivmentValue = InfoLabel.GetComponentInChildren<LabelAchivmentValue>().GetComponent<Text>();
        Text LabelGoldValue = InfoLabel.GetComponentInChildren<LabelGoldValue>().GetComponent<Text>();
        Text LabelNameGild = InfoLabel.GetComponentInChildren<LabelNameGild>().GetComponent<Text>();
             
        foreach(PlayerInfo player in players){
            var newVox = Instantiate(PlayerBox, transform);
            var img = newVox.transform.GetChild(0).GetComponent<Image>();
             var text = newVox.transform.GetChild(1).GetComponent<Text>();
             var button =  newVox.GetComponent<Button>();
           if(player.classRobot == PlayerInfo.classes.инженер){
                img.sprite = IconEngineer;
            }else if(player.classRobot == PlayerInfo.classes.танк){
                img.sprite = IconTank;
            }else if(player.classRobot == PlayerInfo.classes.отшельник){
                img.sprite = IconRough;
            }
            var modelRobot = Instantiate(player.modelRobot,spawnRobotModel.position,spawnRobotModel.rotation);
            modelRobot.transform.SetParent(spawnRobotModel);
            modelRobot.SetActive(false);
            text.text = player.nickName; 
             button.onClick.AddListener(()=> {
                 for(int i=0;i<spawnRobotModel.transform.childCount;i++){
                     spawnRobotModel.transform.GetChild(i).gameObject.SetActive(false);
                 }
                LabelNickName.text = player.nickName;
                LabelLvlCount.text =  player.lvlCount.ToString();
                LabelItemsLvlValue.text =  player.itemsLvlValue.ToString();
                LabelClassRobot.text =  player.classRobot.ToString();
                LabelAchivmentValue.text =  player.achivmentValue.ToString();
                LabelGoldValue.text =  player.goldValue.ToString();
                LabelNameGild.text =  player.nameGild;
                modelRobot.SetActive(true);
             });
             if(players[0] == player){
                 button.Select();
                LabelNickName.text = player.nickName;
                LabelLvlCount.text =  player.lvlCount.ToString();
                LabelItemsLvlValue.text =  player.itemsLvlValue.ToString();
                LabelClassRobot.text =  player.classRobot.ToString();
                LabelAchivmentValue.text =  player.achivmentValue.ToString();
                LabelGoldValue.text =  player.goldValue.ToString();
                LabelNameGild.text =  player.nameGild;
                 modelRobot.SetActive(true);
             }
        }
        
    }else{
        ButtonInGame.GetComponent<Text>().text = "Create";
        
         ButtonInGame.GetComponent<Button>().onClick.AddListener(()=> {
             
         });
        GameObject ButtonDelete = InfoLabel.GetComponentInChildren<ButtonDelete>().gameObject;
        ButtonDelete.SetActive(false);
    }


    }
}
