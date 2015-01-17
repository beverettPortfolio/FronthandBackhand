using UnityEngine;
using System.Collections;

public class ScoreSystem : MonoBehaviour {
	public int currentScore;
	public int highscore;
	public int multiplier;
	public GUIText scoreText;
	public GUIText multiplierText;
	
	
	// Use this for initialization
	void Start () {
		currentScore = 0;
		highscore = 0;
		multiplier = 0;
	}
	
	void resetMultiplier() {
		multiplier = 0;
	}
	
	void adjustScore( int score ) {
		currentScore += score;
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = "Score: " + currentScore;
		multiplierText.text = "Multiplier: " + multiplier;
	}
}
