using UnityEngine;
using System.Collections;

public class Variables : MonoBehaviour {
		
		
	public int age; //an int is a whole number, ie. 4, 17, 217, 459
	public float moveSpeed; //an int is a number with a decimal point, ie. 1.5, 17.63, 217.513, 459.669
	public string name;	//string is an array of character
	public bool iAmAwesome;	//a bool is either true or false
	
	// Use this for initialization
	public void Start () 
	{
		age = 31;
		name = "Paul";
		moveSpeed = 4.5f;
	}
	
	// Update is called once per frame
	public void Update () 
	{
		Debug.Log (name); //prints the single variable to the console
		Debug.Log (age);
		Debug.Log (name + " is " + age + " and he can run at" + moveSpeed + "mph."); //prints multiple variables to console using + additional parameters and "" for text
		Debug.Log (name + " is located at " + transform.position); 
		if(age > 30) //if age is greater than 30
		{
			Debug.Log("Old Fart");
		}
		else //otherwise (checks the opposite to what is in the if above it)
		{
			Debug.Log("Young wan");
		}
		if(transform.position.y < 0) //if our cubes transform.y is less than 0
		{	
			renderer.material.color = Color.red; //set the color, which is a part of the renderer to color red
		}
		else
		{
			renderer.material.color = Color.green; //set the color, which is a part of the renderer to color red
		}
	}
}
