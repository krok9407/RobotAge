
using UnityEngine.SceneManagement;
using UnityEngine;

public class inGame : MonoBehaviour
{
    public GameObject LoadScreen;
   public void InGame(){
       SceneTransition.SwitchToScene("MainWorld");
   }
}
