using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public float force = 10f;
	
	void FixedUpdate () 
	{
		rigidbody.velocity = rigidbody.velocity.normalized * force;
	}
}
