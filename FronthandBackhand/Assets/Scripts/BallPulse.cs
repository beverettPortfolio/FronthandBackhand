using UnityEngine;
using System.Collections;

public class BallPulse : MonoBehaviour {

	public float BaseScale;
	public float GrowAmountUp;
	public float GrowAmountDown;
	private MusicSync _music;

	private Vector3 _initialScale;

	// Use this for initialization
	void Start () {
		_initialScale = transform.localScale;
		_music = Camera.main.GetComponent<MusicSync> ();
	}
	
	// Update is called once per frame
	void Update () {
		int beatNo = _music.IBeat % _music.TimeSignature;
		float growAmount = (beatNo % 2 == 1) ? GrowAmountDown : GrowAmountUp;
	
		float scaleAmount = Mathf.Lerp (growAmount, BaseScale, 2.0f * Mathf.Abs (0.5f - Mathf.Sqrt(_music.BeatPhase)));
		transform.localScale = _initialScale * scaleAmount;
		GetComponent<SpriteRenderer> ().color = Camera.main.backgroundColor;
	}
}
