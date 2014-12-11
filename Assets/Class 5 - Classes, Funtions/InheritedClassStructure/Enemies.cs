using UnityEngine;
using System.Collections.Generic;

public class Enemies : MonoBehaviour {

	public float xPosition, yPosition;
	public float xScale, yScale;
	public float moveSpeed;
	public Color color;
	public static List<GameObject> enemies = new List<GameObject>(); //a new static list to store the enemies, we can access this from any other script by typing 'Enemies.enemies'
	
	protected void Start () 
	{
		CreateOrcs(); //call the function and pass over the required values
		CreateGoblins();
	}
	
	public void CreateOrcs() 
	{
		for(int i = 0; i < 10; i++)
		{
			GameObject orcGO; //create a gameobject variable, sort of like an empty box
			orcGO = GameObject.CreatePrimitive(PrimitiveType.Cube); //assign the orcGO gameobject with a newly created Cube
			orcGO.AddComponent<Orc>(); //Add the Orc script to the orc gameobject
			orcGO.GetComponent<Orc>().SetupOrc(transform.position.x + i*2, 4f, 1f, 0.7f, 5f, Color.green); //a way to access and call a function in another script! Since the function has parameters, we must supply values for them
			enemies.Add (orcGO); //add this new gameobject to the enemies list
		}
	}
	
	public void CreateGoblins() 
	{
		for(int i = 0; i < 10; i++)
		{
			GameObject goblinGO; //create a gameobject variable, sort of like an empty box
			goblinGO = GameObject.CreatePrimitive(PrimitiveType.Cube); //assign the goblinGO gameobject with a newly created Cube
			GameObject goblinGO2; //create a gameobject variable, sort of like an empty box
			goblinGO2 = GameObject.CreatePrimitive(PrimitiveType.Cube); //assign the goblinGO2 gameobject with a newly created Cube
			goblinGO2.transform.parent = goblinGO.transform; //add the new cube as a child of the parent
			goblinGO2.transform.localPosition = new Vector3(0, 1, 0); //sets the position of the child cube relative to it's parent
			goblinGO.AddComponent<Goblin>();
			Goblin goblin = goblinGO.AddComponent<Goblin>();
			goblin.SetupGoblin(transform.position.x + i*2, 4f, 1f, 0.7f, 5f, Color.blue);;
			enemies.Add(goblinGO); //add this new gameobject to the enemies list
		}
	}
}
