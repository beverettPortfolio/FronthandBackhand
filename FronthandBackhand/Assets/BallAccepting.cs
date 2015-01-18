using UnityEngine;
using System.Collections;

public class BallAccepting : MonoBehaviour {

	public float ShrinkDuration;

	private float _createdTime;
	private Vector3 _initialScale;

	// Use this for initialization
	void Start () {
		_createdTime = Time.time;
		_initialScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		float elapsed = Time.time - _createdTime;
		float phase = Mathf.Clamp01(elapsed / ShrinkDuration);
		transform.localScale = Vector3.Lerp (_initialScale, Vector3.zero, phase);
		if(phase >= 1.0f) {
			Destroy (gameObject);
		}
	}
}
