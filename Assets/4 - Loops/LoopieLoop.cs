using UnityEngine;
using System.Collections.Generic;

public class LoopieLoop : MonoBehaviour {

	public List<GameObject> targets = new List<GameObject>();
	public GameObject[] things;
	void Start () 
	{
		for(int i = 0; i < 3; i++)
		{
			Debug.Log ("Loop number "+i);
			targets.Add(GameObject.Find ("EnemyHolder"+i));
		}
		
		
		
		
		
		
		
		for(int e = 0; e < 3; e++)
		{
			GameObject orcBody = GameObject.CreatePrimitive(PrimitiveType.Cube);
			GameObject orcHead = GameObject.CreatePrimitive(PrimitiveType.Cube);
			orcBody.transform.localScale = new Vector3(1, 2, 1);
			orcHead.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
			orcHead.transform.parent = orcBody.transform;
			orcBody.transform.position = new Vector3(e * 1.5f, 0, 0);
			orcHead.transform.localPosition = new Vector3(0, 0.7f, 0);
		}
		
		
		
		
		
		
		for(int p = 0; p < 2; p++)
		{
			int roll = Random.Range (0, 4);
			GameObject enemyToMove = targets[0].transform.GetChild(roll).gameObject;
			enemyToMove.transform.parent = targets[1].transform;
		}	
	}
		
}
