using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour {
	public AudioSource song;

	// Use this for initialization
	void Start () {
	
	}

	public void loadLevelSelect(){

	}

	public void loadLevel(string levelName){
		Application.LoadLevel (levelName);
	}

	public void loadSurvival(){
		//TODO make survival and stuff
	}

	public void loadCredits(){
		//TODO switch the GUI from the tutorial to the credits
		transform.Find ("TutorialImage").gameObject.SetActive (false);
		transform.Find ("CreditImage").gameObject.SetActive (true);
		transform.Find ("Tutorial").gameObject.SetActive (true);
		transform.Find ("Credits").gameObject.SetActive (false);
	}

	public void loadTutorial(){
		//TODO switch the GUI from the credits to the tutorial
		transform.Find ("TutorialImage").gameObject.SetActive (true);
		transform.Find ("CreditImage").gameObject.SetActive (false);
		transform.Find ("Tutorial").gameObject.SetActive (false);
		transform.Find ("Credits").gameObject.SetActive (true);
	}

	public void quitConfirmation(){
		if (!song.isPlaying) {
			song.Play ();
		}
		transform.Find ("QuitConfirmation").gameObject.SetActive (true);
	}

	public void closeQuitConfirmation(){
		transform.Find ("QuitConfirmation").gameObject.SetActive (false);
	}

	public void quitGame(){
		Application.Quit ();
	}
}
