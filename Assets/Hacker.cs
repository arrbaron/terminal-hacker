using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

	int Level;
	enum Screen { MainMenu, Password, Win };
	Screen CurrentScreen = Screen.MainMenu;

	// Use this for initialization
	void Start () {
		ShowMainMenu("Welcome to Hack0r 2017.");
	}
	
	void ShowMainMenu(string greeting) {
		CurrentScreen = Screen.MainMenu;
		Terminal.ClearScreen();
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("WHAT WOULD YOU LIKE TO HACK?");
        Terminal.WriteLine("Press 1 for your kindergarten teacher's email");
        Terminal.WriteLine("Press 2 for the president's email");
        Terminal.WriteLine("Press 3 for the Mars base");
        Terminal.WriteLine("Enter your selection:");
	}

	void OnUserInput(string input) {
		if (input == "menu") {
			ShowMainMenu("Welcome to Hack0r 2017.");
		}
		else if (CurrentScreen == Screen.MainMenu) {
			RunMainMenu(input);
		}
	}

	void RunMainMenu(string input) {
		if (input == "1") {
            Level = 1;
            StartGame();
        }
        else if (input == "2") {
            Level = 2;
            StartGame();
        }
        else {
            Terminal.WriteLine("Please enter a valid level");
        }
	}

	void StartGame() {
		CurrentScreen = Screen.Password;
		Terminal.WriteLine("You have chosen level " + Level);
		Terminal.WriteLine("Please enter your password: ");
	}

	// Update is called once per frame
	void Update () {
		
	}
}
