using UnityEngine;
using System.Collections;

public class Explostion_script : MonoBehaviour {

	//Vars for refencing this to GameManager
	GameManager_script GMs;
	GameObject GM;

	//vars for referening the enemy
	GameObject enemy;
	EnemyMovement_script EMs;

	// Use this for initialization
	void Start () {
		//refence this GM to GameManager
		GM = GameObject.FindGameObjectWithTag ("GM");
		GMs = GM.GetComponent<GameManager_script>();

		//reference the enemy and play its audio
		enemy = GameObject.FindGameObjectWithTag("stayEnemy");
		EMs = enemy.gameObject.GetComponent<EnemyMovement_script>();
	}
	
	// Update is called once per frame
	void Update () {

	}

	//if Collider C is an enemy, destory it
	void OnTriggerEnter(Collider C){
		if (C.tag == "enemy") {

			EMs.PlayAudio();
			//Destroy the enemy
			Destroy(C.gameObject);
			//add Score
			GMs.AddScore();
		}
	}

}
