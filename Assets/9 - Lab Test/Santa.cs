using UnityEngine;
using System.Collections;

public class Santa : Entities {

	public void SetupSanta(float xPos, float yPos, float xSize, float ySize, float speed, Color col)
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
		float horiz = Input.GetAxisRaw ("Horizontal") * moveSpeed * Time.deltaTime;
		transform.Translate(transform.right * horiz);
	}
}
