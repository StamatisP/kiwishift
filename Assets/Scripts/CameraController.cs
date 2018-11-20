using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

	public GameObject player; //Public variable to store a reference to the player game object

	//private Vector3 offset; //Private variable to store the offset distance between the player and camera

	// Use this for initialization
	void Start ()
	{
		//Calculate and store the offset value by getting the distance between the player's position and camera's position.
		//offset = transform.position - player.transform.position;
	}

	// LateUpdate is called after Update each frame
	void LateUpdate ()
	{

		transform.position = new Vector3 (Mathf.Lerp (transform.position.x, player.transform.position.x, 0.75f), Mathf.Lerp (transform.position.y, player.transform.position.y, 0.75f), -0.01f);

		//if (player.transform.position.x > 5)
		// Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
		//transform.position = player.transform.position + offset;
	}
}