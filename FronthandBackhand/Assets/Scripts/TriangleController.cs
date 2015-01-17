using UnityEngine;
using System.Collections;

public class TriangleController : MonoBehaviour {

	public float MovementSpeed;
	private float _toMove;

	// Use this for initialization
	void Start () {
		_toMove = 0.0f;
	}

	// FixedUpdate is called once per physics-frame
	void FixedUpdate() {
		float maxMovement = MovementSpeed * Time.fixedDeltaTime;
		float willMove = Mathf.Clamp (Mathf.Abs (_toMove), 0, MovementSpeed) * Mathf.Sign (_toMove);
		this.transform.RotateAround (Vector3.zero, Vector3.forward, willMove);
		_toMove -= willMove;
	}
	
	// Update is called once per screen-frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			_toMove += 120.0f;
		}
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			_toMove -= 120.0f;
		}
	}
}
