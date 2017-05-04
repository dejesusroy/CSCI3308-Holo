using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Designed using Gamad YouTube snake cam tutorials

public class ThirdPersonCam : MonoBehaviour {

	public float CamSpeed = 1; // Increment speed
	public Transform Target; //For rotation
	public Camera cam;

	
	// Update is called once per frame
	void LateUpdate () {
		Movement ();
	}

	public void Movement(){
		Vector3 direction = (Target.position - cam.transform.position).normalized;
		Quaternion lookrotation = Quaternion.LookRotation(direction);


		// We need to rotate the camera across x and y axis but not z
		lookrotation.x = transform.rotation.x;
		lookrotation.z = transform.rotation.z;


		transform.rotation = Quaternion.Slerp(transform.rotation, lookrotation, Time.deltaTime * 100);
		transform.position = Vector3.Slerp (transform.position, Target.position, Time.deltaTime * CamSpeed);
	}
}
