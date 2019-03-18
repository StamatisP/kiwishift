using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

	public GameObject bullet;
	[SerializeField]
	private GameObject firePositionRight;
	[SerializeField]
	private GameObject firePositionLeft;
	private GameObject firePosition;
	private float timeStamp;

	private PlayerPlatformerController playerPlatformerController;
	// Use this for initialization
	void Start ()
	{
		playerPlatformerController = GetComponent<PlayerPlatformerController> ();
	}

	// Update is called once per frame
	void Update ()
	{

		if (playerPlatformerController.PlayerDirection == Direction.RIGHT)
		{
			firePosition = firePositionRight;
		}
		else if (playerPlatformerController.PlayerDirection == Direction.LEFT)
		{
			firePosition = firePositionLeft;
		}
		else
		{
			Debug.LogError ("tf????");
		}

		if (Input.GetButtonDown ("Fire1") && timeStamp <= Time.time)
		{
			timeStamp = Time.time + (float) 0.5;
			var tBullet = Instantiate (bullet, firePosition.transform.position, bullet.transform.rotation) as GameObject;
			tBullet.GetComponent<Bullet> ().bulletDirection = playerPlatformerController.PlayerDirection;
		}
	}
}