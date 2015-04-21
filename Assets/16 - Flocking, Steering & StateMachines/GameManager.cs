using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	GameObject[] boids;
	GameObject leader;

	void Start () 
	{
		leader = GameObject.Find ("Leader");
		FindBoids();
		GiveBoidsStartState();
	}
	
	void FindBoids()
	{
		boids = GameObject.FindGameObjectsWithTag("Boid");
	}
	
	void GiveBoidsStartState()
	{
		foreach(GameObject boid in boids)
		{
			boid.GetComponent<StateMachine>().SwitchState (new ChaseState(boid));
		}
		leader.GetComponent<StateMachine>().SwitchState (new PatrolState(leader));
	}
}
