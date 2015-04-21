using UnityEngine;
using System.Collections;

public class WIJdia : MonoBehaviour {

	
	public Transform target;

	void Update () 
	{
		Vector3 toEntity = this.transform.position - target.position;
		float distance = toEntity.magnitude;
		toEntity.Normalize();
		print("Steering Force = " +"toEntity (" +toEntity +") divided by distance (" +distance + ") = " +toEntity/distance);
	}
	
	void Foo(ref int p)
	{
		p = p+1;
		print (p);
	}
	
	// Use this for initialization
	void Start () 
	{
		int x = 8;
		Foo (ref x); //make a copy of x
		print (x); //x = 9
	}
}
