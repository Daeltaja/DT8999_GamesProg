using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public float force = 10f;
	
	void FixedUpdate () 
	{
		GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * force;
	}
}
