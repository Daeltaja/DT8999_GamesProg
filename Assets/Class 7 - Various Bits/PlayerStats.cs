using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	public int currentHealth = 100, maxHealth = 100;
	public float currentMana = 50, maxMana = 50;
	public static int lives = 3;
	public bool useMana;
	public bool autoRechargeMana;
	public float manaRechargeRate = 1;
	public float currentScore;
	
	public void ChangeHealth(int adjust)
	{
		currentHealth += adjust;
		if(currentHealth >= maxHealth)
		{
			currentHealth = maxHealth;
		}
		else if(currentHealth <= 0)
		{
			currentHealth = 0;
			if(lives <= 0)
			{
				lives = 3; //game over, so reset the lives to 3
				Application.LoadLevel(Application.loadedLevelName); //load the same level again
			}
			lives--;
			Application.LoadLevel(Application.loadedLevelName);
		}
	}
	
	public void ChangeMana(int adjust)
	{
		currentMana += adjust;
		if(currentMana >= maxMana)
		{
			currentMana = maxMana;
		}
		if(currentMana <= 0)
		{
			currentMana = 0;
		}
	}
	
	public void ChangeScore(int adjust)
	{
		currentScore += adjust;
	}
	
	void Update ()
	{
		if(useMana)
		{
			if(autoRechargeMana) //if you want autorecharging mana, tick this on in the inspector
			{
				currentMana += Time.deltaTime * manaRechargeRate; //change manaRechargeRate if you want mana to regenerate faster. In seconds.
				if(currentMana >= maxMana)
				{
					currentMana = maxMana;
				}
			}
		}
	}
}
