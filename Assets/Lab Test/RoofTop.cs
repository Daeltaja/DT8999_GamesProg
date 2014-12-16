using UnityEngine;
using System.Collections;

public class RoofTop : Entities {

	// Use this for initialization
	void Start () 
	{
	
	}
	
	void Update()
	{
		
	}

	public void SetupRooftop(float xPos, float yPos, float xSize, float ySize, Color col)
	{
		xPosition = xPos;
		yPosition = yPos;
		transform.position = new Vector3(xPosition, yPosition, 0);
		
		xScale = xSize;
		yScale = ySize;
		transform.localScale = new Vector3(xScale, yScale, .2f);
		
		color = col;
		renderer.material.color = color;
	}
}
