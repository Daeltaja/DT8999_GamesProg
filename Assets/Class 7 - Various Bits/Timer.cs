using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		Invoke ("ChangeColor", 1f);
		InvokeRepeating("ChangePosition", 0f, Random.Range (0.2f, 1f));
		//CancelInvoke("ChangePosition");
		StartCoroutine("PingPongColor");
		//StopCoroutine("PingPongColor");
	}
	
	void ChangePosition()
	{
		transform.position += new Vector3(1, 0, 0);
	}
	
	void ChangeColor()
	{
		renderer.material.color = Color.red;
	}
	
	IEnumerator PingPongColor()
	{
		renderer.material.color = Color.red;
		yield return new WaitForSeconds(.2f);
		renderer.material.color = Color.white;
		yield return new WaitForSeconds(.2f);
		renderer.material.color = Color.red;
		yield return new WaitForSeconds(.2f);
		renderer.material.color = Color.white;
		yield return new WaitForSeconds(.2f);
		renderer.material.color = Color.red;
		yield return new WaitForSeconds(.2f);
		renderer.material.color = Color.white;
		yield return new WaitForSeconds(.2f);
		renderer.material.color = Color.red;
		yield return new WaitForSeconds(.2f);
		renderer.material.color = Color.white;
		yield return new WaitForSeconds(.2f);
		renderer.material.color = Color.red;
	}
}
