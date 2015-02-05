using UnityEngine;
using System.Collections;

public class Loopies : MonoBehaviour {

	int age = 30;
	bool alive	;
	GameObject[] enemies;
	
	void Start () 
	{
		for(int x = 0; x < 2; x++)
		{ 
			for(int y = 0; y < 2; y++)
			{
				Debug.Log ("I looped once!");
			}
		}
		/*while(age > 10)
		{
			Debug.Log ("I am de-aging");
			age--;
		}
		do
		{
			Debug.Log("Do something");
		}
		while(alive);
		
		foreach(GameObject enemy in enemies)
		{
			enemy.AddComponent<MeshCollider>();
		}	*/
	}
}
