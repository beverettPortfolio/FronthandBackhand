using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

/// <summary>
/// A class that spawns the balls for the level based on a separate level data file.
/// More levels can easily be added by creating more level text files.
/// </summary>
public class BallControllerScript : MonoBehaviour {
    public int BPM;
    public AudioSource song;
    public TextAsset beatMap;
    public GameObject ballPrefab;
    public Vector2 leftPosition;
    public Vector2 rightPosition;

    private List<double[]> beatMapLeft;
    private List<double[]> beatMapRight;
    private int leftIndex;
    private int rightIndex;
    private GameObject currentBeat;

    private Color[] colorCodeColors;
    private String[] colorCodeTags;

    // Use this for initialization
    void Start() {
        leftIndex = 0;
        rightIndex = 0;
        beatMapLeft = new List<double[]>();
        beatMapRight = new List<double[]>();
        readBeatMap();
        colorCodeColors = new Color[] { Color.red, Color.green, Color.blue };
        colorCodeTags = new String[] { "RedBall", "GreenBall", "BlueBall" };
    }

    // FixedUpdate is called once per physics-frame
    void FixedUpdate() {
        if (leftIndex < beatMapLeft.Count) {
            double leftTime = beatMapLeft[leftIndex][0] / (BPM / 60) * song.clip.frequency;
            if (song.timeSamples >= leftTime) {
                createBall("l", beatMapLeft[leftIndex][1]);
                leftIndex++;
            }
        }
        if (rightIndex < beatMapRight.Count) {
            double rightTime = beatMapRight[rightIndex][0] / (BPM / 60) * song.clip.frequency;
            if (song.timeSamples >= rightTime) {
                createBall("r", beatMapRight[rightIndex][1]);
                rightIndex++;
            }
        }
    }

    /// <summary>
    /// Reads the data file for a level and creates two lists to represent the balls in the level.
    /// Each line in the file should be in the format "l/0/0".
    /// The first character in the line represents whether the ball spawns on the left or right side.
    /// The second character represents what beat the ball spawns on.
    /// The third character represents the color of the ball
    /// The lines in the file should be in order from earliest beat to latest.
    /// </summary>
	void readBeatMap() {
        StringReader stream = new StringReader(beatMap.text);
        string line;
        while ((line = stream.ReadLine()) != null) {
            string[] beat = line.Split('/');
            if (beat[0].Equals("l")) {
                beatMapLeft.Add(new double[2] { Convert.ToDouble(beat[1]), Convert.ToDouble(beat[2]) });
            }
            else if (beat[0].Equals("r")) {
                beatMapRight.Add(new double[2] { Convert.ToDouble(beat[1]), Convert.ToDouble(beat[2]) });
            }
        }
    }

    /// <summary>
    /// Creates a ball GameObject and sets its color.
    /// </summary>
    /// <param name="side">The side the ball will spawn on.</param>
    /// <param name="colorCode">A number representing the ball's color.</param>
	void createBall(string side, double colorCode) {
        Vector2 position = side.Equals("l") ? leftPosition : rightPosition;
        currentBeat = Instantiate(ballPrefab, position, Quaternion.identity) as GameObject;
        int iColorCode = Convert.ToInt32(colorCode);
        currentBeat.GetComponent<SpriteRenderer>().color = colorCodeColors[iColorCode];
        currentBeat.tag = colorCodeTags[iColorCode];
    }
}
