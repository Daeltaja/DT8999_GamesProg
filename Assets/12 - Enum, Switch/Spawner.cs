using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public enum SpawnType 
	{
		loot,
		enemy
	}
	public SpawnType whatIAm;

	void Start () 
	{
		SpawnManager sm = GameObject.Find ("SpawnManager").GetComponent<SpawnManager>();
		GameObject itemToSpawn = sm.PickItem(whatIAm.GetHashCode(), Random.Range (0, 101));
		
		if(itemToSpawn != null)
		{
			GameObject spawnedItem = (GameObject)Instantiate(itemToSpawn, transform.position, transform.rotation);
		}
		Destroy(this.gameObject);	
	}
}
