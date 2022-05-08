using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class searchTarget : MonoBehaviour
{   
    float lastAngleZ=0;
    GameObject[] targets;
    GameObject target;
    float distance = Mathf.Infinity;
    public float rotationSpeed=2.0f;
    public bool readyFire=false;
    

    // Update is called once per frame
    void Update()
    {
         targets = GameObject.FindGameObjectsWithTag("test");
        
         foreach (GameObject go in targets)
        {
             float curDistance=Vector3.Distance(go.transform.position, transform.position) ;
            if (curDistance < distance)
            {
                target = go;
                distance = curDistance;
            }
        }

        float speed = rotationSpeed * Time.deltaTime ;
            Vector3 targetDirection = target.transform.position - transform.position;          // Поворачиваем вектор вперед в направлении цели на один шаг
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDirection, speed, 0.0F);
        transform.rotation = Quaternion.LookRotation(newDir); 
       if(targetDirection.z<0f){
        if((newDir.z>(lastAngleZ+lastAngleZ*0.1f) && newDir.z<(lastAngleZ-lastAngleZ*0.1f)))
      {
         readyFire=true;
      }
      else{
          readyFire=false;
      }
       }
       else{
         if((newDir.z<(lastAngleZ+lastAngleZ*0.1f) && newDir.z>(lastAngleZ-lastAngleZ*0.1f)))
      {
            readyFire=true;
      }
      else{
          readyFire=false;
      }
       }
        
       
       lastAngleZ = newDir.z;
       // if((transform.rotation.z-newDir.z)>-1f && (transform.rotation.z-newDir.z)<1f){
        //    Debug.Log("Попал");
       // }
    }
}
