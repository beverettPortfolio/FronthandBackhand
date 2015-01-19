using UnityEngine;
using System.Collections;

public class ScrollViewController : MonoBehaviour {
	private Vector3 offScreenPosition;
	private Vector3 movePosition;
	public float moveSpeed;

	private bool moving;
	private bool shown;

	// Use this for initialization
	void Start () {
		offScreenPosition=new Vector3((-100f),Screen.height-90f,0);
		movePosition=new Vector3 (290f, Screen.height-90f,0);
		shown = false;
		moving = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (moving){
			float step = moveSpeed*Time.deltaTime;
			if (shown){
				transform.position=Vector3.MoveTowards(transform.position, movePosition, step);
				if (transform.position==movePosition){
					moving=false;
				}
			}
			if (!shown){
				transform.position=Vector3.MoveTowards(transform.position, offScreenPosition, step);
				if (transform.position==offScreenPosition){
					moving=false;
				}
			}
		}
	}

	public void changeState(){
		moving = true;
		shown = (!shown);
	}
}
