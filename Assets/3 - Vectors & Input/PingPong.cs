using UnityEngine;
using System.Collections;

public class PingPong : MonoBehaviour {

	Vector3 direction; //vector to store our direction
	Vector3 dest1 = new Vector3 (5, 0, 0); //vector to store destination 1
	Vector3 dest2 = new Vector3 (-5, 0, 0); //vector to store destination 2
	float speed = 4f; //float to store the speed at which our gameobject moves
	
	void Start()
	{
		direction = new Vector3(speed, 0, 0); //assign the starting speed of x axis in direction
	}

	void Update () 
	{
		if(Input.GetKey (KeyCode.Space))
		{
			transform.position += direction * Time.deltaTime; //add the direction vector onto the gameobject position vector multiplied by Time (1 second) and speed (4 times per second)
		}
		if(transform.position.x >= dest1.x) //check if the x position of our gameobject is greater than or equal to dest1 x position
		{
			direction = new Vector3 (-speed, 0, 0); //update direction to move negatively on x axis
		}
		else if(transform.position.x <= dest2.x) //check if the x position of our gameobject is less than or equal to dest2 x position
		{
			direction = new Vector3 (speed, 0, 0); //update direction to move positively on x axis
		}
	}
}
