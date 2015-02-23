using UnityEngine;
using System.Collections;

public class Enemie : MonoBehaviour {

	NavMeshAgent myNMA;
	Transform player;
	public Transform[] waypoints;
	public int waypointIndex = 0;
	public float waitTime, waitTimer = 1f;

	void Start () 
	{
		myNMA = transform.GetComponent<NavMeshAgent>();
		player = GameObject.FindWithTag("Player").transform;
		
		for(int i = 0; i < waypoints.Length; i++)
		{
			waypoints[i] = GameObject.Find ("Waypoint"+i).transform;
		}
	}
	
	void Update () 
	{
		myNMA.destination = waypoints[waypointIndex].position;
		if(myNMA.remainingDistance < myNMA.stoppingDistance)
		{
			waitTime += Time.deltaTime;
			if(waitTime >= waitTimer)
			{
				waypointIndex = (waypointIndex + 1) % 4;
				waitTime = 0;
			}
			//Application.LoadLevel(Application.loadedLevelName);
		}
	}
}
