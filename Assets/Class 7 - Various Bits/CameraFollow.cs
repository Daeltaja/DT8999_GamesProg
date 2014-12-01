using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform playerToFollow;
	public float yOffset = 1f;
	public float leftLimit, rightLimit, bottomLimit, topLimit;
	Transform myTransform;

	void Start () 
	{
		myTransform = this.transform;
	}
	
	void Update () 
	{	
		Vector3 clampPos;
		clampPos.x = Mathf.Clamp(playerToFollow.position.x, leftLimit, rightLimit);
		clampPos.y = Mathf.Clamp(playerToFollow.position.y + yOffset, bottomLimit, topLimit);
		clampPos.z = myTransform.position.z;
		transform.position = clampPos;
	}
}

