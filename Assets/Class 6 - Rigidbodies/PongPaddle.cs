using UnityEngine;
using System.Collections;

public class PongPaddle : MonoBehaviour {

	float horiz, vert;
	public PhysicMaterial bouncy;
	
	void Update ()
	{
		horiz = Input.GetAxis ("Horizontal") * 5f * Time.deltaTime;
		vert = Input.GetAxis("Vertical") * 5f * Time.deltaTime;
		
		transform.Translate(horiz, vert, 0);
		
		if(Input.GetKeyDown (KeyCode.Space))
		{
			GameObject ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			ball.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
			ball.transform.position = transform.position + new Vector3(0, .85f, 0f);
			ball.AddComponent<Rigidbody>();
			ball.AddComponent<Ball>();
			ball.rigidbody.useGravity = false;
			ball.rigidbody.AddForce(transform.up * ball.GetComponent<Ball>().force);
			ball.GetComponent<SphereCollider>().material = bouncy;
		}
	}
}
