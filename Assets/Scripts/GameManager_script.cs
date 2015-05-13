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



	//vars for levels
	public Text lv_T;
	public int currentLV = 1;
	int levelCount = 1;

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
		score_T.text = "Score: " + score;
		lv_T.text = "LV: " + currentLV;

		if (score >= 2000) {
			winText.text = "You won! Thanks for playing;";
			loseScreen.gameObject.SetActive(true);
			Time.timeScale = 0.0f;
		}

		if (gateHP < 1) {
			loseScreen.gameObject.SetActive(true);
			Time.timeScale = 0.0f;
		}

		if (levelCount >= 400) {
			LevelUp();	
		}
	}

	void LevelUp(){
		currentLV += 1;
		levelCount -= 400;
	}

	public void HPDown (int a){
		//decreases the gate HP
		gateHP -= a;
	}

	public void AddScore(int S){
		//increases the score
		score += S;
		levelCount += S;
	}

	public void Restart(){
		Application.LoadLevel (1);

	}

	public void ToMenu(){
		Application.LoadLevel (0);
	}

	public void QuitGame(){

		Application.Quit ();
	}
}
