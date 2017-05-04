using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// Applied concepts from Gamad tutorials on YouTube
//https://www.youtube.com/channel/UCqFFZvgC7JUL6esOrL8LyWg

// Also looked up information through docs.unity3d.com/SCirptReference

public class SnakeMove : MonoBehaviour {

	public List<Transform> bodyParts = new List<Transform>();
	// Distance to follow
	public float minDistance = 0.25f;
	// Speed for movements
	public float speed = 1;
	// Rotational movement speed
	public float rotateSpeed = 50;
	// Will be the green snake
	public GameObject bodyPreFab;
	// Time Alive
	public float timeElapsed;
	// Will be the dead screen canvas
	public GameObject DeadScreen;
	// Begin size of snake, will be 1
	public int beginsize;
	// Current score on the canvas
	public Text currentScore;
	// For final score
	public Text scoreText;
	// Will start/stop game
	public bool isAlive;
	// distance snake parts will follow
	private float dist;

	private Transform currentBody;
	private Transform previousBody;





	// Use this for initialization
	void Start ()
	{
		StartLevel();
	}

	public void StartLevel()
	{
		// Saving time alive
		timeElapsed = Time.time;
		// Begin by setting dead screen off when playing
		DeadScreen.SetActive (false);
		// Activate current score once game begins
		currentScore.gameObject.SetActive (true);

		//Reset snake
		for (int i = (bodyParts.Count - 1); i > 1; i--) {
			Destroy (bodyParts [i].gameObject);
			bodyParts.Remove (bodyParts [i]);
		}

		// Initialize snake head position
		bodyParts[0].position = new Vector3 (0, 0.5f, 0);
		bodyParts [0].rotation = Quaternion.identity;


		currentScore.gameObject.SetActive (true);
		currentScore.text = "Score: 0";
		isAlive = true;

		// Initialize snake size
		for (int i = 0; i < beginsize; i++) {
			addBody ();
		}

		bodyParts [0].position = new Vector3 (2, 0.5f, 0);
	}


	// Update is called once per frame
	void Update ()
	{

		if (isAlive)
			move();
		if (Input.GetKey(KeyCode.R))
			addBody ();
	}




	// Will add a body part
	public void addBody()
	{
		Transform newPart = (Instantiate(bodyPreFab, bodyParts[bodyParts.Count - 1].position,bodyParts[bodyParts.Count - 1].rotation) as GameObject).transform;
		newPart.SetParent(transform);
		bodyParts.Add(newPart);
		scoreText.text = "Current Snake length: " + (bodyParts.Count - beginsize).ToString();
	}
		

	// Snake movement
	public void move()
	{
		float currentSpeed = speed;
		if (Input.GetKey (KeyCode.W))
		{
			currentSpeed *= 2;
		}

		// NEED BETTER EXPLANATION!!!
		bodyParts[0].Translate(bodyParts[0].forward * currentSpeed * Time.smoothDeltaTime, Space.World);

		if (Input.GetAxis ("Horizontal") != 0)
		{
			bodyParts [0].Rotate (Vector3.up * rotateSpeed * Time.deltaTime * Input.GetAxis ("Horizontal"));
		}

		for(int i = 0; i < bodyParts.Count; i++)
		{
			currentBody = bodyParts[i];
			previousBody = bodyParts [i - 1];
			dist = Vector3.Distance (previousBody.position,currentBody.position);

			Vector3 newpos = previousBody.position;
			newpos.y = bodyParts[0].position.y;
			float T = Time.deltaTime * dist / minDistance * currentSpeed;
			if (T > 0.5f)
			{
				T = 0.5f;
			}
			currentBody.position = Vector3.Slerp (currentBody.position, newpos, T);
			currentBody.rotation = Quaternion.Slerp (currentBody.rotation, previousBody.rotation, T);
		}

	}

	public void Die()
	{
		isAlive = false;
		scoreText.text = "Final Snake length: " + (bodyParts.Count - beginsize).ToString ();
		currentScore.gameObject.SetActive(false);
		DeadScreen.SetActive (true);
	}

}