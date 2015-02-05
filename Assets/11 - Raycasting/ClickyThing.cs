using UnityEngine;
using System.Collections;

public class ClickyThing : MonoBehaviour {

	
	void Update () 
	{
		if(Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //creates a ray and uses the mouse position to shoot it from the camera into the screen
			RaycastHit whatIHit; //stores the collider tnformation of what the raycast hit
			if(Physics.Raycast(ray, out whatIHit)) //creates a raycast using the ray information and pushes out the hit collider into whatIHit so we can access it
			{
				Debug.Log ("My name is " +whatIHit.collider.gameObject.name);
				Debug.Log (whatIHit.point); //.point returns the vector3 of where the ray intersects the collider
				GameObject ball = GameObject.Find ("Parachute"); //
				Vector3 spawnPosition = whatIHit.point + Vector3.up*7; //Vector3 position of mouse click with (0, 1, 0) added to it
				GameObject ballClone = (GameObject)Instantiate(ball, spawnPosition, transform.rotation); //simple instantiation
				//ballClone.AddComponent<Rigidbody>();
				//ballClone.rigidbody.AddForce(Vector3.up * 400f);
			}
		}
	}
}
