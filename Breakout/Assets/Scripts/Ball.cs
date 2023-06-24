using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour 
{
	public float speed;				
	public float maxSpeed;			
	public Vector2 direction;		
	public Rigidbody2D rig;			
	public GameManager manager;		
	public bool goingLeft;			
	public bool goingDown;			

	void Start ()
	{
		transform.position = Vector3.zero;		
		direction = Vector2.down;				
		StartCoroutine("ResetBallWaiter");		
	}

	void Update ()
	{
		rig.velocity = direction * speed * Time.deltaTime;			

		if(transform.position.x > 5 && !goingLeft){					
			direction = new Vector2(-direction.x, direction.y);		
			goingLeft = true;										
		}
		if(transform.position.x < -5 && goingLeft){					
			direction = new Vector2(-direction.x, direction.y);		
			goingLeft = false;										
		}
		if(transform.position.y > 3 && !goingDown){					
			direction = new Vector2(direction.x, -direction.y);		
			goingDown = true;									
		}
		if(transform.position.y < -5){								
			ResetBall();									
		}
	}


	public void SetDirection (Vector3 target)
	{
		Vector2 dir = new Vector2();			

		dir = transform.position - target;		
		dir.Normalize();					

		direction = dir;						

		speed += manager.ballSpeedIncrement;    

		if(speed > maxSpeed)					
			speed = maxSpeed;					

		if(dir.x > 0)							
			goingLeft = false;
		if(dir.x < 0)							
			goingLeft = true;	
		if(dir.y > 0)							
			goingDown = false;
		if(dir.y < 0)							
			goingDown = true;
	}


	public void ResetBall ()
	{
		transform.position = Vector3.zero;		
		direction = Vector2.down;				
		StartCoroutine("ResetBallWaiter");		
		manager.LiveLost();						
	}


	IEnumerator ResetBallWaiter ()
	{
		speed = 200;
		yield return new WaitForSeconds(1.0f);	
		speed = 500;
	}
}
