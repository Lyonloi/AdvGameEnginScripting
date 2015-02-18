using UnityEngine;
using System.Collections;

public class EnemyMovement_script : MonoBehaviour {

	//vars for getting current position
	Transform CurrentPosition;
	float tempX;
	float tempY;
	float tempZ;

	//var for controlling enemy's speed 
	public float movingSpeed = 0.05f;

	//vars for changing status of the enemy
	public bool isMoving = true;

	// Use this for initialization
	void Start () {

		//get the current position
		CurrentPosition = gameObject.transform;
		//store up the vars
		tempX = CurrentPosition.position.x;
		tempY = CurrentPosition.position.y;
		tempZ = CurrentPosition.position.z;
	}
	
	// Update is called once per frame
	void Update () {

		if (isMoving == true) {
			Move();	
		}
	}

	void Move(){
		tempX = tempX - movingSpeed;
		transform.position = new Vector3(tempX,tempY, tempZ);
	}

	void OnTriggerEnter(Collider C){
		if (C.tag == "wall") {
						isMoving = false;
				}
	}
}
