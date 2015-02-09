using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {

	public int whichAnswer;
	
	void  Start() 
	{
		switch(whichAnswer)
		{
			case 0:
				print("Wrong answer, you can't pass!");
				break;
			case 1:
				print("Erm, what you talking boot?");
				break;
			case 2:
				print ("Ok... you can pass!");
				break;
			default:
				print ("Im waiting on an answer...");
				break;
		}	
	}
}
