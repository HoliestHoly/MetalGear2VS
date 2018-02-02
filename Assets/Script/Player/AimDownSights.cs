using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimDownSights : MonoBehaviour {
	public Vector3 aimDownSight;
	public Vector3 hipFire;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown (1)) {
			//print (Mathf.Lerp (hipFire.y, aimDownSight.y, Time.deltaTime));
		//	transform.localPosition = Vector3.Slerp (transform.localPosition, aimDownSight, 10 * Time.deltaTime);
			//transform.localPosition = aimDownSight;
			StopCoroutine ("MoveGunIntoFrame");
			StopCoroutine ("MoveGunOutOfFrame");
			StartCoroutine ("MoveGunIntoFrame");
		}
		if (Input.GetMouseButtonUp (1)) 
		{
			StopCoroutine ("MoveGunIntoFrame");
			StopCoroutine ("MoveGunOutOfFrame");
			StartCoroutine ("MoveGunOutOfFrame");

		}
	}

	IEnumerator MoveGunIntoFrame()
	{
		while(Vector3.Distance (transform.localPosition, aimDownSight) >= 0.02f) {
			transform.localPosition = Vector3.Lerp (transform.localPosition, aimDownSight, 10 * Time.deltaTime);
				yield return null;
		}
		transform.localPosition = aimDownSight;
	}


	IEnumerator MoveGunOutOfFrame()
	{
		while(Vector3.Distance (transform.localPosition, hipFire) >= 0.02f) {
			transform.localPosition = Vector3.Lerp (transform.localPosition, hipFire, 10 * Time.deltaTime);
			yield return null;
		}
		transform.localPosition = hipFire;
	}
}
