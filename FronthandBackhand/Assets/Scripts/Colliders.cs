using UnityEngine;
using System.Collections;

public class Colliders : MonoBehaviour {
	public enum ColliderColor{RED, BLUE, GREEN};
	
	public ColliderColor colliderColor;
	public ScoreSystem score;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D coll) {
		switch(colliderColor) {

		case ColliderColor.RED:
			if (coll.gameObject.CompareTag("RedBall")) {
				//Debug.Log("Redball hit");
				score.adjustScore(score.multiplier);
				score.increaseMultiplier(1);
			}
			else if (coll.gameObject.CompareTag("GreenBall"))
				score.resetMultiplier();			
			else if (coll.gameObject.CompareTag("BlueBall"))
				score.resetMultiplier();
			break;

		case ColliderColor.GREEN:
			if (coll.gameObject.CompareTag("RedBall"))
				score.resetMultiplier();
			else if (coll.gameObject.CompareTag("GreenBall")) {
				score.adjustScore(score.multiplier);
				score.increaseMultiplier(1);
			}
			else if (coll.gameObject.CompareTag("BlueBall"))
				score.resetMultiplier();
			break;

		case ColliderColor.BLUE:
			if (coll.gameObject.CompareTag("RedBall"))
				score.resetMultiplier();
			else if (coll.gameObject.CompareTag("GreenBall"))
				score.resetMultiplier();
			else if (coll.gameObject.CompareTag("BlueBall")) {
				score.adjustScore(score.multiplier);
				score.increaseMultiplier(1);
			}
			break;

		default:
			break;
		};
		DestroyBall (coll.gameObject);
	}

	void DestroyBall (GameObject ball) {
		if (ball != null)
			Destroy (ball);
	}
}
