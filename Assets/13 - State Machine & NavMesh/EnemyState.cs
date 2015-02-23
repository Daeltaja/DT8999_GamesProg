using UnityEngine;
using System.Collections;

public class EnemyState : MonoBehaviour {

	NavMeshAgent nma;
	
	public Transform[] waypoints;
	int waypointsIndex = 0;
	
	public float waitTimer = 1f;
	float waitTime;
	
	void Start()
	{
		nma = GetComponent<NavMeshAgent>();
	}
	
	void Update () 
	{
		Patrol();
	}
	
	void Patrol()
	{
		nma.destination = waypoints[waypointsIndex].position; //destination is a member of navmeshagent
		if(nma.remainingDistance < nma.stoppingDistance)
		{
			waitTime += Time.deltaTime;
			if(waitTime >= waitTimer)
			{
				//waypointIndex = (waypointIndex + 1) % 4; //does same thing as if structure below
				if(waypointsIndex == waypoints.Length - 1)
				{
					waypointsIndex = 0;
				}
				else
				{
					waypointsIndex++;
				}
				waitTime = 0f;
			}
		}
	}
}
