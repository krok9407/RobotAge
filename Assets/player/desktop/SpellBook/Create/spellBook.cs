using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spellBook : MonoBehaviour
{

public List<PictureSpellMain> pictureSpellMain = new List<PictureSpellMain>();
public List<PictureSpellSpecialisation> pictureSpellSpecialisation = new List<PictureSpellSpecialisation>();
public List<PictureSpellProfession> pictureSpellProfession = new List<PictureSpellProfession>();

    public GameObject SpellBook;
    private RectTransform SpellBookRT;

    public float PercentSizeBook;
    public float PercentPositionBookX;
    public float PercentPositionBookY;

    public int rows;
    public int cols;
    public float marginPercent;

    public GameObject Cells;
    private RectTransform CellsRT;
    private GameObject newCells;

    
    public GameObject buttonMainSpellMenu;
    private RectTransform buttonMainSpellMenuRT;

    public GameObject buttonSpecializationMenu;
    private RectTransform buttonSpecializationMenuRT;
    
    public GameObject buttonProfessionMenu;
    private RectTransform buttonProfessionMenuRT;



    public GameObject mainPanel;
    private RectTransform mainPanelRT;

    public GameObject specializationPanel;
    private RectTransform specializationPanelRT;

    public GameObject professionPanel;
    private RectTransform professionPanelRT;

 
    public GameObject PanelButton;
    private RectTransform PanelButtonRT;
    
    public GameObject Canvas;
    private RectTransform CanvasRT;

    private bool flag;

    // Start is called before the first frame update
    void Start()
    {
         SpellBookRT = SpellBook.GetComponent<RectTransform>();
         CanvasRT = Canvas.GetComponent<RectTransform>();
         mainPanelRT = mainPanel.GetComponent<RectTransform>();
         specializationPanelRT = specializationPanel.GetComponent<RectTransform>();
         professionPanelRT = professionPanel.GetComponent<RectTransform>();
         
         PanelButtonRT = PanelButton.GetComponent<RectTransform>();
         CellsRT = Cells.GetComponent<RectTransform>();
         buttonMainSpellMenuRT = buttonMainSpellMenu.GetComponent<RectTransform>();
         buttonSpecializationMenuRT = buttonSpecializationMenu.GetComponent<RectTransform>();
         buttonProfessionMenuRT = buttonProfessionMenu.GetComponent<RectTransform>();

         
         SpellBookRT.sizeDelta= CanvasRT.sizeDelta;

         float heightPanel = CanvasRT.sizeDelta.y*PercentSizeBook/100;
         float widthPanel = heightPanel;
         float xPanel = CanvasRT.sizeDelta.x*PercentPositionBookX/100;
         float yPanel = CanvasRT.sizeDelta.y*PercentPositionBookY/100;
         
         mainPanelRT.sizeDelta = new Vector2(widthPanel,heightPanel);
         mainPanelRT.anchoredPosition = new Vector2(xPanel,yPanel);

         specializationPanelRT.sizeDelta = new Vector2(widthPanel,heightPanel);
         specializationPanelRT.anchoredPosition = new Vector2(xPanel,yPanel);
       
         professionPanelRT.sizeDelta = new Vector2(widthPanel,heightPanel);
         professionPanelRT.anchoredPosition = new Vector2(xPanel,yPanel);
       


         float heightCells = (heightPanel-heightPanel*(marginPercent/100)*(rows+1))/rows;

         float widthCells = (widthPanel-widthPanel*(marginPercent/100)*(cols+1))/cols;

         CellsRT.sizeDelta = new Vector2(widthCells,heightCells);
         
         float heightMenuButton = (heightPanel*0.6f-heightPanel*0.01f*4)/3;
         float widthMenuButton = heightMenuButton;
         
         PanelButtonRT.sizeDelta = new Vector2(widthMenuButton+heightPanel*0.01f*2,heightMenuButton*3+heightPanel*0.01f*4);

         buttonMainSpellMenuRT.sizeDelta = new Vector2(widthMenuButton,heightMenuButton);
         buttonSpecializationMenuRT.sizeDelta = new Vector2(widthMenuButton,heightMenuButton);
         buttonProfessionMenuRT.sizeDelta = new Vector2(widthMenuButton,heightMenuButton);
        
         float xMenuButton = widthPanel+xPanel+widthPanel*0.01f;
         float yMenuButton = yPanel-heightPanel*0.01f;
         PanelButtonRT.anchoredPosition = new Vector2(xMenuButton-widthPanel*0.01f,yMenuButton+heightPanel*0.01f);
      buttonMainSpellMenuRT.anchoredPosition = new Vector2(xMenuButton,yMenuButton);
      yMenuButton-=(heightMenuButton+heightPanel*0.01f);
      buttonSpecializationMenuRT.anchoredPosition = new Vector2(xMenuButton,yMenuButton);
      yMenuButton-=(heightMenuButton+heightPanel*0.01f);
      buttonProfessionMenuRT.anchoredPosition = new Vector2(xMenuButton,yMenuButton);
     
       for(int i=0;i<rows;i++)
            {
                for(int j=0;j<cols;j++)
                    {
                       newCells = Instantiate(Cells, transform.position = new Vector3(0+(widthCells*j)+widthPanel*(marginPercent/100)*(j+1),0-(heightCells*i)-heightPanel*(marginPercent/100)*(i+1)), Quaternion.identity) as GameObject;
                       newCells.transform.SetParent(mainPanel.transform, false);
                       newCells.name="main"+(i*rows+j+1).ToString();
                       var pic = pictureSpellMain[i*rows+j];
                       var newCellsImage = newCells.GetComponent<Image>();
                       newCellsImage.sprite = pic.image;
                    }
                }
                for(int i=0;i<rows;i++)
            {
                for(int j=0;j<cols;j++)
                    {
                       newCells = Instantiate(Cells, transform.position = new Vector3(0+(widthCells*j)+widthPanel*(marginPercent/100)*(j+1),0-(heightCells*i)-heightPanel*(marginPercent/100)*(i+1)), Quaternion.identity) as GameObject;
                       newCells.transform.SetParent(specializationPanel.transform, false);
                       newCells.name="specialization"+(i*rows+j+1).ToString();
                       var pic = pictureSpellProfession[i*rows+j];
                       var newCellsImage = newCells.GetComponent<Image>();
                       newCellsImage.sprite = pic.image;
                   
                    }
                }
                for(int i=0;i<rows;i++)
            {
                for(int j=0;j<cols;j++)
                    {
                       newCells = Instantiate(Cells, transform.position = new Vector3(0+(widthCells*j)+widthPanel*(marginPercent/100)*(j+1),0-(heightCells*i)-heightPanel*(marginPercent/100)*(i+1)), Quaternion.identity) as GameObject;
                       newCells.transform.SetParent(professionPanel.transform, false);
                       newCells.name="profession"+(i*rows+j+1).ToString();
                       var pic = pictureSpellSpecialisation[i*rows+j];
                       var newCellsImage = newCells.GetComponent<Image>();
                       newCellsImage.sprite = pic.image;
                  
                    }
                }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.F))
        {
       if(SpellBook.activeSelf){
            SpellBook.SetActive(false);
            mainPanel.SetActive(false);
            specializationPanel.SetActive(false);
            professionPanel.SetActive(false);
            }
            else
            {
                SpellBook.SetActive(true);
                mainPanel.SetActive(true);
                specializationPanel.SetActive(false);
                professionPanel.SetActive(false); 
            }
    }
}
}

[Serializable]
public class PictureSpellMain
{
    public Sprite image;
}

[Serializable]
public class PictureSpellProfession
{
    public Sprite image;
}

[Serializable]
public class PictureSpellSpecialisation
{
    public Sprite image;
}
