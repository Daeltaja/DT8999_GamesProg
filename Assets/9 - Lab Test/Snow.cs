using UnityEngine;
using System.Collections;

public class Snow : Entities {

	public void SetupSnow(float xPos, float yPos, float xSize, float ySize, float speed, Color col)
	{
		xPosition = xPos;
		yPosition = yPos;
		transform.position = new Vector3(xPosition, yPosition, 0);
		
		xScale = xSize;
		yScale = ySize;
		transform.localScale = new Vector3(xScale, yScale, .1f);
		
		moveSpeed = speed;
		color = col;
		GetComponent<Renderer>().material.color = color;
	}
	
	new void Start()
	{
		
	}
	
	void Update () 
	{
		transform.Translate(-transform.up * moveSpeed * Time.deltaTime);
		
		if(transform.position.y < -5)
		{
			Destroy(gameObject);
		}
	}
}
