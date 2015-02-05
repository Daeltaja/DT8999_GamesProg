using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {

	public int ammoCount = 10;
	
	public void AdjustAmmo(int adj)
	{
		ammoCount += adj; //adjust ammountCount by the pass amount
		Debug.Log (ammoCount);
	}
}
