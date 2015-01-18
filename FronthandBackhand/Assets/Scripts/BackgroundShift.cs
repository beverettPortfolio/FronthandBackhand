using UnityEngine;
using System.Collections;

public class BackgroundShift : MonoBehaviour {

	public MusicSync Music;
	
	public float SaturationStart;
	public float BrightnessStart;
	public float SaturationEnd;
	public float BrightnessEnd;

	private int _lastIMeasure;
	private float _lastHue;
	private float _hue;
	
	// Use this for initialization
	void Start () {
		_lastIMeasure = -1;
		_lastHue = 0.0f;
		_hue = 0.0f;
	}

	private void ChangeHue() {
			_lastHue = _hue;
			_hue += Random.Range(60.0f, 300.0f);
			_hue = Mathf.Repeat(_hue, 360.0f);
	}
	
	// Update is called once per frame
	void Update () {
		if(_lastIMeasure != Music.IMeasure) {
			_lastIMeasure = Music.IMeasure;
			ChangeHue ();
		}

		float h;
		if (Music.IBeat % Music.TimeSignature == 0) {
			h = Mathf.LerpAngle (_lastHue, _hue, Music.BeatPhase);
		}
		else {
			h = _hue;
		}

		h = Mathf.Repeat (h, 360.0f) / 360.0f;
		float s = Mathf.Lerp (SaturationStart, SaturationEnd, Music.BeatPhase);
		float b = Mathf.Lerp (BrightnessStart, BrightnessEnd, Music.BeatPhase);
		HSBColor hsbColor = new HSBColor (h, s, b);
		Color color = HSBColor.ToColor (hsbColor);

		Camera.main.backgroundColor = color;
	}
}
