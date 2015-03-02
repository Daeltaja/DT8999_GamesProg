using UnityEngine;
using System.Collections;

public class DoorClosed : State { //inherit from State.cs
	
	GameObject target;
	public DoorClosed(GameObject myGameObject, Transform player):base(myGameObject) //constructor that needs the same argument as the State base class constructor. use :base(GameObject) to inherit the same myGameObject reference, so this class can access the gameobject it's refereing to
	{
	
		
	}
	
	public override void Enter ()
	{
		Debug.Log ("I'm closed!");
		target = GameObject.FindWithTag("Player");
	}
	public override void Update ()
	{	
		Debug.Log ("I'm still closed...");
		if(Vector3.Distance(myGameObject.transform.position, target.transform.position) < 3)
		{
			myGameObject.GetComponent<StateMachine>().SwitchState(new DoorOpened(myGameObject));//call SwitchState and create a new state for it, passing over the constructor argument
		}
	}
	public override void Exit ()
	{
		Debug.Log ("Player detected, proceed to open!");
	}
}
