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

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//keep the HP and Score Updated
		gateHP_T.text = "Gate Condition: " + gateHP + "%";
		score_T.text = "Score: " + score;

		if (score >= 500) {
			//Application.LoadLevel(2);	
		}
	}

	public void HPDown (){
		//decreases the gate HP
		gateHP--;
	}

	public void AddScore(){
		//increases the score
		score += 100;
	}
}
