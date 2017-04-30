using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Login : MonoBehaviour {

	//check azure blob here
	private string u = "username";
	private string p = "password";

	private string username = string.Empty;
	private string password = string.Empty;

	//public bool yes = false;

	private Rect windowRect = new Rect(0,0,Screen.width,Screen.height);
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI() {
		GUI.Window(0,windowRect,windowFunction,"Login");
		//Debug.Log("Hey");
	}

	void windowFunction(int windowID) {
		//Debug.Log("Yo");
		username = GUI.TextField(new Rect(Screen.width/3,2 * Screen.height/5, Screen.width/3, Screen.height/10), username, 25);
		password = GUI.PasswordField(new Rect(Screen.width/3,2 * Screen.height/3, Screen.width/3, Screen.height/10), password, "*"[0],25);

		if(GUI.Button(new Rect(Screen.width/2, 4 * Screen.height/5, Screen.width/8, Screen.height/8),"Log In")) {
			if(username == u && password == p) {
				SceneManager.LoadScene(1);
			}
			else {

			}
		}

		GUI.Label(new Rect(Screen.width/3,35*Screen.height/100,Screen.width/5,Screen.height/8), "Username");
		GUI.Label(new Rect(Screen.width/3,62*Screen.height/100,Screen.width/5,Screen.height/8), "Password");
	}
}
