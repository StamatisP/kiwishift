using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

	public Direction bulletDirection = Direction.RIGHT;
	public float speed = 4.5f;
	public int damage = 5;
	float distanceFromParent;
	[SerializeField]
	private GameObject parent;
	private Rigidbody2D rb2d;

	//private Transform _transform;
	// Use this for initialization
	void Start ()
	{
		print ("bullet spawn enemy");
		//_transform = transform;
		Destroy (gameObject, 2f);
		rb2d = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update ()
	{
		MoveBullet ();
		//distanceFromParent = Vector3.Distance (transform.parent.transform.position, transform.position);
		//print (distanceFromParent);
		/*if (distanceFromParent > 12f)
		{
			Destroy (gameObject);
		}*/
	}

	void MoveBullet ()
	{
		int moveDirection = bulletDirection == Direction.LEFT ? -1 : 1;

		//float translate = moveDirection * speed * Time.deltaTime;
		//_transform.Translate (translate, 0, 0);
		rb2d.velocity = new Vector2 (rb2d.velocity.x, -speed);
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "Player")
		{
			col.gameObject.GetComponent<PlayerFunctions> ().Damage (damage);
			Destroy (gameObject);
		}
		else if (col.tag == "FlyingEnemy" || col.tag == "Enemy")
		{
			print ("fuck");
		}
	}
}