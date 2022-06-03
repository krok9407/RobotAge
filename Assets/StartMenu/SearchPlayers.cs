using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchPlayers : MonoBehaviour
{
    [SerializeField] private GameObject panelListPlayers;
    [SerializeField]private InputField inputSearch;
    private List<GameObject> listAllPlayers = new List<GameObject>();

    private void Start() {
         inputSearch = gameObject.GetComponent<InputField>();
        getAllUsers();
    }

    void getAllUsers(){
        for(int i=0; i<panelListPlayers.transform.childCount;i++){
            listAllPlayers.Add(panelListPlayers.transform.GetChild(i).gameObject);
        }
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
