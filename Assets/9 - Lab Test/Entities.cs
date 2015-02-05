using UnityEngine;
using System.Collections.Generic;

public class Entities : MonoBehaviour {

	public float xPosition, yPosition;
	public float xScale, yScale;
	public float moveSpeed;
	public Color color;
	public static List<GameObject> chimneys = new List<GameObject>();
	
	void Start()
	{
		CreateSanta();
		CreateRooftop();
		InvokeRepeating("CreateChimney", 0f, 1.5f);
		//InvokeRepeating("CreateSnow", 0f, 0.2f);
	}
	
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			CreatePresent();
		}
	}
	
	public void CreateSanta()
	{
		GameObject santa;
		santa = GameObject.CreatePrimitive(PrimitiveType.Cube);
		santa.AddComponent<Santa>();
		Santa santaScript = santa.GetComponent<Santa>();
		santaScript.SetupSanta(0f, 4f, 1f, 0.7f, 5f, Color.red);
		santa.name = "Santa";
	}
	
	public void CreatePresent()
	{
		GameObject present = GameObject.CreatePrimitive(PrimitiveType.Cube);
		present.AddComponent<Presents>();
		Presents presentScript = present.GetComponent<Presents>();
		float randomScale = Random.Range (0.2f, 0.4f);
		Color randomColor = new Color(Random.Range (0.1f, 1f), Random.Range (0.1f, 1f), Random.Range (0f, 0.1f), 0); //Extra
		GameObject santa = GameObject.Find ("Santa");
		presentScript.SetupPresent(santa.transform.position.x, santa.transform.position.y, randomScale, randomScale, 10f, randomColor);
		present.name = "Present";
	}
	
	void CreateChimney()
	{
		GameObject chimney = GameObject.CreatePrimitive(PrimitiveType.Cube);
		chimney.AddComponent<Chimneys>();
		Chimneys chimneyScript = chimney.GetComponent<Chimneys>();
		chimneyScript.SetupChimney(9.8f, -3.5f, 1, 1, 5f, Color.grey);
		chimney.name = "Chimney";
		chimneys.Add (chimney);
	}
	
	void CreateRooftop()
	{
		GameObject roofTop = GameObject.CreatePrimitive(PrimitiveType.Cube);
		roofTop.AddComponent<RoofTop>();
		RoofTop roofTopScript = roofTop.GetComponent<RoofTop>();
		roofTopScript.SetupRooftop(0f, -4.2f, 20, 1, Color.blue);
		roofTop.name = "Rooftop";
	}
	
	void CreateSnow()
	{
		for(int i = 0; i < 6; i++)
		{
			GameObject snow = GameObject.CreatePrimitive(PrimitiveType.Cube);
			snow.AddComponent<Snow>();
			Snow snowScript = snow.GetComponent<Snow>();
			float randomXPos = Random.Range (-9f, 9f);
			float randomScale = Random.Range (0.02f, 0.08f);
			float randomSpeed = Random.Range (3f, 5f);
			snowScript.SetupSnow(randomXPos, 6.5f, randomScale, randomScale, randomSpeed, Color.white);
			snow.name = "Snow";
		}
	}
}
