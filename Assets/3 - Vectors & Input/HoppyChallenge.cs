using UnityEngine;
using System.Collections;

public class HoppyChallenge : MonoBehaviour {

	Vector3 hop = new Vector3(2, 0, 0);

	void Update () 
	{
		if(Input.GetKeyDown (KeyCode.Space))
		{
			transform.position+=hop;
		}
		if(transform.position.x >=6)
		{
			hop = new Vector3(-2, 0, 0);
		}
		else if(transform.position.x <= -6)
		{
			hop = new Vector3(2, 0, 0);
		}
	}
}
