using UnityEngine;
using System.Collections;

public class MusicSync : MonoBehaviour {

	public float BPM;
	public int TimeSignature;
	public AudioSource Song;

	public float Beat {
		get { return (BPM / 60.0f) * ((float)Song.timeSamples / (float)Song.clip.frequency); }
	}

	public int IBeat {
		get { return Mathf.FloorToInt (Beat); }
	}

	public float BeatPhase {
		get { return Beat - IBeat; }
	}

	public float Measure {
		get { return Beat / TimeSignature; }
	}

	public int IMeasure {
		get { return Mathf.FloorToInt (Measure); }
	}

	public float MeasurePhase {
		get { return Measure / TimeSignature; }
	}
}
