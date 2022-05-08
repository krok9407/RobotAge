using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characteristic : MonoBehaviour
{

   public GameObject Canvas;
    public GameObject HealthBar;
    public GameObject Dno;
    public GameObject Energy;
    public GameObject Glass;
    public GameObject Box;
    public Animator animator;


    private RectTransform CanvasRT;
    private RectTransform HealthBarRT;
    private RectTransform DnoRT;
    private RectTransform EnergyRT;
    private RectTransform GlassRT;
    private RectTransform BoxRT;

    public float hp=50;
    private float width;
    private float x;
    private float y;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        RectTransform CanvasRT = Canvas.GetComponent<RectTransform>();
        RectTransform HealthBarRT = HealthBar.GetComponent<RectTransform>();
        RectTransform DnoRT = Dno.GetComponent<RectTransform>();
        RectTransform EnergyRT = Energy.GetComponent<RectTransform>();
        RectTransform GlassRT = Glass.GetComponent<RectTransform>();
        RectTransform BoxRT = Box.GetComponent<RectTransform>();
   
        HealthBarRT.sizeDelta= CanvasRT.sizeDelta;
        width = HealthBarRT.sizeDelta.x*0.08f;
        DnoRT.sizeDelta = new Vector2(width,width*2);
        EnergyRT.sizeDelta = DnoRT.sizeDelta;
        GlassRT.sizeDelta = DnoRT.sizeDelta;
        BoxRT.sizeDelta = DnoRT.sizeDelta; 
        x = HealthBarRT.sizeDelta.x*0.04f;
        y = HealthBarRT.sizeDelta.y*0.5f;
        DnoRT.anchoredPosition = new Vector2(x,y);
        EnergyRT.anchoredPosition = new Vector2(x-width/2,y-width);
        GlassRT.anchoredPosition = new Vector2(x,y);
        BoxRT.anchoredPosition = new Vector2(x,y);
    }

    //Сделать функцию изменения hp
  /*  void Update()
    {   
            var checkAnimation = animator.GetCurrentAnimatorStateInfo(0);
     if (checkAnimation.IsName("moveEnergy"))
     {
      
    }   

    }*/
}
