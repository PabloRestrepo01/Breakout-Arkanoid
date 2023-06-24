using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour, IDamageable
{
	public GameManager manager;
	public int TotalHealthPoints { get; private set; }
	public int HealthPoints { get; private set; }

	private void Start()
	{
		HealthPoints = 1;
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if(col.gameObject.tag == "Ball"){												
			manager.score++;															
			col.gameObject.GetComponent<Ball>().SetDirection(transform.position);

			if (manager.score == 30)
			{
				manager.WinGame();
			}

			Destroy(gameObject);														
		}
	}

	public void TakeHit()
	{
		
		if (HealthPoints <= 0)
			return;

		HealthPoints--;
		manager.score++;

		if (HealthPoints <= 0)
		{
			if (manager.score == 30)
			{
				manager.WinGame();
			}

			gameObject.SetActive(false);
			Destroy(gameObject);
		}
	}

}
