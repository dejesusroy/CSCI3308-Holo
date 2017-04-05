using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleAI : MonoBehaviour {
    Transform ball;
    public float speed = 10.0f;

	// Use this for initialization
	void Start () {
  
	}
	
	// Update is called once per frame
	void Update () {
        ball = GameObject.FindGameObjectWithTag("ball").transform;
        float yBallPos = ball.transform.position.y;
        float step = speed * Time.deltaTime;
        Vector3 v = ball.transform.position;
        v.y = yBallPos;
        v.x = transform.position.x;

        transform.position = Vector3.MoveTowards(transform.position, v, 5*step);
    }
}
