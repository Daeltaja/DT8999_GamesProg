using UnityEngine;
using System.Collections;

public class Interactions : MonoBehaviour {

	public bool hasBlueKey;
	public bool hasRedKey;
	
	// Update is called once per frame
	void Update () 
	{
		Interact();
	}
	
	void Interact()
	{
		if(Input.GetKeyDown (KeyCode.E))
		{
			RaycastHit hit;
			if(Physics.Raycast(transform.position, transform.forward, out hit, 2f))
			{
				if(hit.collider.GetComponent<Keycards>() != null)
				{
					if(hit.collider.GetComponent<Keycards>().whatColourAmI == Keycards.KeyColours.blueKey)
					{
						hasBlueKey = true;
						Destroy(hit.collider.gameObject);
					}
					if(hit.collider.GetComponent<Keycards>().whatColourAmI == Keycards.KeyColours.redKey)
					{
						hasRedKey = true;
						Destroy(hit.collider.gameObject);
					}
				}
				
				if(hit.collider.name == "DoorRed")
				{
					if(hasRedKey)
					{
						Destroy(hit.collider.gameObject);
					}
					else
					{
						print("Feck off and find the key!");
					}
				}
			}
		}
	}
}
