using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListPlayersInfo : MonoBehaviour
{
    public List<PlayerInfo> players = new List<PlayerInfo>();

    public void DeletePlayers(PlayerInfo player){
        players.Remove(player);
    }

    public void CreateNewPlayers(PlayerInfo player){
        players.Add(player);
    }
}
