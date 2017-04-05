#pragma strict
var force = 0.0;

function Start () {
    GetComponent.<Rigidbody>().AddForce(Vector3.right * force);
    GetComponent.<Rigidbody>().AddForce(Vector3.up * Random.Range(-300,300));
}

function Update () {
	
}

function OnCollisionEnter (other : Collision) {
    if (other.gameObject.tag == "Wall") {
        Application.LoadLevel(Application.loadedLevel);
    }
}