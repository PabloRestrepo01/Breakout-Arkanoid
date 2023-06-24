using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardBrick : MonoBehaviour, IDamageable
{
	public GameManager manager;
	public int TotalHealthPoints { get; private set; }
	public int HealthPoints { get; private set; }

	private void Start()
	{
		HealthPoints = 1;
	}


	public void TakeHit()
	{

		if (HealthPoints <= 0)
			return;

		HealthPoints--;

		if (HealthPoints <= 0)
		{
			manager.score++;
			gameObject.SetActive(false);
			Destroy(gameObject);
		}
	}

}
