using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Paddle : MonoBehaviour, IDamageable
{
	public int TotalHealthPoints { get; private set; }
	public int HealthPoints { get; private set; }
	public float speed;
	public float minX;
	public float maxX;
	public bool canMove;
	public Rigidbody2D rig;
	public GameObject paddlePower;
	public GameManager manager;
	public GameUI gameUI;
	private float _powerTime = 0;

	private void Start()
	{
		HealthPoints = 5;
	}

	void Update()
	{
		if (canMove)
		{
			if (Input.GetKey(KeyCode.LeftArrow))
			{
				rig.velocity = new Vector2(-1 * speed * Time.deltaTime, 0);
			}
			else if (Input.GetKey(KeyCode.RightArrow))
			{
				rig.velocity = new Vector2(1 * speed * Time.deltaTime, 0);
			}
			else
			{
				rig.velocity = Vector2.zero;
			}

			transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), transform.position.y, 0);
		}

		activePower();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Ball")
		{
			col.gameObject.GetComponent<Ball>().SetDirection(transform.position);
		}
	}

	public void ResetPaddle()
	{
		transform.position = new Vector3(0, transform.position.y, 0);
	}

	public void activePower()
	{
		if (Input.GetKey(KeyCode.DownArrow))
		{
			_powerTime = Time.time;
			paddlePower.SetActive(true);
		}

		if (Time.time - _powerTime >= 15)
		{
			paddlePower.SetActive(false);
		}
	}

	public void TakeHit()
	{

		if (HealthPoints <= 0)
			return;

		HealthPoints--;

		if (HealthPoints <= 0)
		{
			manager.lives = 0;
			manager.LiveLost();

			gameObject.SetActive(false);
			Destroy(gameObject);
		}
	}
}
