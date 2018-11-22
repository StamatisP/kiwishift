using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

	private static GameManager _instance;

	public static GameManager Instance
	{
		get
		{
			if (_instance == null)
			{
				GameObject go = new GameObject ("GameManager");
				go.AddComponent<GameManager> ();
			}
			return _instance;
		}
	}

	public bool isShifted { get; set; }

	// Use this for initialization
	void Awake ()
	{
		if (_instance == null)
		{
			_instance = this;
			DontDestroyOnLoad (gameObject);
		}
		else Destroy (this);
	}

	// Update is called once per frame
	void Start ()
	{
		isShifted = false;
		//DontDestroyOnLoad();
	}

	public void PhaseShift ()
	{
		isShifted = !isShifted;
		print ("shifting phase " + isShifted);
	}
}