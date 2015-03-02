using UnityEngine;
using System.Collections;

public class DoorOpened : State { //inherit from state
	
	public DoorOpened(GameObject myGameObject):base (myGameObject) //constructor that needs the same argument as the State base class constructor. use :base(GameObject) to inherit the same myGameObject reference, so this class can access the gameobject it's refereing to
	{
		
	}
	public override void Enter() //override runs over the base class abstract method of the same name (abstract methods can't handle functionality, they are only a blueprint)
	{
		Debug.Log("I'm gonna open!");
	}
	public override void Update() //override runs over the base class abstract method of the same name (abstract methods can't handle functionality, they are only a blueprint)
	{
		myGameObject.transform.Translate(Vector3.up * 2 * Time.deltaTime);
	}
	public override void Exit() //override runs over the base class abstract method of the same name (abstract methods can't handle functionality, they are only a blueprint)
	{
		
	}
}
