using UnityEngine;
using System.Collections;

public class Chimneys : Entities {

	// Use this for initialization
	new void Start ()
	{
	
	}
	
	public void SetupChimney(float xPos, float yPos, float xSize, float ySize, float speed, Color col)
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
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(-transform.right * moveSpeed * Time.deltaTime);
		
		if(transform.position.x < -10)
		{
			chimneys.Remove(gameObject);
			Destroy(gameObject);
		}
	}
}
