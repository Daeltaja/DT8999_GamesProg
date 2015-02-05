using UnityEngine;
using System.Collections;

public class Inputs : MonoBehaviour {

	Vector3 horizDirection;
	Vector3 vertDirection;
	Vector3 rotateDir;
	float moveSpeed = 4f;
	float rotateSpeed = 360f;
	public GameObject missile;
	public Transform missileSpawn;

	// Use this for initialization
	void Start () 
	{
		//horizDirection = new Vector3(moveSpeed, 0, 0); //setting up the axis and speed to be used for the horizontal direction (X axis)
		//vertDirection = new Vector3(0, moveSpeed, 0); //setting up the axis and speed to be used for the vertical direction (Y axis)
		vertDirection = new Vector3(0, moveSpeed, 0); //setting up the axis and speed to be used for the vertical direction
		rotateDir = new Vector3(0, 0, rotateSpeed); //setting up the axis and rotate speed to be used for rotation
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKey(KeyCode.D)) //if the D key is held down
		{
			//transform.position += horizDirection * Time.deltaTime; //add the direction vector onto the gameobject position vector multiplied by Time (1 second) and speed 
			transform.Rotate(-rotateDir * Time.deltaTime, Space.Self); //function to rotate on a supplied axis over time
		}
		if(Input.GetKey(KeyCode.A)) //if the D key is held down
		{
			//transform.position -= horizDirection * Time.deltaTime; //add the direction vector onto the gameobject position vector multiplied by Time (1 second) and speed 
			transform.Rotate(rotateDir * Time.deltaTime, Space.Self); //function to rotate on a supplied axis over time
		}
		if(Input.GetKey (KeyCode.W)) //if the D key is held down
		{
			transform.Translate(vertDirection * Time.deltaTime, Space.Self); //function to translate on the supplied axis in local space
			//transform.position += vertDirection * Time.deltaTime; //add the direction vector onto the gameobject position vector multiplied by Time (1 second) and speed 
		}
		if(Input.GetKey (KeyCode.S)) //if the D key is held down
		{
			transform.Translate(-vertDirection * Time.deltaTime, Space.Self); //function to translate on the supplied axis in local space
			//transform.position -= vertDirection * Time.deltaTime; //add the direction vector onto the gameobject position vector multiplied by Time (1 second) and speed 
		}
		//Clamp the x and y positions so that you cant move out of bounds of the play area
		Vector3 clampPos = transform.position; //new vector 3 to store our position, it updates with the position of this gameobject as it moves
		clampPos.x = Mathf.Clamp(transform.position.x, -8f, 8f); //we can access the x of our new vector3 variable and clamp it with a min and max position
		clampPos.y = Mathf.Clamp(transform.position.y, -6f, 6f); //we can access the y of our new vector3 variable and clamp it with a min and max position
		transform.position = clampPos; //copy the clampPos Vector back onto the transform.position so that the clamp can take effect
		
		if(Input.GetKeyDown (KeyCode.Space)) //if the D key is held down
		{
			GameObject miss = Instantiate(missile, missileSpawn.transform.position, transform.rotation) as GameObject;
			miss.rigidbody.AddForce(transform.up * 600f);
		}
	}
}
