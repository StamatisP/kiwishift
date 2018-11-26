using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	[SerializeField]
	private float speed;
	[SerializeField]
	float gravity;

	private Rigidbody2D rb2D;

	// Use this for initialization
	void Start () {
		rb2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		float moveHorizontal = Input.GetAxis("Horizontal");
		Vector2 movement = new Vector2(moveHorizontal, gravity);

		rb2D.velocity = movement * speed;

	}
}
