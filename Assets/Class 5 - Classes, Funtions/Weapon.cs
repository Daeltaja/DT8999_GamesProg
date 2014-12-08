using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public int damage;
	public int intelligence;
	public int dexterity;
	public int critChance;

	// Use this for initialization
	void Start () 
	{
		GameObject sword = GameObject.CreatePrimitive(PrimitiveType.Cube);
		sword.AddComponent<SwordOfDemonicPossession>();
		SwordOfDemonicPossession swordScript = sword.GetComponent<SwordOfDemonicPossession>();
		swordScript.GiveMeStats(5, 6, 7, 8);
		sword.name = "Sword of Demonic Possession";
		
		GameObject sword2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		sword2.AddComponent<SwordOfDemonicPossession>();
		sword2.GetComponent<SwordOfDemonicPossession>().GiveMeStats(6, 3, 6, 1);
		sword2.name = "Sword of Demonic Possession Lite";
		
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
