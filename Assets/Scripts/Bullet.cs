using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public Direction bulletDirection = Direction.RIGHT;
	public float speed = 5.0f;

	private Transform _transform;
	// Use this for initialization
	void Start () {
		_transform = transform;
	}
	
	// Update is called once per frame
	void Update () {
		MoveBullet();
	}

	void MoveBullet() {
		int moveDirection = bulletDirection == Direction.LEFT ? -1 : 1;

		float translate = moveDirection * speed * Time.deltaTime;
		_transform.Translate(translate, 0, 0);
	}
}
