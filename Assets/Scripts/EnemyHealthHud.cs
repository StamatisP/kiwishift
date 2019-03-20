using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthHud : MonoBehaviour
{

	private Enemy enemy;
	private FlyingEnemyBehavior flyEnemy;
	private float health;
	private TMPro.TextMeshProUGUI text;
	// Use this for initialization
	void Start ()
	{
		if (!GetComponentInParent<Enemy> ())
		{
			flyEnemy = GetComponentInParent<FlyingEnemyBehavior> ();
			health = flyEnemy.health;
			text = GetComponent<TMPro.TextMeshProUGUI> ();
			return;
		}
		enemy = GetComponentInParent<Enemy> ();
		text = GetComponent<TMPro.TextMeshProUGUI> ();
		health = enemy.health;

		/* float offsetPosY = enemy.transform.position.y + 1.5f;
		Vector3 offsetPos = new Vector3 (enemy.transform.position.x, offsetPosY, enemy.transform.position.z);
		Vector2 canvasPos;
		Vector2 screenPoint = Camera.main.WorldToScreenPoint (offsetPos);
		RectTransformUtility.ScreenPointToLocalPointInRectangle (canvasRect, screenPoint, null, out canvasPos);*/

	}

	// Update is called once per frame
	void Update ()
	{
		if (!enemy)
		{
			//Vector3 posFly = Camera.main.WorldToScreenPoint (flyEnemy.transform.position);
			float hpFly = flyEnemy.health / health;
			text.text = "Health: " + flyEnemy.health;
			text.color = Color.Lerp (Color.red, Color.white, hpFly);
			transform.eulerAngles = new Vector3 (0, 0, 0);
			return;
		}
		//Vector3 pos = Camera.main.WorldToScreenPoint (enemy.transform.position);
		float hp = (float) enemy.health / (float) health;
		text.text = "Health: " + enemy.health;
		text.color = Color.Lerp (Color.red, Color.white, hp);
		transform.eulerAngles = new Vector3 (0, 0, 0);
	}
}