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
		for(int i = 0; i < Enemies.enemies.Count; i++) //access the targets list in Enemy script and check the count, basically how many target transforms are in the list
		{
			GameObject tar = Enemies.enemies[i].gameObject; //create local instance of the target with each loop
			float distance = (transform.position - tar.transform.position).magnitude; //create a float to store the distance between 2 positions (vectors)
			if(distance < 0.5f)
			{
				ScoreManager.score += 10 ;//add 10 to our score
				Debug.Log (ScoreManager.score);
				Destroy(gameObject);
			}
		}
	}
}
