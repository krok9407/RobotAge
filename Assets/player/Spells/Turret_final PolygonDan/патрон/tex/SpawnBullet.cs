using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    
    public GameObject spawnPoint;
    public GameObject bullet;
    public GameObject EffecShot;
    public float delay=5f;

    // Update is called once per frame
   private void Start() {
        var coroutine = Fire(delay);
        StartCoroutine(coroutine);
    }
private IEnumerator Fire(float waitTime)
    {
        while(true){
            yield return new WaitForSeconds(waitTime);
            bool check = GetComponent<searchTarget>().readyFire;
            if(check){
            Instantiate(EffecShot,spawnPoint.transform.position,spawnPoint.transform.rotation);
            Instantiate(bullet,spawnPoint.transform.position,spawnPoint.transform.rotation);
            }
        }
    }
}
