using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour {

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
	}

	public void quitGame(){
		Application.Quit ();
	}
}
