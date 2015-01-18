using UnityEngine;
using System.Collections;

public class BackgroundShift : MonoBehaviour {

	public float BPM;
	public int TimeSignature;
	public AudioSource Song;

	
	public float SaturationStart;
	public float BrightnessStart;
	public float SaturationEnd;
	public float BrightnessEnd;

	private float _lastBeat;
	private float _lastHue;
	private float _hue;
	
	// Use this for initialization
	void Start () {
		_lastBeat = -100.0f;
		_lastHue = 0.0f;
		_hue = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		float beat = (BPM / 60.0f) * ((float)Song.timeSamples / (float)Song.clip.frequency);
		int iBeat = Mathf.FloorToInt (beat);
		int iLastBeat = Mathf.FloorToInt (_lastBeat);

		// if new measure
		if (iBeat / TimeSignature != iLastBeat / TimeSignature) {
			_lastHue = _hue;
			_hue += Random.Range(60.0f, 300.0f);
			_hue = Mathf.Repeat(_hue, 360.0f);
		}
		//float measurePhase = (beat - (iBeat / TimeSignature * TimeSignature)) / TimeSignature;
		float beatPhase = beat - iBeat;

		float h;
		if (iBeat % TimeSignature == 0) {
			h = Mathf.LerpAngle (_lastHue, _hue, beatPhase);
		}
		else {
			h = _hue;
		}

		h = Mathf.Repeat (h, 360.0f) / 360.0f;
		float s = Mathf.Lerp (SaturationStart, SaturationEnd, beatPhase);
		float b = Mathf.Lerp (BrightnessStart, BrightnessEnd, beatPhase);
		HSBColor hsbColor = new HSBColor (h, s, b);
		Color color = HSBColor.ToColor (hsbColor);

		Camera.main.backgroundColor = color;
		_lastBeat = beat;
	}
}
