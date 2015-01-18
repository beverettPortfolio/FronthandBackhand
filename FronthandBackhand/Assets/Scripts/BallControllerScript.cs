using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

public class BallControllerScript : MonoBehaviour {
	public int BPM;
	public AudioSource song;
	public TextAsset beatMap;
	public GameObject ballPrefab;

	private List<double[]> beatMapLeft;
	private List<double[]> beatMapRight;
	private int leftIndex;
	private int rightIndex;
	private GameObject currentBeat;

	// Use this for initialization
	void Start () {
		leftIndex = 0;
		rightIndex = 0;
		beatMapLeft = new List<double[]> ();
		beatMapRight = new List<double[]> ();
		readBeatMap ();
	}
	
	// Update is called once per frame
	void Update () {
		if (leftIndex < beatMapLeft.Count) {		
			double leftTime = beatMapLeft[leftIndex][0]/(BPM/60)*song.clip.frequency;
			if (song.timeSamples>=leftTime){
				createBall("l",beatMapLeft[leftIndex][1]);
				leftIndex++;
			}
		}
		if (rightIndex < beatMapRight.Count) {
			double rightTime = beatMapRight[rightIndex][0]/(BPM/60)*song.clip.frequency;
			if (song.timeSamples>=rightTime){
				createBall("r",beatMapRight[rightIndex][1]);
				rightIndex++;
			}
		}
	}

	void readBeatMap(){
		StringReader stream = new StringReader (beatMap.text);
		string line;
		while ((line=stream.ReadLine()) != null) {
			string[] beat=line.Split ('/');
			if (beat[0].Equals("l")){
				beatMapLeft.Add (new double[2] {Convert.ToDouble(beat[1]),Convert.ToDouble(beat[2])});
			}
			else if (beat[0].Equals("r")){
				beatMapRight.Add (new double[2] {Convert.ToDouble(beat[1]),Convert.ToDouble(beat[2])});
			}
		}
	}

	void createBall(string side, double colorCode){
		if (side.Equals ("l")) {
			currentBeat = Instantiate (ballPrefab, transform.position, transform.rotation) as GameObject;
		} 
		else if (side.Equals ("r")) {
			currentBeat = Instantiate (ballPrefab, transform.position, transform.rotation) as GameObject;
		}
	}
}
