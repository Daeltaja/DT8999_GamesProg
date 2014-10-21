using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	Vector3 vertDirection;
	public float speed = 5f;
	
	// Use this for initialization
	void Start () 
	{
		vertDirection = new Vector3(0, speed, 0); //initiate the axis for vertDirection vector, using the speed float
	}
	
	// Update is called once per frame
	void Update () 
	{
		//transform.position += new Vector3 (0, 5, 0); //add the new vector (0,5,0) onto the our position vector every frame
		transform.position += vertDirection * Time.deltaTime; //same as above line, except we use the stored vector vertDirection to achieve the same thing
	}
}
