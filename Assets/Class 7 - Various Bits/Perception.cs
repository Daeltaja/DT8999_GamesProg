using UnityEngine;
using System.Collections;

public class Perception : MonoBehaviour {

	Vector2 a, b;
	public Transform target;

	void Update () 
	{
		Vector3 forwardDirection = transform.TransformDirection(Vector3.right);
		Vector3 vectorToOther = target.position - transform.position;
		vectorToOther.Normalize();
		
		Debug.DrawLine (transform.position, target.position);
		Debug.DrawLine (transform.position, transform.position + forwardDirection * 4);
		
	//	float dotH = Vector3.Dot (vectorToOther, forwardDirection); //for testing the non-normalized Vector
		//Debug.Log (dotH);
		
		//float dotMath = (forwardDirection.x * forwardDirection.x) + (forwardDirection.y * vectorToOther.y) + (forwardDirection.z * vectorToOther.z); //this way works too!
		float dot = Vector3.Dot(vectorToOther, forwardDirection);
		
		float fov = 45f;
		float angle = Mathf.Acos(dot) * Mathf.Rad2Deg; 
		
		if(angle < fov)
		{
			Debug.Log ("Spotted!");
			target.renderer.material.color = Color.red;
		}
		else
		{
			target.renderer.material.color = Color.white;
		}
		//Debug.Log (angle);
	}
}
