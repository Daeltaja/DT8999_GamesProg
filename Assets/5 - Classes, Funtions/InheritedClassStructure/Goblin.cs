using UnityEngine;
using System.Collections;

public class Goblin : Enemies {

	public void SetupGoblin(float xPos, float yPos, float xSize, float ySize, float speed, Color col) //Custom public function with parameters to define properties for gameobjects, like a constructor of sorts
	{
		xPosition = xPos; //assign the xPosition variable from the base class with the parameter from above
		yPosition = yPos;
		transform.position = new Vector3(xPosition, yPosition, 0); //create a new position for the goblin, using whatever value for xPosition and yPosition we pass over
		
		xScale = xSize;
		yScale = ySize;
		transform.localScale = new Vector3(xScale, yScale, 1);//create a new scale for the goblin, using whatever value for xScale and yScale we pass over
		
		moveSpeed = speed;
		
		color = col;
		renderer.material.color = color; //access the color property and assign the color value we passed over
	}	
	
	void Start()
	{

	
	}
	
	void Update()
	{
		float vert = Input.GetAxisRaw ("Vertical");
		transform.Translate(transform.up * vert * moveSpeed * Time.deltaTime); //move the object on the up axis (0, 1, 0) multiplied by the value of our vert axis, * by moveSpeed and finally by Time.deltatime
		
		if(transform.position.y > 6)
		{
			Enemies.enemies.Remove(gameObject); //remove this gameobject from the static list enemies in the Enemies script
			Destroy(gameObject);
		}
	}
}
