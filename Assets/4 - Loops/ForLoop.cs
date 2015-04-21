using UnityEngine;
using System.Collections.Generic;

public class ForLoop : MonoBehaviour {

	int boxCount = 5;
	int boxNum = 0; //int to count the box numbers in order of creation
	public List<GameObject> boxes = new List<GameObject>(); //creates a new list of type Gameobject
	public float timer = 0.5f;
	int boxeys = 0;
	
	void Start () // Use this for initialization
	{
		for(int xPos = 0; xPos < boxCount; xPos++) //nested loop - the nested loop runs as many times as xPos < boxCount
		{
			for(int yPos = 0; yPos < boxCount; yPos++)
			{
				GameObject box = GameObject.CreatePrimitive(PrimitiveType.Cube);
				boxNum++;
				box.name = "Box"+boxNum;
				box.transform.localScale = new Vector3(1, 1, 1);
				box.transform.position = new Vector3(xPos, yPos, 0); //use the increasing x and y values from the loop declaration
				box.GetComponent<Renderer>().material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range (0.0f, 1.0f),Random.Range (0.0f, 1.0f), 255);
				boxes.Add (box); //adds the new box into the list
				Debug.Log (xPos + " / " +yPos);
			}
		}
		
		
		foreach(GameObject boxey in boxes)
		{
			
		}
	}
	
	void Update()
	{
		timer += Time.deltaTime;
		if(timer > .5)
		{
			
			boxeys++;
			Destroy(boxes[boxeys].gameObject);
			//boxes.Remove(boxes[boxeys]);
			timer = 0;
		}
		
	}
}
