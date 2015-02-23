using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

	Transform turret,player;
	float shootTime, shootTimer = 0.3f;
	float searchTime, searchTimer = 4f;
	float randLookTime, randLookTimer = 0.3f;
	Ray ray;
	RaycastHit target;

	enum States //our states 
	{
		Initialize,
		Sleep,
		Attack,
		Searching,
	}
	
	States currentState = States.Initialize; //create an instance of the enum and set it's default to Initialize

	void Update () 
	{
		switch(currentState) //pass in the current state
		{
			case States.Initialize:
			Initilize();
			break;
			case States.Sleep:
			Sleep ();
			break;
			case States.Attack:
			Attack ();
			break;
			case States.Searching:
			Searching ();
			break;
		}
		Debug.DrawRay(turret.position, turret.transform.forward * 10f, Color.magenta);
		Debug.Log (currentState);
	}
	
	void Initilize()
	{
		turret = GameObject.Find ("GunPivot").transform;
		player = GameObject.FindWithTag("Player").transform;
		
		currentState = States.Sleep;
	}
	
	void Sleep()
	{
		searchTime = 0;
		if(DoRayCast())
		{
			if(target.transform.tag == "Player")
			{
				currentState = States.Attack;
			}
		}
	}	
	
	void Attack()
	{
		Vector3 lookAtPlayer = new Vector3( player.position.x, this.transform.position.y, player.position.z ) ; //create a vector to find the players x and z position
		turret.LookAt(lookAtPlayer); //lookat takes a vector3 position and converts it to the angle it needs to look at supplied position
		shootTime += Time.deltaTime;
		if(shootTime >= shootTimer)
		{
			shootTime = 0;
		}
		if(Vector3.Distance(turret.position, player.position) > 10f)
		{
			currentState = States.Searching;
		}
	}
	
	void Searching()
	{
		if(DoRayCast()) //checks to see if ray hits a collider using the bool return method
		{
			if(target.transform.tag == "Player") //check to see if player
			{
				currentState = States.Attack;
			}
		}
		searchTime+=Time.deltaTime;
		if(searchTime >= searchTimer)
		{
			currentState = States.Sleep;
		}
		randLookTime+=Time.deltaTime;
		if(randLookTime >= randLookTimer)
		{
			Vector3 randLook = new Vector3(turret.transform.position.x+Random.Range (-7, 7), 0, 0);
			turret.LookAt(randLook);
			randLookTime = 0;
		}
	}
	
	bool DoRayCast() //bool return type, returns true if ray hits a collider
	{
		ray = new Ray(turret.position, turret.transform.forward); //a new ray, which takes a start position and direction
		bool rayHit = Physics.Raycast(ray, out target, 10f); //raycast returns true or false
		return rayHit; //returns rayHit if true or false
	}
}	
	
