using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForSound : MonoBehaviour 
{

   

    

    void Update()
	{
		CheckSound (this.transform.position, 20);
	}

    void CheckSound(Vector3 center, float radius)
	{
        int layerId = 8;
        int layerMask = 1 << layerId;
        Collider[] soundInRadius = Physics.OverlapSphere (center, radius, layerMask);
		int i = 0;
		while (i < soundInRadius.Length) 
		{
			Debug.Log ("Sounds!");
			i++;
		}
	}


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
     //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
     Gizmos.DrawWireSphere(this.transform.position, 20);
    }



}