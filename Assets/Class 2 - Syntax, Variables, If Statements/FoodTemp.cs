using UnityEngine;
using System.Collections;

public class FoodTemp : MonoBehaviour {

	public float currentTemp = 80f, tooCold = 30f, tooHot = 70f;
	
	// Update is called once per frame
	void Update () 
	{
		currentTemp -= Time.deltaTime; //We are using Time.deltaTime to decrement currentTemp by 1 once a second
		
		if(currentTemp > tooHot) //if currentTemp is greater than our variable tooHot
		{
			renderer.material.color = Color.red; //change the color, which belongs in the renderer, to red
			Debug.Log("Too Hot");
		}
		//else if its not greater than too hot, if currentTemp is less than tooCold
		else if(currentTemp < tooCold)
		{
			renderer.material.color = Color.blue; //change the color, which belongs in the renderer, to blue
			Debug.Log ("Too Cold");
		}
		else //otherwise if it's neither do this
		{
			renderer.material.color = Color.green; 	//change the color, which belongs in the renderer, to blue
			Debug.Log("Just Right");
		}
	}
}
