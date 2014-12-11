using UnityEngine;
using System.Collections;

public class Goblin : Enemies {

	public void SetupGoblin(float xPos, float yPos, float xSize, float ySize, float speed, Color col)
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
	
	void Update()
	{
		float vert = Input.GetAxisRaw ("Vertical");
		transform.Translate(transform.up * vert * moveSpeed * Time.deltaTime);
		
		if(transform.position.y > 6)
		{
			Enemies.enemies.Remove(gameObject); //remove this gameobject from the static list enemies in the Enemies script
			Destroy(gameObject);
		}
	}
}
