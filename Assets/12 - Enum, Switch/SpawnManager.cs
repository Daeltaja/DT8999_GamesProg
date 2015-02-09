using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

	public Object[] lootCommon;
	public Object[] lootRare;
	public Object[] enemiesCommon;
	public Object[] enemiesRare;
	
	public string lootCommonFolder;
	public string lootRareFolder;
	public string enemiesCommonFolder;
	public string enemiesRareFolder;
	
	int lootRareRoll = 90;
	int enemiesRareRoll = 90;

	// Use this for initialization
	void Awake () 
	{
		lootCommon = Resources.LoadAll(lootCommonFolder);
		lootRare = Resources.LoadAll (lootRareFolder);
		enemiesCommon = Resources.LoadAll (enemiesCommonFolder);
		enemiesRare = Resources.LoadAll (enemiesRareFolder);
	}
	
	public GameObject PickItem(int type, int roll)
	{
		GameObject whatToSpawn = null;
		switch(type)
		{
			case 0:
			if(roll > lootRareRoll)
			{
				whatToSpawn = lootRare[Random.Range (0, lootRare.Length)] as GameObject;
			}
			else
			{
				whatToSpawn = lootCommon[Random.Range (0, lootCommon.Length)] as GameObject;
			}
			break;
			case 1:
			if(roll > enemiesRareRoll)
			{
				whatToSpawn = enemiesRare[Random.Range (0, enemiesRare.Length)] as GameObject;
			}
			else
			{
				whatToSpawn = enemiesCommon[Random.Range (0, enemiesCommon.Length)] as GameObject;
			}
			break;
		}
		return whatToSpawn;
	}
}
