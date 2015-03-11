using UnityEngine;
using System.Collections;

public class EnemyAttack_script : MonoBehaviour {
	//Vars for refencing this to GameManager
	GameManager_script GMs;
	GameObject GM;


	float attackCount = 1f;
	bool isTouchingTheGate = false;


	// Use this for initialization
	void Start () {
		//refence this GM to GameManager
		GM = GameObject.FindGameObjectWithTag ("GM");
		GMs = GM.GetComponent<GameManager_script>();
	}
	
	// Update is called once per frame
	void Update () {

		if (isTouchingTheGate) {

				//attackCount increases overtime
				attackCount += 1f * Time.deltaTime;
		
				//When it is over 2, attack the gate once and goes back to 1 again
				if (attackCount >= 2f) {

						Attack ();
						attackCount = 1;		
			
				}

		}

	}

	void OnTriggerEnter(Collider C){
		//When this enemy touches the gate
		if (C.tag == "wall") {
			isTouchingTheGate = true;

		}
	}


	void Attack(){
		//HP goes down
		GMs.HPDown ();
	}
}
