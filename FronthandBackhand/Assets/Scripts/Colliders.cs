﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Colliders : MonoBehaviour {
	
	public GameObject redSensor;
	public GameObject greenSensor;
	public GameObject blueSensor;

	public GameObject ballExplodePrefab;
	public GameObject ballAcceptingPrefab;

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

			GameObject ballEndPrefab;

			// if correct
			if (hitSide == coll.gameObject.tag) {
				score.adjustScore(score.multiplier);
				score.increaseMultiplier(1);
				ballEndPrefab = ballAcceptingPrefab;
			}
			else {
				score.resetMultiplier();
				ballEndPrefab = ballExplodePrefab;
			}
			
			GameObject ballEnd = Instantiate(ballEndPrefab, coll.gameObject.transform.position, coll.gameObject.transform.rotation) as GameObject;
			ballEnd.GetComponent<SpriteRenderer>().color = coll.gameObject.GetComponent<SpriteRenderer>().color;

			Destroy(coll.gameObject);
		}
	}
}
