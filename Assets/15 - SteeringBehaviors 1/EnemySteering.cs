using UnityEngine;
using System.Collections;

public class EnemySteering : MonoBehaviour {

	public Vector3 forceAcc;
	public Vector3 velocity;
	public float mass = 1f;
	public float maxSpeed = 5f;
	public Vector3 target;
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
		forceAcc += Seek(dest);
	}
	
	Vector3 Seek(Vector3 target)
	{
		Vector3 desired = target - transform.position;
		desired.Normalize();
		desired *= maxSpeed;
		return desired - velocity;
	}
}
