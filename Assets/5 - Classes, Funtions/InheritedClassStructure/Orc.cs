using UnityEngine;
using System.Collections;

public class Orc : Enemies {

	public void SetupOrc(float xPos, float yPos, float xSize, float ySize, float speed, Color col) //Custom public function with parameters to define properties for gameobjects, like a constructor of sorts
	{
		xPosition = xPos;
		yPosition = yPos;
		transform.position = new Vector3(xPosition, yPosition, 0);
		
		xScale = xSize;
		yScale = ySize;
		transform.localScale = new Vector3(xScale, yScale, 1);
		
		moveSpeed = speed;
		
		color = col;
		GetComponent<Renderer>().material.color = color;
	}	
	
	void Start()
	{
		
	}
	
	void Update()
	{
		transform.Translate(-transform.up * moveSpeed * Time.deltaTime);
		
		if(transform.position.y > 6)
		{
			Enemies.enemies.Remove(gameObject); //remove this gameobject from the static list enemies in the Enemies script
			Destroy(gameObject);
		}
	}
}
