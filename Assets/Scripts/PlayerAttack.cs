using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

	bool attacking = false;

	float attackTimer = 0;
	float attackCooldown = 0.3f;

	public Collider2D attackTrigger;

	Animator anim;

	private void Awake ()
	{
		anim = gameObject.GetComponent<Animator> ();
		attackTrigger.enabled = false;
	}

	private void Update ()
	{
		if (Input.GetButtonDown ("Attack") && !attacking)
		{
			attacking = true;
			attackTimer = attackCooldown;
			print ("attack");

			attackTrigger.enabled = true;
		}

		if (attacking)
		{
			if (attackTimer > 0)
			{
				attackTimer -= Time.deltaTime;
			}
			else
			{
				attacking = false;
				attackTrigger.enabled = false;
			}
		}

		//anim.SetBool("Attacking", attacking);
	}
}