using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TriangleController : MonoBehaviour {

	public Vector2 RotateCenter;

	public float RotationDuration;
	private Vector3 _oldPosition;
	private Quaternion _oldRotation;
	private float _oldFixedTime;

	/*
	public float MovementSpeed;
	public float FlipSpeed;
	private float _toMove;
	private float _xScaleGoal;

*/

	private enum TrianglePoint {
		RedBlue = 1,
		BlueGreen = 2,
		GreenRed = 3,

		BlueRed = -1,
		GreenBlue = -2,
		RedGreen = -3
	};
	
	private Dictionary<TrianglePoint, Vector3> _positions;
	private Dictionary<TrianglePoint, Quaternion> _rotations;

	private TrianglePoint _currentTop;

	// Use this for initialization
	void Start () {
		//_toMove = 0.0f;
		//_xScaleGoal = 1.0f;
		_currentTop = TrianglePoint.RedBlue;
		_oldPosition = transform.localPosition;
		_oldRotation = transform.localRotation;
		_oldFixedTime = float.NegativeInfinity;


		_positions = new Dictionary<TrianglePoint, Vector3> ();
		_rotations = new Dictionary<TrianglePoint, Quaternion> ();

		_positions [TrianglePoint.RedBlue] = transform.localPosition;
		_rotations [TrianglePoint.RedBlue] = transform.localRotation;

		transform.RotateAround ((Vector3)RotateCenter, Vector3.forward, 120.0f);
		_positions [TrianglePoint.BlueGreen] = transform.localPosition;
		_rotations [TrianglePoint.BlueGreen] = transform.localRotation;

		transform.RotateAround ((Vector3)RotateCenter, Vector3.forward, 120.0f);
		_positions [TrianglePoint.GreenRed] = transform.localPosition;
		_rotations [TrianglePoint.GreenRed] = transform.localRotation;
		
		transform.RotateAround ((Vector3)RotateCenter, Vector3.forward, 120.0f);
		transform.RotateAround ((Vector3)RotateCenter, Vector3.up, 180.0f);
		_positions [TrianglePoint.BlueRed] = transform.localPosition;
		_rotations [TrianglePoint.BlueRed] = transform.localRotation;

		transform.RotateAround ((Vector3)RotateCenter, Vector3.forward, -120.0f);
		_positions [TrianglePoint.GreenBlue] = transform.localPosition;
		_rotations [TrianglePoint.GreenBlue] = transform.localRotation;

		
		transform.RotateAround ((Vector3)RotateCenter, Vector3.forward, -120.0f);
		_positions [TrianglePoint.RedGreen] = transform.localPosition;
		_rotations [TrianglePoint.RedGreen] = transform.localRotation;


		/*
		transform.Translate (RotateCenter);
		Vector3 forward = Vector3.forward;
		Vector3 up = Vector3.up;
		Vector3 downright = new Vector2 (1.0f, -Mathf.Sqrt (3.0f) / 2.0f);
		Vector3 downleft = new Vector2 (-1.0f, -Mathf.Sqrt (3.0f) / 2.0f);

		_rotations = new Dictionary<TrianglePoint, Quaternion> ();
		
		_rotations [TrianglePoint.RedBlue] = Quaternion.LookRotation (forward, up);
		_rotations [TrianglePoint.BlueGreen] = Quaternion.LookRotation (forward, downleft);
		_rotations [TrianglePoint.GreenRed] = Quaternion.LookRotation (forward, downright);

		_rotations [TrianglePoint.BlueRed] = Quaternion.LookRotation (-forward, up);
		_rotations [TrianglePoint.GreenBlue] = Quaternion.LookRotation (-forward, downleft);
		_rotations [TrianglePoint.RedGreen] = Quaternion.LookRotation (-forward, downright);

*/
	}

	// FixedUpdate is called once per physics-frame
	void FixedUpdate() {
		float lerpAmount = Mathf.Clamp01 ((Time.fixedTime - _oldFixedTime) / RotationDuration);
		transform.localPosition = Vector3.Lerp (_oldPosition, _positions [_currentTop], lerpAmount);
		transform.localRotation = Quaternion.Lerp (_oldRotation, _rotations [_currentTop], lerpAmount);

/*
		// Rotate
		float maxMovement = MovementSpeed * Time.fixedDeltaTime;
		float willMove = Mathf.Clamp (Mathf.Abs (_toMove), 0, MovementSpeed) * Mathf.Sign (_toMove);
		transform.RotateAround ((Vector3)RotateCenter, Vector3.forward, willMove);
		_toMove -= willMove;

		// Flip
		Vector3 localScale = this.transform.localScale;
		float maxFlip = FlipSpeed * Time.fixedDeltaTime;
		float toFlip = _xScaleGoal - localScale.x;
		float willFlip = Mathf.Clamp (Mathf.Abs (toFlip), 0, FlipSpeed) * Mathf.Sign (toFlip);
		localScale.x += willFlip;
		transform.localScale = localScale;
		*/
	}

	private void SaveOld() {
		_oldPosition = transform.localPosition;
		_oldRotation = transform.localRotation;
		_oldFixedTime = Time.fixedTime;
	}

	private void SpinLeft() {
		//_toMove += 120.0f;
		SaveOld ();
		if (_currentTop > 0) {
			_currentTop = (TrianglePoint)((((int)_currentTop) % 3) + 1);
		}
		else {
			_currentTop = (TrianglePoint)(((((int)_currentTop) - 1) % 3) - 1);
		}
	}

	private void SpinRight() {
		//_toMove -= 120.0f;
		SaveOld ();
		if (_currentTop > 0) {
			_currentTop = (TrianglePoint)(((((int)_currentTop) + 1) % 3) + 1);
		}
		else {
			_currentTop = (TrianglePoint)((((int)_currentTop) % 3) - 1);
		}
	}

	private void Flip() {
		//_xScaleGoal *= -1.0f;
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
