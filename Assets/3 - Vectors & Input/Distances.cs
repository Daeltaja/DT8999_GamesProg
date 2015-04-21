using UnityEngine;
using System.Collections;

public class Distances : MonoBehaviour {

	Vector3 myPos; //new vector a
	Vector3 targetPos; //new vector b
	public Transform target; //assign this in the inspector
	
	void Update () 
	{
		if(target) //checks to see if we have a target assigned
		{
			target.gameObject.GetComponent<Renderer>().material.color = Color.red;
			myPos = transform.position; //assigns myPos with this gameobjects position
			targetPos = target.transform.position; //assigns targetPos with targets position
			Debug.Log (Vector3.Distance (myPos, targetPos)); //check the distance between two vectors
			float distance = Vector3.Distance(myPos, targetPos); //creates a local variable to store the distance between 2 vectors
			//float distance = (myPos - targetPos).magnitude; //another way to get the distance between two objects
			
			if(distance < .5f) //checks if distance between two vectors is less than .5
			{
				Destroy(target.gameObject); //destroy target gameobject
			}
		}
		else
		{
			if(GameObject.Find ("Target"))
			target = GameObject.Find ("Target").transform; //looks for a new target when we have destroyed the previous one
		}
	}
}
