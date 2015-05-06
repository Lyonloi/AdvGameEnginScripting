using UnityEngine;
using System.Collections;

public class Rock_script : MonoBehaviour {
	//var for referencing to its ClickNDrag_script
	ClickNDrag_script CnDs;

	//Vars for refencing this to GameManager
	GameManager_script GMs;
	GameObject GM;

	//vars for referening the enemy
	GameObject enemy;
	EnemyMovement_script EMs;

	//vars for referening a boss
	Boss_script Bs;

	// Use this for initialization
	void Start () {
		//refence this GM to GameManager
		GM = GameObject.FindGameObjectWithTag ("GM");
		GMs = GM.GetComponent<GameManager_script>();


		// reference to its ClickNDrag_script
		CnDs = gameObject.GetComponent<ClickNDrag_script>();

		//reference the enemy and play its audio
		enemy = GameObject.FindGameObjectWithTag("stayEnemy");
		EMs = enemy.gameObject.GetComponent<EnemyMovement_script>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//if it touches another bullet, back to the position
	void OnTriggerEnter(Collider C){
		if (C.tag == "bomb" && CnDs.isSelected == true) {
			CnDs.BackToPosition();
		}

		if (C.tag == "bullet" && CnDs.isSelected == true) {
			Destroy(C.gameObject);
		}

		if (C.tag == "enemy" && gameObject.tag == "bullet") {
			//play the audio
			EMs.PlayAudio();
			//Destroy the enemy
			Destroy(C.gameObject);
			//add Score
			GMs.AddScore(50);		
		}


	}


}
