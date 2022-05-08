using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class MoveToDetals : MonoBehaviour
{
    [SerializeField]
    private Transform startMarker;
    private Transform endMarker;
    public float speed = 1.0F;
    private float startTime;
    private float journeyLength;
    private Vector3 checkFinished = new Vector3(0f,0f,0f);

    public void MoveToNewPosition(Transform target){
        startMarker = transform;
        endMarker = target;
        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
        StartCoroutine(moveCamera());
       }
   IEnumerator moveCamera(){
        float distCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fractionOfJourney);
        transform.rotation = Quaternion.Lerp(startMarker.rotation, endMarker.rotation, fractionOfJourney);
        yield return new WaitForSeconds(.0001f);
        if(checkFinished == (startMarker.position-endMarker.position) && Mathf.Abs(Quaternion.Dot(startMarker.rotation,endMarker.rotation))>0.9999f){
           yield return null; 
        }else{
        StartCoroutine(moveCamera());
        }
   }
}