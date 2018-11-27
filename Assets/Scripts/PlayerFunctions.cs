using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerFunctions : MonoBehaviour
{

	//bool isShifted; // if false, then in normal world. if true, then other world

	// Use this for initialization
	void Start ()
	{
		//isShifted = false;
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
	}

	void OnTriggerEnter2D(Collider2D col) {
		//print("TRIGGER ENTER");
		if (col.tag == "Spikes") {
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}