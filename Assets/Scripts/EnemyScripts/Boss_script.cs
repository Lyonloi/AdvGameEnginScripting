using UnityEngine;
using System.Collections;

public class Boss_script : MonoBehaviour {
	//Vars for refencing this to GameManager
	GameManager_script GMs;
	GameObject GM;

	//vars for attacking
	float attackCount = 1f;
	bool isTouchingTheGate = false;

	//vars for audio
	GameObject audioMan;
	EnemyMovement_script EMs;

	//vars for changing status of the enemy
	public bool isMoving = true;
	public bool isAttacking = false;

	//var for controlling enemy's speed 
	public float movingSpeed = 0.05f;
	
	//var for targeting a gameobject to destory
	public GameObject attackTarget;

	//var for its HP
	public int hp = 5;

	// Use this for initialization
	void Start () {
		//refence this GMs to GameManager
		GM = GameObject.FindGameObjectWithTag ("GM");
		GMs = GM.GetComponent<GameManager_script>();

		//refence to the audio
		audioMan = GameObject.FindGameObjectWithTag ("stayEnemy");
		EMs = audioMan.gameObject.GetComponent<EnemyMovement_script>();
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

		if (isMoving == true) {
			Move();	
		}

		if (hp <= 0) {
			EMs.PlayAudio();
			Destroy(gameObject);
		}
	}

	void Attack(){
		//HP goes down
		GMs.HPDown (5);
	}

	void Move(){
		//make this unit moves 
		transform.Translate (Vector3.right * Time.deltaTime * movingSpeed);
	}

	void DestoryObstacle(){
		//destroy an obstacle if there is one
		if (attackTarget != null) {
			Destroy (attackTarget);
			
		}
	}

	public void PlayAudio(){
		EMs.PlayAudio();
	}

	void OnTriggerEnter(Collider C){
	
	}



}
