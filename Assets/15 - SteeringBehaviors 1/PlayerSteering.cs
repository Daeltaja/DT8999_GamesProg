using UnityEngine;
using System.Collections;

public class PlayerSteering : MonoBehaviour {

	public float mass = 1f;
	public Vector3 velocity = Vector3.zero;
	public float maxSpeed = 5f;
	public Vector3 force = Vector3.zero;
	public GameObject target;
	
	void Update () 
	{
		ForceIntegrator();
	}
	
	void ForceIntegrator()
	{
		Vector3 accel = force / mass;
		velocity = velocity + accel * Time.deltaTime;
		transform.position = transform.position + velocity * Time.deltaTime;
		force = Vector3.zero;
		if(velocity.magnitude > float.Epsilon)
		{
			transform.forward = Vector3.Normalize(velocity);
		}
		velocity *= 0.99f;
		force += Seek (target.transform.position);
	}
	
	Vector3 Seek(Vector3 target)
	{
		Vector3 desiredVel = target - transform.position;
		desiredVel.Normalize();
		desiredVel *= maxSpeed;
		return desiredVel - velocity;
	}
	
	Vector3 Flee(Vector3 target)
	{
		Vector3 desiredVel = target - transform.position;
		float distance = desiredVel.magnitude;
		float fleeDistance = 4f;
		if(distance < fleeDistance)
		{
			desiredVel.Normalize();
			desiredVel *= maxSpeed;
			return velocity - desiredVel;
		}
		else
		{
			return Vector3.zero;
		}
	}
}
