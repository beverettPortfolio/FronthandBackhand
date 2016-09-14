using UnityEngine;
using System.Collections;

/// <summary>
/// A class that controls the GUI on the main menu. These functions are all called by the various buttons on the UI.
/// </summary>
public class GUIController : MonoBehaviour {
	public AudioSource song;

    /// <summary>
    /// An unused method. We were originally going to have more levels and a level select, but we only had one weekend to make the game.
    /// </summary>
	public void loadLevelSelect(){

	}

    /// <summary>
    /// Loads the specified level.
    /// Called by that level's button.
    /// </summary>
    /// <param name="levelName">The name of the level to be loaded</param>
	public void loadLevel(string levelName){
		Application.LoadLevel (levelName);
	}


    /// <summary>
    /// We were also going to have an endless survival mode with procedurally generated balls, but again, one weekend.
    /// </summary>
	public void loadSurvival(){
		//TODO make survival and stuff
	}

    /// <summary>
    /// Hides the tutorial UI and shows the credits image.
    /// Called by the credits button
    /// </summary>
	public void loadCredits(){
		//TODO switch the GUI from the tutorial to the credits
		transform.Find ("TutorialImage").gameObject.SetActive (false);
		transform.Find ("CreditImage").gameObject.SetActive (true);
		transform.Find ("Tutorial").gameObject.SetActive (true);
		transform.Find ("Credits").gameObject.SetActive (false);
	}

    /// <summary>
    /// Hides the credits image and shows the tutorial UI.
    /// Called by the tutorial button
    /// </summary>
	public void loadTutorial(){
		transform.Find ("TutorialImage").gameObject.SetActive (true);
		transform.Find ("CreditImage").gameObject.SetActive (false);
		transform.Find ("Tutorial").gameObject.SetActive (false);
		transform.Find ("Credits").gameObject.SetActive (true);
	}

    /// <summary>
    /// Opens the quit confirmation window and plays a sound
    /// Called by the quit button
    /// </summary>
	public void quitConfirmation(){
		if (!song.isPlaying) {
			song.Play ();
		}
		transform.Find ("QuitConfirmation").gameObject.SetActive (true);
	}

    /// <summary>
    /// Closes the quit confirmation window.
    /// Called by the no button on the quit confirmation window.
    /// </summary>
	public void closeQuitConfirmation(){
		transform.Find ("QuitConfirmation").gameObject.SetActive (false);
	}

    /// <summary>
    /// Quits the game
    /// Called by the yes button on the quit confirmation window.
    /// </summary>
	public void quitGame(){
		Application.Quit ();
	}
}
