using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	GameObject bullet; //empty container for our bullet gameobject
	Inventory inventory;
	
	void Start()
	{
		inventory = GetComponent<Inventory>();
	}
	
	void Update () 
	{
		if(Input.GetKeyDown (KeyCode.Space))
		{
			if(inventory.ammoCount > 0)
			{
				FireBullet(); //call the firebullet function
			}
			else
			{
				Debug.Log ("Out of ammo!");
			}
		}
		if(bullet) //if there is a bullet
		Physics.IgnoreCollision(bullet.collider, collider); //tell two colliders to ignore each other
	}
	
	void FireBullet()
	{
		bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		bullet.transform.localScale = new Vector3(.5f, .5f, .5f);
		bullet.renderer.material.color = Color.red;
		bullet.transform.position = this.transform.position;
		bullet.AddComponent<Bullet>(); //add rigidbody component
		bullet.AddComponent<Rigidbody>(); //add rigidbody component
		bullet.rigidbody.useGravity = false; //turn of gravity on the rigidbody
		bullet.rigidbody.AddForce(transform.up * 600f); //add force to the bullet
		inventory.AdjustAmmo(-1);
	}
}
