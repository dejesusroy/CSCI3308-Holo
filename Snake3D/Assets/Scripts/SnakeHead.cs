using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//

public class SnakeHead : MonoBehaviour {
	
	public SnakeMove movement;
	public SpawnObject SO;

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.CompareTag("Food"))
		{
			movement.addBody ();
			Destroy(col.gameObject);
			SO.spawnFood();
		}
		else
		{
			if (col.transform != movement.bodyParts [1] && !movement.isAlive)
			{
				if(Time.time - movement.timeElapsed > 5)
				{
				movement.Die();
				}
			}
		}
	}
}