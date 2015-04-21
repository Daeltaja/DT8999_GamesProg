using UnityEngine;
using System.Collections;

public class Perception : MonoBehaviour {

	Vector2 a, b;
	public Transform target;

	void Update () 
	{
		FieldOfView();
		//InFrontOrBehind();
	}
	
	public bool FieldOfView() //if you want to spot a target within a specific angle, or cone of vision
	{
		//Vector3 forwardDirection = transform.TransformDirection(transform.forward); //give our player a default facing direction, change this is you like! It updates with it's rotation
		Vector3 vectorToOther = target.position - transform.position; 
		vectorToOther.Normalize(); //makes the vector of length 1 (x, y, z componenet of vector each divided by the length or magnitude of the vector
		//magnitude is caculated as the square root of x2, y2, z2, so for example (4, 3, 0) = 16 + 9 + 0 = 25. Square root of 25 is 5, which is the length or magnitude of the vector
		
		Debug.DrawLine (transform.position, target.position);
		Debug.DrawLine (transform.position, transform.position + transform.forward * 4);
		
		//float dotMath = (forwardDirection.x * forwardDirection.x) + (forwardDirection.y * vectorToOther.y) + (forwardDirection.z * vectorToOther.z); //this way works too!
		float dot = Vector3.Dot(vectorToOther, transform.forward); //takes two vectors and returns the dot product between them (same as calculation in line above!)
		
		float fov = 45f;
		float angle = Mathf.Acos(dot) * Mathf.Rad2Deg; //passes DOT through Acos, which returns the angle of DOT in radians. We then * by Rad2Deg to convert it to degrees.
		
		if(angle < fov) //if the angle of dot is less than 45 degrees, the target is in my cone of vision!
		{
			
			GetComponent<Renderer>().material.color = Color.red;
			return true;
		}
		else
		{
			GetComponent<Renderer>().material.color = Color.white;
			return false;
		}
	}
	
	void InFrontOrBehind()
	{
		Vector3 forwardDirection = transform.TransformDirection(transform.forward); //give our player a default facing direction, change this is you like! It updates with it's rotation
		Vector3 vectorToOther = target.position - transform.position; 
		vectorToOther.Normalize(); //makes the vector of length 1 (x, y, z componenet of vector each divided by the length or magnitude of the vector
		//magnitude is caculated as the square root of x2, y2, z2, so for example (4, 3, 0) = 16 + 9 + 0 = 25. Square root of 25 is 5, which is the length or magnitude of the vector
		
		Debug.DrawLine (transform.position, target.position);
		Debug.DrawLine (transform.position, transform.position + forwardDirection * 4);
		
		//float dotMath = (forwardDirection.x * forwardDirection.x) + (forwardDirection.y * vectorToOther.y) + (forwardDirection.z * vectorToOther.z); //this way works too!
		float dot = Vector3.Dot(vectorToOther, forwardDirection); //takes two vectors and returns the dot product between them (same as calculation in line above!)
		
		if(dot > 0) //if the angle of dot is less than 0, target is in front of the player!
		{
			Debug.Log ("Spotted!");
			target.GetComponent<Renderer>().material.color = Color.red;
		}
		else
		{
			target.GetComponent<Renderer>().material.color = Color.white;
		}
	}
}
