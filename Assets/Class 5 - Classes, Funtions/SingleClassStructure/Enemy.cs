using UnityEngine;
using System.Collections.Generic;

public class Enemy : MonoBehaviour {

	public static List<Transform> targets = new List<Transform>(); //new list
	
	void Start () 
	{
		for(int i = 0; i < 3; i++)
		{
			targets.Add(GameObject.Find ("Target"+i).transform); //access the list and add the gameobject with name Target and using i, which increments each loop
		}
	}
}
