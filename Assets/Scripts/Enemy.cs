using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public int health = 10;
	// Use this for initialization
	public void Damage(int dmg) {
		health -= dmg;
		if(health <= 0) {
			Destroy(gameObject);
		}
	}
}
