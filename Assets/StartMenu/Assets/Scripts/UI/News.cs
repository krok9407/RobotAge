using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class News : MonoBehaviour
{
    [Header("Set options")]
    public Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void moveUp(){
        animator.SetTrigger("Up");
    }
    public void moveDown(){
        animator.SetTrigger("Down");
    }
}
