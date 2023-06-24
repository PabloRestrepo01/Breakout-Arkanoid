using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddlePower : MonoBehaviour
{
	public float speed;
	public float minX;
	public float maxX;
	public bool canMove;
	public Rigidbody2D rig;
	public GameObject paddlePower;

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
}
