using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {

	public LayerMask enemies;
	
	void Start () 
	{
		Invoke ("Explode", 1f);
	}
	
	void Explode () 
	{
		Collider[] hitThings = Physics.OverlapSphere(transform.position, 3f, enemies);
		// 1 >> LayerMask.layerToName("Enemy") //alternate way to search for a layer directly
		for(int i = 0; i < hitThings.Length; i++)
		{
			Vector3 forceDir = hitThings[i].transform.position - this.transform.position;
			forceDir.Normalize();
			hitThings[i].GetComponent<Rigidbody>().AddForce(forceDir * 800f + Vector3.up * 1500f);
		}
		Destroy(this.gameObject);
	}
}
