using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{

	public float speed;
	public Transform[] moveSpots;
	private int nextSpot;

	void Start ()
	{
		nextSpot = Random.Range (0, moveSpots.Length);
	}

	void Update ()
	{
		transform.position = Vector2.MoveTowards (transform.position, moveSpots[nextSpot].position, speed * Time.deltaTime);

		if (Vector2.Distance (transform.position, moveSpots[nextSpot].position) < 0.2f)
		{
			if (nextSpot == 1)
			{
				// this means it hit the second spot, should move left now
				nextSpot = 0;
				transform.eulerAngles = new Vector3 (0, -180, 0);
			}
			else if (nextSpot == 0)
			{
				// hit first spot, moves right now
				nextSpot = 1;
				transform.eulerAngles = new Vector3 (0, 0, 0);
			}
		}
		// to do: flip the sprite once it reaches destination, to do this implement a way for it not to be a random spot, and choose the opposite spot
	}
}