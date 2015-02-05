using UnityEngine;
using System.Collections;

public class Presents : Entities {
	
	public void SetupPresent(float xPos, float yPos, float xSize, float ySize, float speed, Color col)
	{
		xPosition = xPos;
		yPosition = yPos;
		transform.position = new Vector3(xPosition, yPosition, 0);
		
		xScale = xSize;
		yScale = ySize;
		transform.localScale = new Vector3(xScale, yScale, 1);
		
		moveSpeed = speed;
		color = col;
		renderer.material.color = color;
	}

	void Start()
	{
		
	}

	void Update () 
	{
		transform.Translate(-transform.up * moveSpeed * Time.deltaTime);
		
		if(transform.position.y < -6)
		{
			Destroy(gameObject);
		}
		
		for(int i = 0; i < Entities.chimneys.Count; i++)
		{
			GameObject tar = Entities.chimneys[i].gameObject; //create local instance of the target with each loop
			float distance = (transform.position - tar.transform.position).magnitude; //create a float to store the distance between 2 positions (vectors)
			if(distance < 0.5f)
			{
				ScoreManager.score += 10 ;//add 5 to our score
				Debug.Log (ScoreManager.score);
				Destroy(gameObject);
			}
		}
	}
}
