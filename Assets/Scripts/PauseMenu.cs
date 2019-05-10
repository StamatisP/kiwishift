using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
	[SerializeField]
	private GameObject pauseGui;
	private bool isPaused = false;

	// Use this for initialization
	void Start()
	{
		isPaused = false;
		pauseGui.SetActive(false);

	}

	// Update is called once per frame
	void Update()
	{
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
					isPaused = false;
					Time.timeScale = 1f;
				}
				else
				{
					print("pausing");
					pauseGui.SetActive(true);
					isPaused = true;
					Time.timeScale = 0f;
				}
			}
		}
	}

	public void Continue()
	{
		isPaused = false;
		pauseGui.SetActive(false);
		Time.timeScale = 1f;
	}

	public void Quit()
	{
		Application.Quit();
	}
}