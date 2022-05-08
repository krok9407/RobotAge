using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addForce : MonoBehaviour
{
    private Rigidbody rb;
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        rb.AddRelativeForce(0,2500f,0);
    }
 void OnCollisionEnter(Collision collision){
     Destroy(gameObject,0.5f);
 }
}
