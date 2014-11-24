using UnityEngine;
using System.Collections;

public class RigidBodies : MonoBehaviour {

	public float force = 100f;
	public float speed = 10f;
	public float maxSpeed = 10f;
	float horizInput, vertInput;
	public float decellaration = 0.92f;
	public float rotateSpeed = 3f;
	public float maxRotateSpeed = 1f;
	public PhysicMaterial bouncy;
	
	void StoreAxis()
	{
		horizInput = Input.GetAxis("Horizontal");
		vertInput = Input.GetAxis("Vertical");
	}
	
	void Update()
	{
		StoreAxis ();
		if(Input.GetKey(KeyCode.Space))
		{
			ShootBall();
		}
	}
	
	void FixedUpdate () 
	{
		if(rigidbody.velocity.magnitude < maxSpeed)
		{
			rigidbody.AddForce(transform.up * vertInput * speed, ForceMode.Force); 
		}
		if(rigidbody.angularVelocity.magnitude < maxRotateSpeed)
		{
			rigidbody.AddTorque(-transform.forward * horizInput * rotateSpeed);
		}
		
		if(vertInput < 1 && vertInput > -1)
		{
			rigidbody.velocity = rigidbody.velocity * decellaration;
		}
		if(horizInput < 1 && horizInput > -1)
		{
			rigidbody.angularVelocity = rigidbody.angularVelocity * decellaration;
		}
	}
	
	void ShootBall()
	{
		GameObject ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		ball.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
		ball.transform.position = new Vector3(transform.position.x, transform.position.y + 0.8f, transform.position.z);
		ball.AddComponent<Rigidbody>();
		ball.renderer.material.color = new Color(Random.Range (0.1f, 1f), Random.Range (0.1f, 1f), Random.Range (0.1f, 1f), 0);
		Light light = ball.AddComponent<Light>();
		light.range = 1f;
		light.color = new Color(Random.Range (0.1f, 1f), Random.Range (0.1f, 1f), Random.Range (0.1f, 1f), 0);
		ball.rigidbody.useGravity = false;
		ball.AddComponent<Ball>();
		ball.AddComponent<ParticleSystem>();
		ball.rigidbody.AddForce(transform.up * 10f);
		ball.rigidbody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
		ball.collider.material = bouncy;
		//InvokeRepeating("Toggle", Random.Range (0, 0.3f), Random.Range (.5f, 1f));
	}
}
