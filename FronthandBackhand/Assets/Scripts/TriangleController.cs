using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TriangleController : MonoBehaviour {
	public float RotationDuration;

	private Quaternion _oldRotation;
	private float _oldFixedTime;
	
	private enum TrianglePoint {
		RedBlue = 1,
		BlueGreen = 2,
		GreenRed = 3,

		BlueRed = -1,
		GreenBlue = -2,
		RedGreen = -3
	};

	private Dictionary<TrianglePoint, Quaternion> _rotations;

	private TrianglePoint _currentTop;

	// Use this for initialization
	void Start () {
		_currentTop = TrianglePoint.RedBlue;
		_oldRotation = transform.localRotation;
		_oldFixedTime = float.NegativeInfinity;
		_rotations = new Dictionary<TrianglePoint, Quaternion> ();

		_rotations [TrianglePoint.RedBlue] = transform.localRotation;

		transform.RotateAround (Vector3.zero, Vector3.forward, 120.0f);
		_rotations [TrianglePoint.BlueGreen] = transform.localRotation;

		transform.RotateAround (Vector3.zero, Vector3.forward, 120.0f);
		_rotations [TrianglePoint.GreenRed] = transform.localRotation;
		
		transform.RotateAround (Vector3.zero, Vector3.forward, 120.0f);
		transform.RotateAround (Vector3.zero, Vector3.up, 180.0f);;
		_rotations [TrianglePoint.BlueRed] = transform.localRotation;

		transform.RotateAround (Vector3.zero, Vector3.forward, -120.0f);
		_rotations [TrianglePoint.GreenBlue] = transform.localRotation;

		transform.RotateAround (Vector3.zero, Vector3.forward, -120.0f);
		_rotations [TrianglePoint.RedGreen] = transform.localRotation;
	}

	// FixedUpdate is called once per physics-frame
	void FixedUpdate() {
		float lerpAmount = Mathf.Clamp01 ((Time.fixedTime - _oldFixedTime) / RotationDuration);
		transform.localRotation = Quaternion.Slerp (_oldRotation, _rotations [_currentTop], lerpAmount);
	}

	private void SaveOld() {
		_oldRotation = transform.localRotation;
		_oldFixedTime = Time.fixedTime;
	}

	private void SpinLeft() {
		SaveOld ();
		if (_currentTop > 0) {
			_currentTop = (TrianglePoint)((((int)_currentTop) % 3) + 1);
		}
		else {
			_currentTop = (TrianglePoint)(((((int)_currentTop) - 1) % 3) - 1);
		}
	}

	private void SpinRight() {
		SaveOld ();
		if (_currentTop > 0) {
			_currentTop = (TrianglePoint)(((((int)_currentTop) + 1) % 3) + 1);
		}
		else {
			_currentTop = (TrianglePoint)((((int)_currentTop) % 3) - 1);
		}
	}

	private void Flip() {
		SaveOld ();
		_currentTop = (TrianglePoint)(-(int)_currentTop);
	}
	
	// Update is called once per screen-frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			SpinLeft ();
		}
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			SpinRight ();
		}
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			Flip ();
		}
	}
}
