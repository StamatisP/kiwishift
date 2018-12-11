using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
	public float speed;
	private bool movingRight = true;
	public Transform groundDetect;
	public int currentHealth;
	public int maxHealth;
	public Animator anim;

	// Use this for initialization
	void Start ()
	{
		currentHealth = maxHealth;
	}

	// Update is called once per frame
	void Update ()
	{
		if (currentHealth <= 0)
		{
			Destroy (gameObject);
		}
		transform.Translate(Vector2.right * speed * Time.deltaTime);

		RaycastHit2D groundInfo = Physics2D.Raycast(groundDetect.position, Vector2.down, 2f);
		if (groundInfo.collider == false) {
			if (movingRight == true) {
				transform.eulerAngles = new Vector3(0, -180, 0);
				movingRight = false;
			} else {
				transform.eulerAngles = new Vector3(0, 0, 0);
				movingRight = true;
			}
		}
	}

	public void Damage (int damage)
	{
		currentHealth -= damage;
		//gameObject.GetComponent<Animation>().Play("")
	}
}