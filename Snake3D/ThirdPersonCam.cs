using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Designed using Gamad YouTube snake cam tutorials

public class ThirdPersonCam : MonoBehaviour {

	public float CamSpeed = 1; // Increment speed
	public Transform target; //For rotation
	public Camera cam;

	
	// Update is called once per frame
	void Update () {
		Movement();
	}

	public void Movement(){
		Vector3 direction = (target.position - cam.transform.position).normalized;
		Quaternion lookRotate = Quaternion.LookRotation(direction);
		// We need to rotate the camera across x and z axis but not y
		lookRotate.x = transform.rotation.x;
		lookRotate.z = transform.rotation.z;
		transform.rotation = Quaternion.Slerp (transform.rotation,lookRotate,Time.deltaTime * 100);

		transform.position = Vector3.Slerp (transform.position, target.position, Time.deltaTime * CamSpeed);
	}
}
