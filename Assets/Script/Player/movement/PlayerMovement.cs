using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private InputManager inputManager;
	[SerializeField]
	 private GameObject _PlayerSound;
	private float movementSpeed = 5;
	private float soundSpawnTimer = 1f;
	private bool moving;
	void Start(){
		//check if the inputmanager is present. If it's not, add it.
		//I was too lazy to add it in the unity editor, and this looks pretty nice
		//copy paste from camerarotation
		if (!(inputManager = this.GetComponent<InputManager>()))
		{
			inputManager = this.gameObject.AddComponent<InputManager>();
		}
	}

	void Update () {
		

		if (Input.GetKey (KeyCode.LeftShift)) {
			
			movementSpeed = 3;
		} else if (Input.GetKey (KeyCode.LeftControl) || Input.GetMouseButton (1)) {
			movementSpeed = 1;
		} else {
				movementSpeed = 5;

			if (Time.time > soundSpawnTimer && moving) {
				soundSpawnTimer = Time.time + 1;
				Instantiate (_PlayerSound, transform.position, transform.rotation);
			}

			}
			



		moving = false;
	
		Vector3 movement = new Vector3();
		if (inputManager.Up())
		{
			
			movement += this.transform.forward;
			moving = true;
		}
		if (inputManager.Down())
		{
			movement -= this.transform.forward;
			moving = true;
		}
		if (inputManager.Right())
		{
			movement += this.transform.right;
			moving = true;
		}
		if (inputManager.Left())
		{
			movement -= this.transform.right;
			moving = true;
		}
		movement.Normalize();
		this.transform.position += (movement * Time.deltaTime * movementSpeed);
	}
}
