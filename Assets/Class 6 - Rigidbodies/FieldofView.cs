using UnityEngine;
using System.Collections;

public class FieldofView : MonoBehaviour {

	public Transform other;
	void Update() {
		if (other) {
			Vector3 forward = transform.TransformDirection(transform.up);
			Vector3 toOther = other.position - transform.position;
			//float dot = Vector3.Dot(forward, toOther);
		//	print (dot);
			/*if (dot < 0)
			{
				print ("Behind");
			}
			else if(dot > 0)
			{
				print ("In Front");
			}
				//print("The other transform is behind me!");
				*/
				
				//use unity example
			Vector3 a = new Vector3(1, 2, 3); //compare vector a with vector b
			Vector3 b = new Vector3(2, 4, 3);
			float dot = (1*2)+(2*4)+(3*3); //the DOT is the result of 2 vectors magnitudes multiplied by each other
			
			
			Debug.Log(dot);
		}
	}
}
