using UnityEngine;
using System.Collections.Generic;

public class Bullet : MonoBehaviour {

	ScoreManager sm;
	
	void Start () 
	{
		sm = GameObject.Find("Player").transform.GetComponent<ScoreManager>(); //store the component in a variable
	}
	
	void Update () 
	{
		for(int d = 0; d < Enemy.targets.Count; d++) //access the targets list in Enemy script and check the count, basically how many target transforms are in the list
		{
			GameObject tar = Enemy.targets[d].gameObject; //create local instance of the target with each loop
			float distance = (transform.position - tar.transform.position).magnitude; //create a float to store the distance between 2 positions (vectors)
			if(distance < 0.5f)
			{
				sm.AdjustScore(5); //add 5 to our score
				Enemy.targets.Remove (tar.transform); //remove the hit target from list
				Destroy (tar.transform.gameObject);
				Destroy(gameObject);
			}
		}
	}
}
