using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public string CurrentMenu;

	// Use this for initialization
	void Start () {
		CurrentMenu = "Main";
	}

	void OnGUI()
	{
		if (CurrentMenu == "Main")
		{
			Menu_Main();
		}
		if (CurrentMenu == "Credit")
		{
			Menu_Credit();
		}
	}

	private void changeMenu(string next)
	{
		CurrentMenu = next;
	}

	private void Menu_Main() {
		if (GUI.Button (new Rect ((Screen.width/2)-100, (Screen.height/2)-145, 200, 50), "Tutorial")) {
			Application.LoadLevel ("Tutorial");
		}
		if (GUI.Button (new Rect ((Screen.width/2)-100, (Screen.height/2)-85, 200, 50), "Export Mode")) {
			Application.LoadLevel("MainGame");
		}
		if (GUI.Button (new Rect ((Screen.width/2)-100, (Screen.height/2)-25, 200, 50), "Hell Mode")) {

		}
		if (GUI.Button (new Rect ((Screen.width/2)-100, (Screen.height/2)+35, 200, 50), "Credits")) {
			changeMenu("Credit");
		}
		if (GUI.Button (new Rect ((Screen.width/2)-100, (Screen.height/2)+95, 200, 50), "Quit")) {
			Application.Quit();
		}
	}

	private void Menu_Credit()
	{
		if (GUI.Button (new Rect ((Screen.width/2)-100, Screen.height-80, 200, 50), "Back")) {
			changeMenu("Main");
		}
	}
}

