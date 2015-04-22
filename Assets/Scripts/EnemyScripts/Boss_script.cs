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
	public float movingSpeed = 0.5f;
	
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
		transform.Translate (Vector3.back * Time.deltaTime * movingSpeed);
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

		if (isMoving == true && C.tag == "wall"||C.tag == "boss") {
			//stop moving
			isMoving = false;
			gameObject.rigidbody.useGravity = true;
			
			
			//if Collider C is a rock
			if (C.tag == "rock" && isAttacking != true){
				//make Collider C as the attackTarget and destory it after a few second
				attackTarget = C.gameObject;
				DestoryObstacle();

				
			}
			
			
		}


		if (C.tag == "wall") {
			isTouchingTheGate = true;
			isAttacking = true;
			
		}
		
		if (C.tag == "oilOnGround") {
			movingSpeed = 0.2f;
		}
	}

	void MoveAgain(){
		//make this unit moves again
		gameObject.transform.Translate(Vector3.back *Time.deltaTime);
		isMoving = true;
	}

	void OnTriggerExit(Collider C){
		if (C.tag == "oilOnGround") {
			movingSpeed = 0.5f;
		}
		if (C.tag == "enemy" || C.tag == "boss") {
			Invoke("MoveAgain",1f);
		}
	}

}
