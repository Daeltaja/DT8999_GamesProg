using UnityEngine;
using System.Collections;

public class DistanceThingy : MonoBehaviour {

	Vector3 myPos, targetPos;
	Transform myTransform;
	public Transform target;
	
	void Start()
	{
		target = GameObject.Find ("Target").transform;
		myTransform = this.transform;
	}
	
	void Update () 
	{
		if(target != null)
		{
			myPos = myTransform.position;
			targetPos = target.position;
			if(Vector3.Distance (myPos, targetPos) < 0.5f)
			{
				Destroy(target.transform.gameObject);
			}
		}	
		else
		{
			if(GameObject.Find ("Target"))
			target = GameObject.Find ("Target").transform;
		}
	}
}
