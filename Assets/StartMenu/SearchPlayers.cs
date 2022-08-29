using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchPlayers : MonoBehaviour
{
    private InputField inputSearch;
    private List<GameObject> listAllPlayers;
    public createPlayerIcon _createPlayerIcon;

    private void Start() {
        inputSearch = gameObject.GetComponent<InputField>();
        listAllPlayers = _createPlayerIcon.buttons;
    }
    public void filterPlayers(){
        string searchingPlayer = inputSearch.text.ToLower();
        for(int i=0; i<listAllPlayers.Count;i++){
            var labelPlayerName = listAllPlayers[i].transform.GetChild(1).gameObject;
            string playerName = labelPlayerName.GetComponent<Text>().text.ToLower();
            if(!playerName.StartsWith(searchingPlayer)){
                listAllPlayers[i].SetActive(false);
            }
            else{
                listAllPlayers[i].SetActive(true);
            }
        }
    }
}
