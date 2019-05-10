using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class PlayerFunctions : MonoBehaviour
{
	public int health = 40;
	private int maxHealth = 40;
	//private PlayerPlatformerController playerController;
	private Rigidbody2D rb2d;
	private Vector3 spawnPos;
	private Animator animator;
	[SerializeField]
	private PostProcessProfile DeathProfile;
	[SerializeField]
	private PostProcessProfile NormalProfile;
	public bool isDead;
	private GameObject deathNotif;

	public bool isPaused = false;
	private GameObject pauseGui;
	//private SpriteRenderer material;
	//bool isShifted; // if false, then in normal world. if true, then other world

	// Use this for initialization
	void Start()
	{
		//playerController = GetComponent<PlayerPlatformerController>();
		//isShifted = false;
		spawnPos = transform.position;
		Application.targetFrameRate = 60;
		animator = GetComponent<Animator>();
		//playerController = GetComponent<PlayerPlatformerController> ();
		rb2d = GetComponent<Rigidbody2D>();
		isDead = false;
		deathNotif = GameObject.FindWithTag("DeathNotif");
		if (deathNotif != null)
		{
			Spawn();
		}
		else
		{
			print("deathnotif is null?");
		}

		pauseGui = GameObject.FindWithTag("PauseGUI");
		pauseGui.SetActive(false);

		//material = GetComponent<SpriteRenderer> ();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetButtonDown("PhaseShift"))
		{
			if (isDead)
			{
				Spawn();
				return;
			}
			//isShifted = !isShifted;
			GameManager.Instance.PhaseShift();
			SoundManager.instance.PlaySound("PhaseShift");
			//print ("phasing shift " + GameManager.Instance.isShifted);
		}
		if (Input.GetKeyDown(KeyCode.Semicolon))
		{
			GameManager.Instance.LevelLoad();
		}
		if (Input.GetKeyDown(KeyCode.K))
		{
			PlayerDeath();
		}

		if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex > 0)
		{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				print("escapee");
				if (isPaused)
				{
					print("unpausing");
					print(pauseGui.name);
					pauseGui.SetActive(false);
					gameObject.GetComponent<PlayerPlatformerController>().enabled = true;
					isPaused = false;
					Time.timeScale = 1f;
				}
				else
				{
					print("pausing");
					pauseGui.SetActive(true);
					gameObject.GetComponent<PlayerPlatformerController>().enabled = false;
					isPaused = true;
					Time.timeScale = 0f;
				}
			}
		}

		//material.color = new Color (255, 255, 255, health * (float) 7.28);
		//print (material.color);
	}

	public void Continue()
	{
		isPaused = false;
		pauseGui.SetActive(false);
		Time.timeScale = 1f;
		gameObject.GetComponent<PlayerPlatformerController>().enabled = true;
	}

	public void Quit()
	{
		Application.Quit();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		//print("TRIGGER ENTER");
		if (col.tag == "Spikes")
		{
			//SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			//transform.position = spawnPos;
			//health = 35;
			PlayerDeath();
		}
		if (col.tag == "Portal" && col.tag != "Bullet")
		{
			GameManager.Instance.LevelLoad();
		}
		if (col.tag == "Enemy" || col.tag == "FlyingEnemy")
		{
			print("entering fuck");
			var opposite = -rb2d.velocity;
			print(opposite);
			rb2d.AddForce(opposite * Time.deltaTime);
			Damage(5);
			//transform.position = spawnPos;
		}

	}

	public void Damage(int dmg)
	{
		if (isDead)
		{
			return;
		}
		health -= dmg;
		print("kiwi damaged");
		if (health <= 0)
		{
			PlayerDeath();
			//transform.position = spawnPos;
			//health = 35;
		}
	}

	public void PlayerDeath()
	{
		// vignette effect, tone down colors, play sound, and at the end
		animator.SetTrigger("Died");
		isDead = true;
		animator.SetBool("IsDead", true);
		SoundManager.instance.PlaySound("Death");
		Camera.main.GetComponent<PostProcessVolume>().profile = DeathProfile;
		gameObject.GetComponent<PlayerPlatformerController>().enabled = false;

		deathNotif.SetActive(true);
	}

	public void Spawn()
	{
		transform.position = spawnPos;
		health = maxHealth;
		animator.ResetTrigger("Died");
		isDead = false;
		animator.SetBool("IsDead", false);
		animator.SetTrigger("Spawn");
		Camera.main.GetComponent<PostProcessVolume>().profile = NormalProfile;
		gameObject.GetComponent<PlayerPlatformerController>().enabled = true;

		deathNotif.SetActive(false); // so so so ugly but deadlines
	}
}