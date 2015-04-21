using UnityEngine;
using System.Collections;

public class TrackState : State {
	
	public float changeStateTime, changeStateTimer = 5f; //A very simple change state condition!
	
	public TrackState(GameObject myGameObject):base (myGameObject) //constructor that needs the same argument as the State base class constructor. use :base(GameObject) to inherit the same myGameObject reference, so this class can access the gameobject it's refereing to
	{
		
	}
	public override void Enter() //override runs over the base class abstract method of the same name (abstract methods can't handle functionality, they are only a blueprint)
	{
		//give our boids a seek target position
		myGameObject.GetComponent<SteeringBehaviours>().seekTargetPos = new Vector3(0, 0, 5000f); //assign the leader to the target 
		
		//This is where you toggle the steering behaviours ON!
		myGameObject.GetComponent<SteeringBehaviours>().seekEnabled = true;
		myGameObject.GetComponent<SteeringBehaviours>().seperationEnabled = true;
		myGameObject.GetComponent<SteeringBehaviours>().cohesionEnabled = true;
		myGameObject.GetComponent<SteeringBehaviours>().alignmentEnabled = true;
		Debug.Log("Boids are tracking a target!");
	}
	
	public override void Update() //override runs over the base class abstract method of the same name (abstract methods can't handle functionality, they are only a blueprint)
	{
		//This is where we calculate stuff, like the condition to transition to the next state
		changeStateTime += Time.deltaTime;
		if(changeStateTime >= changeStateTimer)
		{
			myGameObject.GetComponent<StateMachine>().SwitchState (new ChaseState(myGameObject));
		}	
	}
	
	public override void Exit() //override runs over the base class abstract method of the same name (abstract methods can't handle functionality, they are only a blueprint)
	{
		//this is where we turn off all steering behaviours, as the new state we transition to will enable only the ones it needs
		myGameObject.GetComponent<SteeringBehaviours>().TurnOffAll();
	}
}
