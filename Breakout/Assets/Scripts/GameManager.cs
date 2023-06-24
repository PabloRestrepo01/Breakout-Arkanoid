using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
	public int score;
	public int lives;
	public int ballSpeedIncrement;
	public bool gameOver;
	public bool wonGame;
	public GameObject enemy;

	public GameObject paddle;
	public GameObject ball;

	public GameUI gameUI;

	//Prefabs
	public GameObject brickPrefab;
	public GameObject hardBrickPrefab;

	public List<GameObject> bricks = new List<GameObject>();
	public int brickCountX;
	public int brickCountY;

	public Color[] colors;

	void Start()
	{
		StartGame();
	}

		public void StartGame()
		{
			score = 0;
			lives = 3;
			gameOver = false;
			wonGame = false;
			paddle.active = true;
			ball.active = true;
			enemy.active = true;
			paddle.GetComponent<Paddle>().ResetPaddle();
			CreateBrickArray();
		}


		public void CreateBrickArray()
		{
			int colorId = 0;

			for (int y = 0; y < brickCountY; y++) {
				for (int x = -(brickCountX / 2); x < (brickCountX / 2); x++)
				{
					Vector3 pos = new Vector3(0.8f + (x * 1.6f), 1 + (y * 0.4f), 0);
					GameObject brick = Instantiate(brickPrefab, pos, Quaternion.identity) as GameObject;
					brick.GetComponent<Brick>().manager = this;
					brick.GetComponent<SpriteRenderer>().color = colors[colorId];
					bricks.Add(brick);
				}
	
			colorId++;

				if (colorId == colors.Length)
					colorId = 0;
			}

			for (int x = -(brickCountX / 2); x < (brickCountX / 2); x++)
			{
				Vector3 pos = new Vector3(0.8f + (x * 1.6f), 1 + (brickCountY * 0.4f), 0);
				GameObject brick = Instantiate(hardBrickPrefab, pos, Quaternion.identity) as GameObject;
				brick.GetComponent<HardBrick>().manager = this;
				bricks.Add(brick);
			}

		ball.GetComponent<Ball>().ResetBall();
		}

		public void WinGame()
		{
			wonGame = true;
			paddle.active = false;
			ball.active = false;
			enemy.active = false;
			gameUI.SetWin();

		}

		public void LiveLost()
		{
			lives--;

			if (lives <= 0) {
				gameOver = true;
				paddle.active = false;
				ball.active = false;
				enemy.active = false;
				gameUI.SetGameOver();

				for (int x = 0; x < bricks.Count; x++) {
					Destroy(bricks[x]);
				}

				bricks = new List<GameObject>();
			}
		}
	}

