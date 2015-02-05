using UnityEngine;
using System.Collections;

public class Functions : MonoBehaviour {

	public int health = 0;

	void Start ()
	{
		DoSomething(this.gameObject);
		MyAge ();
		AddScore(10, 7);
		Distance();
	}

	void DoSomething()
	{
		Debug.Log("I did something!");
	}
	
	void DoSomething(GameObject me) //Create a local GO variable called me. A gameobject must be passed in when we call this function in order for it to run
	{
		//Destroy(me); //the passed gameobject in the function called is stored in me so we can access it. In this case we are simple destroying it
	}
	
	void IncreaseHealth(int adjustHealth) //Overload Function
	{
		health += adjustHealth; //our health is adjusted by the passed amount
	}
	
	void Update()
	{
		if(Input.GetKeyDown (KeyCode.Space))
		{
			IncreaseHealth(10); //we pass the value of 10 into the IncreaseHealth function paramater
		}
	}
	
	int MyAge()
	{
		int age = 31;
		Debug.Log("My age is "+age);
		return age;
	}
	
	int AddScore(int a, int b) //create a function with a return type int with 2 paramaters
	{
		int total = a + b; //create a new local int Total and assign it with the added value of the values passed into a and b in the function call
		Debug.Log ("My score is " +total);
		return total; //returns the total
	}
	
	Vector3 Distance()
	{
		Vector3 target = new Vector3(50, 0, 0);
		Vector3 distance = this.transform.position - target;
		//float distance = (this.transform.position - target).magnitude; //you could return a float also if you wanted the specific meter distance
		Debug.Log ("I am " +distance +" meters away from my target.");
		return distance;
	}
}
