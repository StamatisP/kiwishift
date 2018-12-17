using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject
{
	//private GameManager gameManager;
	public float maxSpeed = 7;
	public float jumpTakeOffSpeed = 7;
	//public Vector3 previousPosition;

	private SpriteRenderer spriteRenderer;
	public Animator animator;
	public AudioSource audioSource;

	// Use this for initialization
	void Awake ()
	{
		spriteRenderer = GetComponent<SpriteRenderer> ();
		//animator = GetComponent<Animator> ();
		//gameManager = GameManager.Instance;

	}

	protected override void ComputeVelocity ()
	{
		Vector2 move = Vector2.zero;

		move.x = Input.GetAxis ("Horizontal");

		if (Input.GetButtonDown ("Jump") && grounded)
		{
			velocity.y = jumpTakeOffSpeed;
			SoundManager.instance.PlaySound("Jump");
		}
		else if (Input.GetButtonUp ("Jump"))
		{
			if (velocity.y > 0)
			{
				velocity.y = velocity.y * 0.5f;
			}
		}

		bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0.0f));
		if (flipSprite)
		{
			spriteRenderer.flipX = !spriteRenderer.flipX;
		}

		if (grounded && Mathf.Abs(move.x) > 0.3f) {
			audioSource.UnPause();
		} else {
			audioSource.Pause();
		}

		animator.SetBool ("Grounded", grounded);
		animator.SetFloat ("Speed", Mathf.Abs (velocity.x) / maxSpeed);

		targetVelocity = move * maxSpeed;
	}

	void AttackBounce(int attackBounce) {
		velocity.y = attackBounce;
	}

	public bool GetGrounded() {
		return grounded;
	}
}