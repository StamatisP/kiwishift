using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
	#region singleton stuff
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
	#endregion 
	public bool isShifted { get; set; }
	public List<GameObject> normalWorldObjects;
	public List<GameObject> otherWorldObjects;
	public List<Tilemap> normalWorldRenderers;
	public List<Tilemap> otherWorldRenderers;
	public List<TilemapCollider2D> normalWorldColliders;
	public List<TilemapCollider2D> otherWorldColliders;

	// Update is called once per frame
	void Start ()
	{
		isShifted = false;
		//DontDestroyOnLoad();
	}

	//[MenuItem ("Testing/Call Level Load")]
	public void LevelLoad ()
	{
		StartCoroutine ("LevelLoadCoroutine");
	}

	IEnumerator LevelLoadCoroutine ()
	{
		print ("loading level...");
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
		yield return new WaitForFixedUpdate ();

		// levelload should get called when you hit the exit portal, and when you click "start game" on main menu
		normalWorldObjects.Clear ();
		otherWorldObjects.Clear ();
		normalWorldRenderers.Clear ();
		otherWorldRenderers.Clear ();

		List<GameObject> normalWorldObjectsList = GameObject.FindGameObjectsWithTag ("NormalWorld").ToList ();
		foreach (GameObject _go in normalWorldObjectsList)
		{
			Debug.Log ("loop work");
			print (_go.name);
			normalWorldObjects.Add (_go);
			normalWorldRenderers.Add (_go.GetComponent<Tilemap> ());
			normalWorldColliders.Add (_go.GetComponent<TilemapCollider2D> ());
		}
		// this is so spaghetti

		List<GameObject> otherWorldObjectsList = GameObject.FindGameObjectsWithTag ("OtherWorld").ToList ();
		foreach (GameObject _go in otherWorldObjectsList)
		{
			Debug.Log ("loop work");
			print (_go.name);
			otherWorldObjects.Add (_go);
			otherWorldRenderers.Add (_go.GetComponent<Tilemap> ());
			otherWorldColliders.Add (_go.GetComponent<TilemapCollider2D> ());
		}

		yield return null;
	}

	//[MenuItem ("Testing/Call Phase Shift")]
	public void PhaseShift ()
	{
		isShifted = !isShifted; // if false, then in normal world. if true, then other world
		print ("shifting phase " + isShifted);

		// the sprite renderer should be cached...
		// did it, cached above

		// this won't work really good, i need to somehow reset the colliders and color
		if (isShifted == false)
		{
			foreach (Tilemap _rend in otherWorldRenderers)
			{
				_rend.color = new Color (1f, 1f, 1f, 0.5f);
				// wait shit its not gonna reset oh
			}
			foreach (TilemapCollider2D _coll in otherWorldColliders)
			{
				_coll.enabled = false;
			}
		}
		else if (isShifted == true)
		{
			foreach (Tilemap _rend in normalWorldRenderers)
			{
				_rend.color = new Color (1f, 1f, 1f, 0.5f);
			}
			foreach (TilemapCollider2D _coll in normalWorldColliders)
			{
				_coll.enabled = false;
			}
		}

		/* if (isShifted == false)
		{
			foreach (var obj in otherWorldObjects)
			{
				obj.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 0.5f);
			}
		}
		else if (isShifted == true)
		{
			foreach (var obj in normalWorldObjects)
			{
				obj.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 0.5f);
			}
		}*/
	}
}