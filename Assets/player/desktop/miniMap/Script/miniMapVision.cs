using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class miniMapVision : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
   public GameObject Player;
   public Camera cam;
   public Slider scroll;
   private float distance;
   private float speedCam;
 public Image board;
 public bool onPlace;
public Animator animator;
  void Start() {
   animator = board.GetComponent<Animator>();
}
   public void OnPointerEnter(PointerEventData eventData)
    {
        animator.SetTrigger("OnEnter");
        onPlace=true;
       }

   public void OnPointerExit(PointerEventData eventData)
    {
        animator.SetTrigger("Normal");
       onPlace=false;
        }

    void Update()
    {
        distance = scroll.value;
     //   float y;
        cam.orthographicSize = distance;
       // Player.transform.rotation.ToAngleAxis(out y, out v);
       // cam.transform.position = Player.transform.position +Vector3.up*distance;
      //  cam.transform.rotation = Quaternion.Euler(new Vector3(90, 0, -y));
  
        if(onPlace){
            float mw = Input.GetAxis("Mouse ScrollWheel");
        if (mw > 0.1 && scroll.value<96)
        {
        cam.orthographicSize+=5;
        scroll.value+=5;
        }
        if (mw < -0.1 && scroll.value>54)
        {
        cam.orthographicSize-=5;
        scroll.value-=5;
         }
        }
    }
}
