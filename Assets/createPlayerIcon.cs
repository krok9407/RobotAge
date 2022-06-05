using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class createPlayerIcon : MonoBehaviour
{
    ListPlayersInfo playersList;
    List<PlayerInfo> players;

    public Transform spawnRobotModel;

    [SerializeField] private GameObject PlayerBox;
    [SerializeField] private Sprite IconEngineer;
    [SerializeField] private Sprite IconTank;
    [SerializeField] private Sprite IconRough;
    [SerializeField] private GameObject InfoLabel;

    [SerializeField] private List<GameObject> buttons;
    [SerializeField] private List<GameObject> Robots;
                      
    
    void Awake()
    {
        playersList = GetComponent<ListPlayersInfo>();
        players = playersList.players;
        GameObject ButtonInGame = InfoLabel.GetComponentInChildren<ButtonInGame>().gameObject;
        
        if(players.Count>0){
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
            buttons.Add(newVox);
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
            Robots.Add(modelRobot);
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
             foreach(var btn in buttons){
                btn.GetComponent<Button>().onClick.AddListener(()=> {
                    foreach(var _btn in buttons){
                        _btn.GetComponent<Selected>().isSelect = false;
                    }
                    btn.GetComponent<Selected>().isSelect = true;
                });
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
    public void RemovePlayer(){
        for(int i=0; i<buttons.Count; i++)
        {
            if(buttons[i].GetComponent<Selected>().isSelect)
            {
                playersList.DeletePlayers(players[i]);
                Destroy(Robots[i].gameObject);
                Robots.Remove(Robots[i]);
                
                Destroy(buttons[i].gameObject);
                buttons.Remove(buttons[i]);
            }   
        }
    }
}
