using UnityEngine;
using System.Collections;

public class TriangleExplosionTrigger : MonoBehaviour {
	public BallControllerScript ballcontrol;

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

	void ToMenu() {
		Application.LoadLevel ("Menu");
	}
}
