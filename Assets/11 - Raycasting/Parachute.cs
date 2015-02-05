using UnityEngine;
using System.Collections;

public class Parachute : MonoBehaviour {

	public LayerMask ground;
	public float paraDrag = 8f;
	Animator myAnimator;
	bool shuteOpened;

	void Start () 
	{
		myAnimator = GetComponent<Animator>();
	}
	
	void Update () 
	{
		Debug.DrawRay (this.transform.position, -transform.up * 4f, Color.red);
		Ray myRay = new Ray(this.transform.position, -transform.up);
		if(!shuteOpened)
		{
			if(Physics.Raycast(myRay, 4f, ground))
			{
				OpenParachute();
			}
		}
	}
	
	void OpenParachute()
	{
		shuteOpened = true;
		this.rigidbody.drag = paraDrag;
		myAnimator.SetTrigger("Open");
	}
	
	void OnCollisionEnter()
	{
		myAnimator.SetTrigger("Close");
	}
}
