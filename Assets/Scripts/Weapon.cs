using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public GameObject bullet;
	
	private PlayerPlatformerController playerPlatformerController;
	// Use this for initialization
	void Start () {
		playerPlatformerController = GetComponent<PlayerPlatformerController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			var tBullet = Instantiate(bullet, gameObject.transform.position, bullet.transform.rotation) as GameObject;
			tBullet.GetComponent<Bullet>().bulletDirection = playerPlatformerController.PlayerDirection;
		}
	}
}
