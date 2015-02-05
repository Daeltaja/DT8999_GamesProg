using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	float horiz, vert; //floats to store axis value, which is 0-1
	
	void StoreAxis()
	{
		horiz = Input.GetAxis ("Horizontal") * 5f * Time.deltaTime; //store a stored axis in a float
		vert = Input.GetAxis ("Vertical") * 5f * Time.deltaTime;
	}
	
	void Update () 
	{
		StoreAxis(); //axis values need to be updated every frame 
		transform.Translate(horiz, vert, 0);
	}
}
