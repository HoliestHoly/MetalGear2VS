using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeSound : MonoBehaviour {

	private float lifeTimer;
	void Start () {
		lifeTimer = 4f;
	}
	

	void Update () {
		
		Destroy (this.gameObject, lifeTimer);

	}
}
