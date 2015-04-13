using UnityEngine;
using System.Collections;

public class EnemySteering : MonoBehaviour {

	public Vector3 forceAcc;
	public Vector3 velocity;
	public float mass = 1f;
	public float maxSpeed = 5f;
	public Vector3 target;
	public GameObject targetGO;
	public Vector3 dest = new Vector3(100, 5, 10);
	float timer = 2f, time;
	void Update () 
	{
		ForceIntegrator();
		time += Time.deltaTime;
		if(time >= timer)
		{
			dest = new Vector3(100, Random.Range (-20f, 20f), Random.Range (-30f, 30f));
			time = 0;
		}
	}
	
	void ForceIntegrator()
	{
		Vector3 accel = forceAcc / mass;
		velocity = velocity + accel * Time.deltaTime;
		transform.position = transform.position + velocity * Time.deltaTime;
		forceAcc = Vector3.zero;
		if(velocity.magnitude > float.Epsilon)
		{
			transform.forward = Vector3.Normalize(velocity);
		}
		velocity *= 0.99f;
		forceAcc += Seek(target);
	}
	
	Vector3 Seek(Vector3 target)
	{
		Vector3 desired = target - transform.position;
		desired.Normalize();
		desired *= maxSpeed;
		return desired - velocity;
	}
	
	Vector3 Flee(Vector3 target) //flee is just the opposite of Seek. We create an Vector3 to steer the agent in the opposite direction
	{
		Vector3 desiredVel = target - transform.position; //same as flee
		float distance = desiredVel.magnitude; //we now create a distance float, which tracks the distance between agent and target using the magnitude of the vector (distance)
		if(distance < 10f) //if the distance between the two is less than 4 units, Flee!
		{
			desiredVel.Normalize();
			desiredVel *= maxSpeed;
			return velocity - desiredVel; //we create our opposing force here, notice how we flipped the vectors compared to Seek
		}
		else //if our agent and target are greater than 4 units apart
		{
			return Vector3.zero; //return a 0,0,0 vector (we don't want to move!)
		}
	}
	
	Vector3 Evade()
	{
		Vector3 desiredVel = targetGO.transform.position + (maxSpeed * targetGO.GetComponent<SteeringBehavioursPlayer>().velocity);
		return Flee(desiredVel);
	}
	
}
