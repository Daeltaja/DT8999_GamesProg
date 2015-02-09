using UnityEngine;
using System.Collections;

public class ClickyThing : MonoBehaviour {
 
 	public GameObject bomb;
 	
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
			
				GameObject ballClone = (GameObject)Instantiate(bomb, whatIHit.point, bomb.transform.rotation); //simple instantiation
			}
		}
	}
}
