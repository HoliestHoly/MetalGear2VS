using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForSound : MonoBehaviour 
{



	int layerMask = 8;
	void Update()
	{
		CheckSound (this.transform.position, 10);
	}

	void CheckSound(Vector3 center, float radius)
	{
		Collider[] soundInRadius = Physics.OverlapSphere (center, radius, layerMask);
		int i = 0;
		while (i < soundInRadius.Length) 
		{
			Debug.Log ("Sounds!");
			i++;
		}
	}

}