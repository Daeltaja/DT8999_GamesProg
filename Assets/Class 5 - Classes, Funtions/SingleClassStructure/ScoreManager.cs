using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	public int score = 0;
	
	public void AdjustScore(int adj)
	{
		score += adj;
		Debug.Log (score);
	}
}
