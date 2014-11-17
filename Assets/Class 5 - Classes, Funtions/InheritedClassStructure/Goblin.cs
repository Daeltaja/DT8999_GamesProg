using UnityEngine;
using System.Collections;

public class Goblin : Enemies {

	public void CreateGoblin(int orcCount, Color col, int ag, float hei, float wei, float spee, float xPos)
	{
		clothesColor = col;
		age = ag;
		weight = wei;
		height = hei;
		speed = spee;
		transform.position = new Vector3(xPos, 10, 0);
		transform.localScale = new Vector3(1, hei, 1);
		renderer.material.color = clothesColor;
		name = "Goblin";
	}	
	
	void Start()
	{
		gameObject.AddComponent<Movement>();
		Movement move = GetComponent<Movement>();
		move.vertDirection = -transform.up * move.speed;
	}
}
