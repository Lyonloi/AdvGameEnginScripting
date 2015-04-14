using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager_script : MonoBehaviour {
	//vars for Gate condition
	int gateHP = 100;
	public Text gateHP_T;

	//Vars for Scores;
	int score = 0;
	public Text score_T;

	//Vars for lose screen
	public GameObject loseScreen;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//keep the HP and Score Updated
		gateHP_T.text = "Gate Condition: " + gateHP + "%";
		score_T.text = "Coins: " + score;

		if (score >= 500) {
			//Application.LoadLevel(2);	
		}

		if (gateHP < 1) {
			loseScreen.gameObject.SetActive(true);
			Time.timeScale = 0.0f;
		}
	}

	public void HPDown (){
		//decreases the gate HP
		gateHP--;
	}

	public void AddScore(){
		//increases the score
		score += 50;
	}

	public void Restart(){
		Application.LoadLevel (0);

	}
}
