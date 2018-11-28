using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{

	public int damage = 20;

	private void OnTriggerEnter2D (Collider2D other)
	{
		if (other.isTrigger != true && other.CompareTag ("Enemy"))
		{
			other.SendMessageUpwards ("Damage", damage);
		}
	}
}