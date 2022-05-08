using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBtn : MonoBehaviour
{
    public Animator anim;

    public void moveBtn()
    {
        //gameObject.SetActive(true);
        anim.SetInteger("Anim",1);
    }

    public void backBtn()
    {
        anim.SetInteger("Anim",0);
        //gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        //gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
