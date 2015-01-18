using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour {
	public int currentScore;
	public int highscore;
	public int multiplier;

	public GUIText scoreText;
	public GUIText multiplierText;
	public GUIText highscoreText;
	
	
	// Use this for initialization
	void Start () {
		currentScore = 0;
		highscore = 0;
		multiplier = 1;
	}

	public void resetMultiplier() {
		multiplier = 1;
	}

	public void increaseMultiplier(int inc) {
		multiplier+= inc;
	}

	public void adjustScore( int score ) {
		currentScore += score;
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = "Score: " + currentScore;
		multiplierText.text = "Multiplier: " + multiplier;
		if (currentScore > highscore) {
			highscore = currentScore;	
			PlayerPrefs.SetInt("High Score", highscore);
		}

		highscoreText.text = "High Score: " + highscore;
	}
}
