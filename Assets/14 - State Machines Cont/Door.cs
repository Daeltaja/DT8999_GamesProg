using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	void Start () 
	{
		Transform player = GameObject.FindWithTag("Player").transform;
		this.gameObject.GetComponent<StateMachine>().SwitchState(new DoorClosed(this.gameObject, player)); //call SwitchState and create a new state for it, passing over the constructor argument
	}
}
