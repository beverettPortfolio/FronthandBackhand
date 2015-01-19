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

	public float scoreBarLength;
	public float scoreBarLength2;
	public float scoreBarLength3;
	public float scoreBarLength4;
	public float scoreBarMax;
	public float xPosition;
	public float yPosition;


	// Use this for initialization
	void Start () {
		currentScore = 0;
		multiplier = 1;
		highscore = PlayerPrefs.GetInt("High Score");
		scoreBarLength = 100;
		scoreBarLength2 = 100;
		scoreBarLength3 = 100;
		scoreBarLength4 = 100;
		scoreBarMax = Screen.width - 100;
		xPosition = Screen.width / 2;
		yPosition = Screen.height - 50;
	}

	public void resetMultiplier() {
		multiplier = 1;
		Camera.main.GetComponent<CameraShakeScript>().shakeAmount = .5f;
		Camera.main.GetComponent<CameraShakeScript>().shake = .5f;
	}

	public void increaseMultiplier(int inc) {
		multiplier+= inc;
	}

	public void adjustScore( int score ) {
		currentScore += score;

		if (scoreBarLength < scoreBarMax) {
			scoreBarLength += currentScore/50;
		}
		if (scoreBarLength >= scoreBarMax) {
			scoreBarLength = scoreBarMax;
			if(scoreBarLength2 < scoreBarMax){
				scoreBarLength2 += currentScore/50;
			}
			if (scoreBarLength2 >= scoreBarMax) {
				scoreBarLength2 = scoreBarMax;
				if (scoreBarLength3 < scoreBarMax) {
					scoreBarLength3 += currentScore/50;
				}
				if (scoreBarLength3 >= scoreBarMax) {
					scoreBarLength3 = scoreBarMax;
					if (scoreBarLength4 < scoreBarMax) {
						scoreBarLength4 += currentScore/50;
					}
					if (scoreBarLength4 >= scoreBarMax) {
						scoreBarLength4 = scoreBarMax;
					}
				}
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
		//scoreText.text = "Score" + currentScore;
		multiplierText.text = "Multiplier: x" + multiplier;
		if (currentScore > highscore) {
			highscore = currentScore;	
			PlayerPrefs.SetInt("High Score", highscore);
		}

		highscoreText.text = "High Score: " + highscore;
	}

	void OnGUI(){
		GUI.backgroundColor = new Color(1,1,1,0.5f);
		GUI.Box (new Rect (xPosition - scoreBarLength/2, yPosition, scoreBarLength, 30), "");
		GUI.Box (new Rect (xPosition - scoreBarLength2/2, yPosition, scoreBarLength2, 30), "");
		GUI.Box (new Rect (xPosition - scoreBarLength3/2, yPosition, scoreBarLength3, 30), "");
		GUI.Box (new Rect (xPosition - scoreBarLength4/2, yPosition, scoreBarLength4, 30), "Score: " + currentScore);
	}
}
