using UnityEngine;
using System.Collections;

public class SwordOfDemonicPossession : Weapon {

	// Use this for initialization
	void Start () 
	{
		damage = 5;
	}
	
	// Update is called once per frame
	public void GiveMeStats (int dmg, int intel, int dex, int crit) 
	{
		damage = dmg;
		intelligence = intel;
		dexterity = dex;
		critChance = crit;
	}
}
