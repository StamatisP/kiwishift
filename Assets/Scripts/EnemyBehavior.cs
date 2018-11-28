using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{

	int currentHealth;
	int maxHealth;

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
	}

	public void Damage (int damage)
	{
		currentHealth -= damage;
		//gameObject.GetComponent<Animation>().Play("")
	}
}