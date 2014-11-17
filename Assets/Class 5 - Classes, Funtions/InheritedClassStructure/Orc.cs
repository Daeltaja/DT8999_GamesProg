using UnityEngine;
using System.Collections;

public class Orc : Enemies {

	public void CreateOrc(int orcCount, Color col, int ag, float hei, float wei, float spee, float xPos)
	{
		clothesColor = col;
		age = ag;
		weight = wei;
		height = hei;
		speed = spee;
		transform.position = new Vector3(xPos, 0, 0);
		transform.localScale = new Vector3(1, hei, 1);
		renderer.material.color = clothesColor;
		name = "Orc";
	}
	
	void Start()
	{
		gameObject.AddComponent<Movement>();
	}
}
