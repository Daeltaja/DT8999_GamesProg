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
		Physics.IgnoreCollision(bullet.GetComponent<Collider>(), GetComponent<Collider>()); //tell two colliders to ignore each other
	}
	
	void FireBullet()
	{
		bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		bullet.transform.localScale = new Vector3(.5f, .5f, .5f);
		bullet.GetComponent<Renderer>().material.color = Color.red;
		bullet.transform.position = this.transform.position;
		bullet.AddComponent<Bullet>(); //add rigidbody component
		bullet.AddComponent<Rigidbody>(); //add rigidbody component
		bullet.GetComponent<Rigidbody>().useGravity = false; //turn of gravity on the rigidbody
		bullet.GetComponent<Rigidbody>().AddForce(transform.up * 600f); //add force to the bullet
		inventory.AdjustAmmo(-1);
	}
}
