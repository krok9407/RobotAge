using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListPlayersInfo : MonoBehaviour
{
    public List<PlayerInfo> players = new List<PlayerInfo>();
    [SerializeField]private GameObject buttonCreatePlayer;
    public void DeletePlayers(PlayerInfo player){
        players.Remove(player);
        if(players.Count<1){
            buttonCreatePlayer.SetActive(true);
        }
    }

    public void CreateNewPlayers(PlayerInfo player){
        players.Add(player);
    }
}
