using UnityEngine;
using System.Collections;

public class LoopsBasic : MonoBehaviour {

	int foodCount = 10; 
	int age = 10;
	bool alive = false;
	GameObject[] enemies;
	
	void Start () 
	{
		//for loop
		for(int i = 0; i < foodCount; i++) //create local int i with a value, execute code in the body if condition is true, increment i by 1 each loop. 
		{
			Debug.Log ("Food piece number " +i); //print out text with the value of i, after each iteration of the loop
		}
		
		//while loop - while the conditional is true, execute the code in the body
		while(age > 0)
		{
			Debug.Log ("My Age is " +age);
			age--;
		}
		
		//DoWhile loop - Will execute at least once, then checks the conditional the first iteration
		do
		{
			Debug.Log ("I am alive!");
		}
		while(alive);
		
		foreach(GameObject enemy in enemies)
		{
			enemy.AddComponent<MeshCollider>();
		}
	}
}
