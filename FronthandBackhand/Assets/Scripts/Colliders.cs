using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Colliders : MonoBehaviour {
	
	public GameObject redSensor;
	public GameObject greenSensor;
	public GameObject blueSensor;

	public ScoreSystem score;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private float CalcSqrDistance(GameObject sensor, Collider2D coll) {
		Vector2 sensorPosition = sensor.transform.position;
		Vector2 collPosition = coll.gameObject.transform.position;
		return (collPosition - sensorPosition).sqrMagnitude;
	}

	void OnTriggerEnter2D(Collider2D coll) {
		HashSet<string> ballTags = new HashSet<string> (new string[]{"RedBall", "GreenBall", "BlueBall"});

		if (ballTags.Contains(coll.gameObject.tag)) {
			Vector2 offset = coll.gameObject.transform.position - transform.position;
			float direction = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

			
			float redSqrDistance = CalcSqrDistance (redSensor, coll);
			float greenSqrDistance = CalcSqrDistance (greenSensor, coll);
			float blueSqrDistance = CalcSqrDistance (blueSensor, coll);

			string hitSide;

			if (redSqrDistance < greenSqrDistance && redSqrDistance < blueSqrDistance) {
				hitSide = "RedBall";
			}
			else if (greenSqrDistance <= blueSqrDistance) {
				hitSide = "GreenBall";
			}
			else {
				hitSide = "BlueBall";
			}

			if (hitSide == coll.gameObject.tag) {
				score.adjustScore(score.multiplier);
				score.increaseMultiplier(1);
			}
			else {
				score.resetMultiplier();
			}

			Destroy(coll.gameObject);
		}
	}
}
