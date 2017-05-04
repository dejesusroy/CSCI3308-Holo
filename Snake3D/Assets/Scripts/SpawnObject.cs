using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Designed using Gamad YouTube snake food spawn tutorials
// https://www.youtube.com/watch?v=kTvBRkPTvRY&list=PL47vwJBRNh1yn_29bPEg-xO9GOasPH2-g&index=6


public class SpawnObject : MonoBehaviour {

	public GameObject foodPre;
	public Vector3 center;
	public Vector3 size;
	public float timeSpawn;





	// Use this for initialization
	void Start () {
		Debug.Log("SpawnFood started");
		spawnFood ();
	}
	
	// Update is called once per frame
	void Update () {
	}


	public void spawnFood()
	{
		Vector3 posi = center + new Vector3 (Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
		Instantiate(foodPre,posi,Quaternion.identity);
	}

	void onDrawGizmosSelected()
	{
		Gizmos.color = new Color (1, 0, 0, 0.5f);
		Gizmos.DrawCube (transform.localPosition + center, size);
	}
}