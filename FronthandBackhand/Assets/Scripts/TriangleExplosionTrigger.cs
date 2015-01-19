using UnityEngine;
using System.Collections;

public class TriangleExplosionTrigger : MonoBehaviour {
	public BallControllerScript ballcontrol;
	public AudioSource explosionAudio;

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (ballcontrol.song.time == 0) {
			anim.SetTrigger ("Explode");
		}
	}

	void PlayExplodeSound() {
		explosionAudio.Play ();
	}

	void HideTriangle () {
		GetComponent<SpriteRenderer> ().enabled = false;
	}

	void ToMenu() {
		Application.LoadLevel ("Menu");
	}
}
