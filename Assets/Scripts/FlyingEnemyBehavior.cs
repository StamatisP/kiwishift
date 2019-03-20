/** Author: Taylor Ereio
 * File: BeeController.cs
 * Date: 4/9/2015
 * Description: Controls the Bee Maverick AI
 * */

using System.Collections;
using UnityEngine;

public class FlyingEnemyBehavior : MonoBehaviour
{

	public float alertDistance = 5f;
	public float health = 5f;
	public float attackMinTime = 3f; // Attack Time Minimums and Maximums
	public float attackMaxTime = 4f;
	public GameObject beam; // refrences it's beam object
	private Direction direction;

	private float attackTime = 0f; //	current attack time
	private GameObject player; // handle on players MegaMan
	//private Animator anim;
	private bool enemyActive;
	private bool firstDash = false; // first dash handle for the inital jump towards player
	//private float explosionTime = 0f;
	//private Animator explosionAnim = null;
	private float yDifference = 0f;

	public float speed = 1.25f; // horizontal speed
	public float vSpeed = 1.5f; // vertical speed
	public int move = 0; // horizontal direction
	// Use this for initialization
	void Start ()
	{
		// getting handle on player
		player = GameObject.FindGameObjectWithTag ("Player");

		// Getting a handle on animators
		//anim = GetComponent<Animator> ();
		attackTime = Time.time + Random.Range (attackMinTime, attackMaxTime);
	}

	void FixedUpdate ()
	{
		if (enemyActive)
		{
			Attack ();
			Movement ();
		}
	}
	// Update is called once per frame
	void Update ()
	{
		try
		{ // in try in case it cannot find the player object
			if (!enemyActive)
			{
				if (Vector2.Distance ((Vector2) transform.position, player.transform.position) < 5f)
				{
					enemyActive = true;
					speed = 1.25f;
					//anim.SetBool("Alert", true);
				}
			}

			if (enemyActive && !firstDash)
			{
				// checks for swift move towards player
				if (Vector2.Distance ((Vector2) transform.position, player.transform.position) > 3f)
				{
					speed = 4f; //if not within 3f, keep dashing at speed = 4f;
				}
				else
				{
					firstDash = true;
				}
			}
			else
			{
				speed = 1.25f;
			}

			if (health <= 0)
			{
				//anim.SetTrigger("Death");			//sets animation death trigger
				GetComponent<Rigidbody2D> ().isKinematic = false; //lets the bee fall to the ground
				enemyActive = false; //sets the enemy inactive for movement
				//explosionAnim.SetTrigger("explode");//allows explosion on the GO animator
				//DeathDriver();						//calls the explosion driver
				Destroy (this.gameObject, 0.75f); //destroys the object when done
			}
		}
		catch
		{
			player = GameObject.FindGameObjectWithTag ("Player");
		}
	}

	/*void DeathDriver ()
	{
		// drives the explosions
		if (Time.time >= explosionTime)
		{
			// sets new explosion position
			float randX = Random.Range (-0.25f, 0.25f);
			float randY = Random.Range (-0.25f, 0.25f);

			// after the explosion animation changes, it will change the next anim's position around the object
			explosionTime = Time.time + 0.9f;
		}
	}*/

	void Movement ()
	{

		// Checks if it should move left or right towards player
		if (transform.position.x - player.transform.position.x > 0.1f)
		{
			move = -1;
			transform.eulerAngles = new Vector3 (0, -180, 0);
			direction = Direction.LEFT;
		}
		else if (transform.position.x - player.transform.position.x == 0)
		{
			speed = 0;
		}
		else if (transform.position.x - player.transform.position.x < -0.1f)
		{
			move = 1;
			transform.eulerAngles = new Vector3 (0, 0, 0);
			direction = Direction.RIGHT;
		}

		// Checks if enemy is too high for player to hit - moves up and down
		yDifference = transform.position.y - player.transform.position.y;
		if (yDifference > 1.0f)
		{
			vSpeed = -0.5f;
		}
		else if (yDifference < 0.5f)
		{
			vSpeed = 0.5f;
		}
		else
		{
			vSpeed = 0f;
		}

		GetComponent<Rigidbody2D> ().velocity = new Vector2 (move * speed, vSpeed);
	}

	void Attack ()
	{
		if (Time.time >= attackTime)
		{
			attackTime = Time.time + Random.Range (attackMinTime, attackMaxTime);
			//anim.SetTrigger ("Attack");
			//Vector3 beamRotation = new Vector3 (transform.rotation.x, transform.rotation.y, 90);
			var eBullet = Instantiate (beam, new Vector3 (transform.position.x, transform.position.y - 0.04f, 0f), Quaternion.identity) as GameObject;
			print (eBullet);
			eBullet.GetComponent<EnemyBullet> ().bulletDirection = direction;
			print ("attack");
		}
	}

	public void Damage (int dmg)
	{
		health -= dmg;
		if (health <= 0)
		{
			Destroy (gameObject);
		}
	}
}