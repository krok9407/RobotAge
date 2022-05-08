using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScaleMenu : MonoBehaviour
{
    public GameObject canvas;
    private  int position=0;
    private bool check = false;
    private string key ="";
    public GameObject btn;
    public GameObject spellButton;
    private GameObject newButton;   
    public GameObject Canvas;
    public GameObject panel;
    public GameObject panelSetButton;
    public GameObject panelPreference;
 
    private void Awake() {
        RectTransform CanvasRT = Canvas.GetComponent<RectTransform>();
        RectTransform panelRT = panel.GetComponent<RectTransform>();
        RectTransform panelSetButtonRT = panelSetButton.GetComponent<RectTransform>();

         float xPanel = CanvasRT.sizeDelta.x*0.35f;
         float yPanel = CanvasRT.sizeDelta.y*0.27f;
         float heightPanel = CanvasRT.sizeDelta.y*0.72f;
         float widthPanel = CanvasRT.sizeDelta.x*0.3f;

        panelRT.sizeDelta= new Vector2(widthPanel,heightPanel);
        panelRT.anchoredPosition = new Vector2(xPanel,yPanel);

        panelSetButtonRT.sizeDelta=panelRT.sizeDelta;
        panelSetButtonRT.anchoredPosition=panelRT.anchoredPosition;

        float heightBtn = heightPanel*0.15f;
        float widthBtn = widthPanel*0.8f;
float yBtn;
        for(int i=1; i<5;i++){
         yBtn= heightPanel*0.08f*i+heightBtn*(i-1);
        newButton = Instantiate(btn, btn.transform.position = new Vector3(widthPanel*0.1f,-yBtn), Quaternion.identity);
        newButton.GetComponent<RectTransform>().sizeDelta= new Vector2(widthBtn,heightBtn);
         var newBtn=newButton.GetComponent<Button>();
         switch(i){
            case 1:{
                newBtn.GetComponentInChildren<Text>().text = "Start";
                newBtn.onClick.AddListener(backToGame);
                break;
            }
            case 2:{
                newBtn.GetComponentInChildren<Text>().text = "Preference";
                newBtn.onClick.AddListener(openPreference);
                break;
            }
            case 3:{
                newBtn.GetComponentInChildren<Text>().text = "Change Button";
                newBtn.onClick.AddListener(openSetButton);
                break;
            }
            case 4:{
                newBtn.GetComponentInChildren<Text>().text = "Exit";
                newBtn.onClick.AddListener(Quit);
                break;
            }
        
        }
        newButton.transform.SetParent(panel.transform, false);
        } 
        float xBtn=widthPanel*0.1f;
        int j=0;
        for(int i=1; i<11;i++){
             
        heightBtn = heightPanel*0.14f;
         widthBtn = widthPanel*0.35f;
         if(i>5){
            xBtn=widthBtn+widthPanel*0.2f;
            j=5;
         }
        yBtn= heightPanel*0.05f*(i-j)+heightBtn*(i-1-j);
        newButton = Instantiate(btn, btn.transform.position = new Vector3(xBtn,-yBtn), Quaternion.identity);
        newButton.GetComponent<RectTransform>().sizeDelta= new Vector2(widthBtn,heightBtn);
        newButton.name=(i-1).ToString();
        var newBtn=newButton.GetComponent<Button>();
 
       if(i==10){
        newBtn.GetComponentInChildren<Text>().text ="0";
        }
        else{
         newBtn.GetComponentInChildren<Text>().text =i.ToString();
        }
         newBtn.onClick.AddListener(()=>changeKey(newBtn));
        newButton.transform.SetParent(panelSetButton.transform, false);
        }    
    }
    void changeKey(Button buttonClicked){
        position = Int32.Parse(buttonClicked.name);
        StartCoroutine(waitPressButton(buttonClicked));
        }
     void OnGUI()
    {
        Event e = Event.current;
        if (e.isKey)
        {
           check=true;
            if(e.keyCode.ToString()!="None"){
                bool number = e.keyCode.ToString().Contains("Alpha");
                if(number){
                    
                }else{
                    var middleResult = e.keyCode.ToString();
                    key=middleResult.ToLower();
                }
           }
        }
        else{
            check=false;
        }
    }
    IEnumerator waitPressButton(Button buttonClicked)
    {
        yield return new WaitUntil(() => check==true);
        spellButton.GetComponent<spellButton>().changeKeySpell(key,position);
         buttonClicked.GetComponentInChildren<Text>().text=key;
         
    }
     void openSetButton()
    {
        panel.SetActive(false);
        panelSetButton.SetActive(true);
    }
     void backToGame()
    {
        panel.SetActive(false);
    }
    void openPreference(){
         panel.SetActive(false);
         panelPreference.SetActive(true);
    }
     void Quit()
    {
        SceneTransition.SwitchToScene("Menu");
        canvas.SetActive(false);
        gameObject.SetActive(false);
        
    }
      void backToPauseMenu()
    {
        panelSetButton.SetActive(false);
        panelPreference.SetActive(false);
        panel.SetActive(true);
    }
}
