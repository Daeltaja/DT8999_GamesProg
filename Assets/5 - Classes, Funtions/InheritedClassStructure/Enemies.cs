using UnityEngine;
using System.Collections.Generic;

public class Enemies : MonoBehaviour {
	public float xPosition, yPosition;
	public float xScale, yScale;
	public float moveSpeed;
	public Color color;
	public static List<GameObject> enemies = new List<GameObject>(); //a new static list to store the enemies, we can access this from any other script by typing 'Enemies.enemies'
	
	void Start () 
	{
		InvokeRepeating("CreateOrcs", 0f, 1f); //calls the function 'CreateGoblins' at 0 seconds, then every 1 subsequent second
		CreateGoblinBody(); //call the function
		CreateGoblinHead();
	}
	
	void CreateOrcs() 
	{
		GameObject orcGO; //create a gameobject variable, sort of like an empty box
		orcGO = GameObject.CreatePrimitive(PrimitiveType.Cube); //assign the orcGO gameobject with a newly created Cube
		orcGO.AddComponent<Orc>(); //Add the Orc script to the orc gameobject
		orcGO.GetComponent<Orc>().SetupOrc(0, 4f, 1f, 0.7f, 5f, Color.green); //a way to access and call a function in another script! Since the function has parameters, we must supply values for them
		enemies.Add (orcGO); //add this new gameobject to the enemies list	
	}
	
	void CreateGoblinBody() //create the goblin body
	{
		GameObject goblinGO; //create a gameobject variable, sort of like an empty box
		goblinGO = GameObject.CreatePrimitive(PrimitiveType.Cube); //assign the goblinGO gameobject with a newly created Cube
		goblinGO.AddComponent<Goblin>();
		goblinGO.GetComponent<Goblin>().SetupGoblin(0, 4f, 1f, 0.7f, 5f, Color.blue);
		enemies.Add(goblinGO); //add this new gameobject to the enemies list
		goblinGO.name = "Goblin";
	}
	
	void CreateGoblinHead()
	{
		GameObject goblinGO2; //create a gameobject variable, sort of like an empty box
		goblinGO2 = GameObject.CreatePrimitive(PrimitiveType.Cube); //assign the goblinGO2 gameobject with a newly created Cube
		goblinGO2.AddComponent<Goblin>();
		GameObject goblinBody = GameObject.Find ("Goblin"); //search for the goblin body aka goblinGO!
		goblinGO2.GetComponent<Goblin>().SetupGoblin(goblinBody.transform.position.x, goblinBody.transform.position.y + 1f, 1f, 0.7f, 5f, Color.blue); //use the goblin body x and y positions for where to spawn
		goblinGO2.transform.parent = goblinBody.transform; //add the new cube as a child of the parent
	}
}
