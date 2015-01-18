using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour {

	public float Speed;

	// Use this for initialization
	void Start () {
	}

	void FixedUpdate () {
		Vector3 position = transform.position;
		position -= position.normalized * Speed;
		transform.position = position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
