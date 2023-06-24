using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameUI : MonoBehaviour 
{
	public GameManager manager;		

	public Text scoreText;			
	public Text livesText;			

	public GameObject gameOverScreen;	
	public Text gameOverScoreText;	

	public GameObject winScreen;	

	void Update ()
	{
		if(!manager.gameOver && !manager.wonGame){					
			scoreText.text = "<b>SCORE</b>\n" + manager.score;		
			livesText.text = "<b>LIVES</b>: " + manager.lives;		
		}else{														
			scoreText.text = "";
			livesText.text = "";
		}
	}

	//Called when the game is over
	public void SetGameOver()
	{
		gameOverScreen.active = true;
		gameOverScoreText.text = "<b>YOU ACHIEVED A SCORE OF</b>\n" + manager.score;
	}
	
	public void SetWin ()
	{
		winScreen.active = true;
	}

	public void TryAgainButton ()
	{
		Application.LoadLevel(0);
	}
}
