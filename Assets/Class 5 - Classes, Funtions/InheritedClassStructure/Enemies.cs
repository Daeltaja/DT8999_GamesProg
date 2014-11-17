using UnityEngine;
using System.Collections.Generic;

public class Enemies : MonoBehaviour {

	public int age;
	public float height;
	public float weight;
	public float speed;
	public float strength;
	public int health;
	public Color eyeColor;
	public Color clothesColor;
	public Transform myTransform;
	public List<GameObject> enemies = new List<GameObject>(); //a new list to store the enemies
	
	protected void Start () 
	{
		CreateOrcs(); //call the function and pass over the required values
		CreateGoblins();
	}
	
	public void CreateOrcs() //Function constructor with local vars for each property to pass down into the body
	{
		for(int i = 0; i < 10; i++)
		{
			GameObject orcGO = GameObject.CreatePrimitive(PrimitiveType.Cube); //create a new empty gameobject and assign a cube to it
			Orc orc = orcGO.AddComponent<Orc>(); //create a new variable of the Orc script and add AND assign the orc script component to the variable
			orc.CreateOrc(10, Color.blue, 31, Random.Range (.5f, 2f), 5f, 5f, transform.position.x + i*2); //access the orc script instance created above and run the CreateOrc function, passing in the various parameters it needs
		}
	}
	
	public void CreateGoblins() //Function constructor with local vars for each property to pass down into the body
	{
		for(int i = 0; i < 10; i++)
		{
			GameObject goblinGO = GameObject.CreatePrimitive(PrimitiveType.Cube);
			Goblin goblin = goblinGO.AddComponent<Goblin>();
			goblin.CreateGoblin(10, Color.green, 31, Random.Range (.5f, 2f), 5f, 5f, transform.position.x + i*2);
		}
	}
}
