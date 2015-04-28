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
	public Text winText;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1f;
	}
	
	// Update is called once per frame
	void Update () {
		//keep the HP and Score Updated
		gateHP_T.text = "Gate Condition: " + gateHP + "%";
		score_T.text = "Coins: " + score;

		if (score >= 2500) {
			winText.text = "You won! Thanks for playing;";
			loseScreen.gameObject.SetActive(true);
			Time.timeScale = 0.0f;
		}

		if (gateHP < 1) {
			loseScreen.gameObject.SetActive(true);
			Time.timeScale = 0.0f;
		}
		
	}

	public void HPDown (int a){
		//decreases the gate HP
		gateHP -= a;
	}

	public void AddScore(int S){
		//increases the score
		score += S;
	}

	public void Restart(){
		Application.LoadLevel (1);

	}

	public void ToMenu(){
		Application.LoadLevel (0);
	}
}
