using UnityEngine;
using System.Collections;

public class ClickNDrag_script : MonoBehaviour {



	public GameObject dragTarget;

	//Origin position
	float OriginX;
	float OriginY;
	float OriginZ;

	//Tem bullet position
	float bulletPositionX;
	float bulletPositionY;
	float bulletPositionZ;

	//vars for dragging visual effect
	public float DragBackSpeed;
	public float DragDownSpeed;
	public float distance;


	// vars for determining the spring force
	public float springingforce;
	public float forceMultiplier;

	//vars for checking if the mouse is hovering and selected
	bool isHovering = false;
	bool isSelected = false;


	// Use this for initialization
	void Start () {
		OriginX = dragTarget.transform.position.x;
		OriginY = dragTarget.transform.position.y;
		OriginZ = dragTarget.transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {

		//keep the vector 3 updated
		bulletPositionX = dragTarget.transform.position.x;
		bulletPositionY = dragTarget.transform.position.y;
		bulletPositionZ = dragTarget.transform.position.z;


		if (isHovering == true) {
			//if the mouse is hovering this 
			Drag();
		}

		//When releasing mouse click, run springing function
		if(Input.GetMouseButtonUp(0) && isSelected == true){

			Spring();
		}

	}

	void Drag(){

		//When clicking on a shootable object, run draging function
		if(Input.GetMouseButton(0)){

			isSelected = true;
			StartDragging();

		}
		

		
		// back to postion
		if(Input.GetMouseButtonDown(1)){
			//zero out all forces
			rigidbody.velocity = Vector3.zero;
			rigidbody.angularVelocity = Vector3.zero;
			//disable gravity
			gameObject.rigidbody.useGravity = false;
			//back to position
			BackToPosition();
		}
	}

	void StartDragging(){

		gameObject.transform.position = new Vector3(bulletPositionX, bulletPositionY - DragDownSpeed, bulletPositionZ - DragBackSpeed);

	}

	void Spring(){
		//add the force to the bullet
		gameObject.rigidbody.AddForce(Vector3.forward * springingforce);
		gameObject.rigidbody.AddForce(Vector3.up * springingforce/4);
		//enable gravity
		gameObject.rigidbody.useGravity = true;
		//unselect the bullet
		isSelected = false;
	}

	void BackToPosition(){
		//back to postion(for testing)
		gameObject.transform.position = new Vector3(OriginX,OriginY,OriginZ);
	}

	void OnMouseEnter(){
		isHovering = true;

	}

	void OnMouseExit(){
		isHovering = false;
	}
}
