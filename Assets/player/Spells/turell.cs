using System.Collections;
using UnityEngine;

public class turell : setTarget
{
    public static turell trl;
    public GameObject prefabTurrel;
    public float delay = 3f;
    public float range = 100f;
    public float timeLife=10f;
    public GameObject cam;
    private GameObject newTurell;
    private void Awake() {
        trl=this;
    }
       void Update()
    {
       if(Input.GetMouseButtonDown(0))
			{  
                var  standTurelCoroutine = standTurel(delay/10f);
                StartCoroutine(standTurelCoroutine);
            } 
    }
    private IEnumerator standTurel(float waitTime) {
        paintTarget(range);
        yield return new WaitForSeconds(waitTime);
       if(check){
       newTurell = Instantiate(prefabTurrel,targetPointer.transform.position,targetPointer.transform.localRotation);
       newTurell.transform.Rotate(90f, 0,0,Space.Self);    
       targetPointer.SetActive(false);
       Destroy(newTurell, timeLife);
       trl.enabled = false;
       }
    }
}
