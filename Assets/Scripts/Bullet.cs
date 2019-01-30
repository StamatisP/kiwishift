using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

	public Direction bulletDirection = Direction.RIGHT;
	public float speed = 5.0f;
	public int damage = 5;
	float distanceFromParent;
	[SerializeField]
	private GameObject parent;

	private Transform _transform;
	// Use this for initialization
	void Start ()
	{
		_transform = transform;
		Destroy (gameObject, 4f);
	}

	// Update is called once per frame
	void Update ()
	{
		MoveBullet ();
		//distanceFromParent = Vector3.Distance (transform.parent.transform.position, transform.position);
		/*if (distanceFromParent > 12f)
		{
			Destroy (gameObject);
		}*/
	}

	void MoveBullet ()
	{
		int moveDirection = bulletDirection == Direction.LEFT ? -1 : 1;

		float translate = moveDirection * speed * Time.deltaTime;
		_transform.Translate (translate, 0, 0);
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "Enemy")
		{
			col.gameObject.GetComponent<Enemy> ().Damage (damage);
			Destroy (gameObject);
		}
		else if (col.tag == "FlyingEnemy")
		{
			col.gameObject.GetComponent<FlyingEnemyBehavior> ().Damage (damage);
			Destroy (gameObject);
		}
		else
		{
			Destroy (gameObject);
		}
	}
}