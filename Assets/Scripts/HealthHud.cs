using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHud : MonoBehaviour
{

	private PlayerFunctions player;
	private TMPro.TextMeshProUGUI text;
	private int health;
	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerFunctions> ();
		text = GetComponent<TMPro.TextMeshProUGUI> ();
		health = player.health;
	}

	// Update is called once per frame
	void Update ()
	{
		float hp = (float) player.health / (float) health;
		text.text = "Health: " + player.health;
		text.color = Color.Lerp (Color.red, Color.white, hp);
		//print (hp);
	}
}