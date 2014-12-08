using UnityEngine;
using System.Collections;

public class EnemyStats : MonoBehaviour {

	int health = 50;
	
	public void TakeDamage(int adjust)
	{
		health -= adjust;
		if(health <= 0)
		{
			Destroy(this.gameObject);
		}
	}
	
}
