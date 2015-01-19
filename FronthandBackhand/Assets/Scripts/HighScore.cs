using UnityEngine;
using System.Collections;

public class HighScore : MonoBehaviour {
	public int highscore;
	// Use this for initialization
	void Start () {
		highscore = PlayerPrefs.GetInt("High Score");
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnGUI(){
		GUIStyle style = new GUIStyle ();
		style.fontSize = 30;
		style.normal.textColor = Color.white;
		style.alignment = TextAnchor.MiddleCenter;
		GUI.skin.label.alignment = TextAnchor.MiddleCenter;
		GUI.backgroundColor = new Color(1,1,1,0.5f);
		GUI.Label (new Rect (Screen.width/2 - 100, Screen.height - 50, 200, 30), "Highscore: " + highscore, style);
	}
}
