using System;
using UnityEngine;

    public class setTarget: MonoBehaviour
    {
       
	public static bool isPointer;
	public static Vector3 target;
	public GameObject targetPointer;
	protected bool check = true;
	void Start () 
	{
		targetPointer.SetActive(false);
	}

	public void paintTarget (float range) 
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit, range))
		{
			
				if(hit.transform.tag == "Terrain")
				{
                    targetPointer.SetActive(true);
					target = hit.point;
					targetPointer.transform.localRotation = Quaternion.FromToRotation(Vector3.forward, hit.normal);
					
					targetPointer.transform.position = hit.point;
              check=true;
			    }
		}
		else{
			check=false;
		}
	}
    }
