using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerFunctions : MonoBehaviour
{
	public int health = 35;
	//private PlayerPlatformerController playerController;
	private Rigidbody2D rb2d;
	private Vector3 spawnPos;
	//bool isShifted; // if false, then in normal world. if true, then other world

	// Use this for initialization
	void Start ()
	{
		//playerController = GetComponent<PlayerPlatformerController>();
		//isShifted = false;
		spawnPos = transform.position;
		Application.targetFrameRate = 60;
		//playerController = GetComponent<PlayerPlatformerController> ();
		rb2d = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButtonDown ("PhaseShift"))
		{
			//isShifted = !isShifted;
			GameManager.Instance.PhaseShift ();
			//print ("phasing shift " + GameManager.Instance.isShifted);
		}
		if (Input.GetKeyDown (KeyCode.Semicolon))
		{
			GameManager.Instance.LevelLoad ();
		}

		if (Input.GetKeyDown (KeyCode.Escape))
		{
			Application.Quit ();
		}

	}

	void OnTriggerEnter2D (Collider2D col)
	{
		//print("TRIGGER ENTER");
		if (col.tag == "Spikes")
		{
			//SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			transform.position = spawnPos;
		}
		if (col.tag == "Portal" && col.tag != "Bullet")
		{
			GameManager.Instance.LevelLoad ();
		}
		if (col.tag == "Enemy" || col.tag == "FlyingEnemy")
		{
			print ("entering fuck");
			var opposite = -rb2d.velocity;
			print (opposite);
			rb2d.AddForce (opposite * Time.deltaTime);
			Damage (5);
			//transform.position = spawnPos;
		}

	}

	public void Damage (int dmg)
	{
		health -= dmg;
		print ("kiwi damaged");
		if (health <= 0)
		{
			transform.position = spawnPos;
			health = 35;
		}
	}
}