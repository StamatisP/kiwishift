using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
	//public PlayerPlatformerController playerPlatformerController;
	public int attackBounceJump;

	public int damage = 20;

	private void OnTriggerEnter2D (Collider2D other)
	{
		if (other.isTrigger = true && other.CompareTag ("Enemy"))
		{
			print("enemy damage " + damage);
			other.SendMessageUpwards ("Damage", damage);
			print("enemy new health: " + other.GetComponent<EnemyBehavior>().currentHealth);
			gameObject.SendMessageUpwards("AttackBounce", attackBounceJump);
		}
	}
}