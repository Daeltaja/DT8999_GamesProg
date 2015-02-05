using UnityEngine;
using System.Collections;

public class LightChallenge : MonoBehaviour {
	
	//these are the numbers we will check our spotlights position against
	public float redRange = -1f, blueRange = 1; //to check the lights position against
	
	// Update is called once per frame
	public void Update () 
	{
		if(transform.position.x < redRange) //if the spotlights x position is less than redRange
		{
			light.color = Color.red; //change light color to red
		}
		//if not the above and if our lights x position is greater than redRange and less than blueRange
		else if(transform.position.x > redRange && transform.position.x < blueRange)	
		{
			light.color = Color.green; //change light color to green
		}
		else //if it's neither of the above
		{
			light.color = Color.blue; //change light color to green
		}
	}
}
