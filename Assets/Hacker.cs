using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

	int Level;
	string Password = "pizza";
	string[] Passwords = { "pizza", "teeth", "goat", "dinosaur", "fantasy", "existence" };
	enum Screen { MainMenu, Password, Win };
	Screen CurrentScreen = Screen.MainMenu;

	// Use this for initialization
	void Start () {
		Terminal.WriteLine("Welcome to Hack0r 2017.");
		AskForPassword();
	}
	
	void AskForPassword() {
		CurrentScreen = Screen.MainMenu;
		Terminal.ClearScreen();
        Terminal.WriteLine("WHAT WOULD YOU LIKE TO HACK?");
        Terminal.WriteLine("Press 1 for your kindergarten teacher's email");
        Terminal.WriteLine("Press 2 for the president's email");
        Terminal.WriteLine("Press 3 for the Mars base");
        Terminal.WriteLine("Enter your selection:");
	}

	void OnUserInput(string input) {
		if (input == "menu") {
			AskForPassword();
		}
		else if (CurrentScreen == Screen.MainMenu) {
			RunMainMenu(input);
		}
		else if (CurrentScreen == Screen.Password) {
			CheckPassword(input);
		}
	}

	void RunMainMenu(string input) {
		bool isValidLevel = (input == "1" | input == "2");
		
		if (isValidLevel) {
			Level = int.Parse(input);
			StartGame();
		}
        else {
            Terminal.WriteLine("Please enter a valid level");
        }
	}

	void CheckPassword(string input) {
		if (input == Password) {
			Win();
		}
		else {
			TryAgain();
		}
	}

	void Win() {
		CurrentScreen = Screen.Win;
		Terminal.ClearScreen();
		ShowLevelReward();
	}

	void ShowLevelReward() {
		if (Level == 1) {
			Terminal.WriteLine("You beat level 1! You win! Type 'menu' to play again!");
		}
		else {
			Terminal.WriteLine("You beat level 2! You win! Type 'menu' to play again!");
		}
	}

	void TryAgain() {
		Terminal.WriteLine("Wrong. Try again.");
	}

	void StartGame() {
		CurrentScreen = Screen.Password;

		GeneratePassword();

		Terminal.ClearScreen();
		Terminal.WriteLine("Please enter your password: hint: " + Password.Anagram());
	}

	void GeneratePassword() {
		if (Level == 1)
        {
            Password = Passwords[Random.Range(0, 3)];
            print(Password);
        }
        else if (Level == 2)
        {
            Password = Passwords[Random.Range(3, Passwords.Length)];
            print(Password);
        }
        else
        {
            Debug.LogError("Invalid level number");
        }
	}

	// Update is called once per frame
	void Update () {
		
	}
}
