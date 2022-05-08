using UnityEngine;
using UnityEngine.UI;

public class openCharecterDataBase : MonoBehaviour
{
    public void ClearImage(Image img){
        img.sprite = null;
    }
    public void InvisibleImage(Image img){
        img.sprite = null;
        img.color = new Color(1f,1f,1f,0f);
    }
    public void fillImage(Image img){
        img.color = new Color(1f,1f,1f,1f);
    }
}
