#pragma strict
var speed = 5.0;

function Start () {
	
}

function Update () {
    if (Input.GetKey("up") && transform.position.y < 5.1) {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
    if (Input.GetKey("down") && transform.position.y > -3.2) {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}
