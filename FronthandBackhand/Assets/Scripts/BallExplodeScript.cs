using UnityEngine;
using System.Collections;

public class BallExplodeScript : MonoBehaviour {

	public float LifeDuration;
	public float RandomRange;
	public float PitchMin;
	public float PitchMax;

	// Use this for initialization
	void Start () {
		//transform.localPosition = transform.localPosition + new Vector3 (Random.Range (-RandomRange, RandomRange), Random.Range (-RandomRange, RandomRange));
		float angleRad = Mathf.Atan2 (-transform.position.y, -transform.position.x);
		angleRad += Random.Range (-RandomRange * Mathf.Deg2Rad, RandomRange * Mathf.Deg2Rad);
		Vector2 goalPosition = new Vector2 (Mathf.Cos (angleRad), Mathf.Sin (angleRad)) * 10000000.0f;
		gameObject.GetComponent<BallMovement> ().GoalPosition = goalPosition;

		GetComponent<AudioSource> ().pitch = Random.Range (PitchMin, PitchMax);

		Destroy (gameObject, LifeDuration);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
