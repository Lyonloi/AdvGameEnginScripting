using UnityEngine;
using System.Collections;

public class ClickNDrag_script : MonoBehaviour {



	public GameObject dragTarget;

	//Origin position
	Vector3 Origin;

	//Tem bullet position
	Vector3 bulletPosition;

	//vars for dragging visual effect
	public float DragBackSpeed;
	public float DragDownSpeed;
	public float distance;


	// vars for determining the spring force
	public float springForce;
	public float forceMultiplier;
	public float MaxForce =1150f;

	//vars for making it shake
	float shakingSpeed = 1.0f;

	//vars for checking if the mouse is hovering and selected
	bool isHovering = false;
	bool isSelected = false;

	//vars for controlling the springing angle of the bullet
	float originMouseX;
	float currentMonseX;
	float minMouseXChange;
	float maxMouseXChange;
	float mouseXChanged;




	// Use this for initialization
	void Start () {

		Origin = dragTarget.transform.position;

	
	}
	
	// Update is called once per frame
	void Update () {



		//keep the vector 3 updated
		bulletPosition = gameObject.transform.position;
		//keep the current mouse x updated
		currentMonseX = Input.mousePosition.x;
		//keep getting the 
	
		//get the current mouse postion x
		if (Input.GetMouseButtonDown(0)){
			originMouseX = Input.mousePosition.x;
		}


		//if the mouse is hovering this object
		if (isHovering == true) {
			Drag();
		}

		//make the hovered bullet selected
		if (Input.GetMouseButtonDown(0) && isHovering){
			this.isSelected = true;

		}


		StartDragging ();

		//When releasing mouse click, run spring function
		if(Input.GetMouseButtonUp(0) && isSelected){

			Spring();
		}

		if (Input.GetMouseButtonDown (1)) {
				
			BackToPosition();
		
		}
	}

	void Drag(){

		//When clicking on a shootable object, run draging function

		if(Input.GetMouseButtonDown(0)){


			StartDragging();

		}
	}

	void StartDragging(){
		// increase the drag force
			if (isSelected == true) {
						//limit the spring force
						if (springForce < MaxForce) {
								//simulate the slingshot, move back, add force
				gameObject.transform.position = new Vector3 (bulletPosition.x + (Input.GetAxis("Mouse X"))*0.1f , bulletPosition.y - DragDownSpeed / 200
				                                             , bulletPosition.z - DragBackSpeed / 100);
								springForce += forceMultiplier * Time.deltaTime * 2;
						}

						
				}

			
	
		}

	void Spring(){
		//spring when the force is over 200 so that the bullet won't stay on the base
		if (springForce > 200){

		//add the force to the bullet
		gameObject.rigidbody.AddForce((Origin - gameObject.transform.position).normalized * springForce);
		gameObject.rigidbody.AddForce(Vector3.up * springForce/8);
		//enable gravity
		gameObject.rigidbody.useGravity = true;
		//unselect the bullet
		isSelected = false;
		
		}
		//back to the origin position when the force is less than 200
		else if (springForce < 200){

			BackToPosition();
			isSelected = false;
		}
	}

	void BackToPosition(){

		//zero out all forces
			gameObject.rigidbody.velocity = Vector3.zero;
			gameObject.rigidbody.angularVelocity = Vector3.zero;

		//disable gravity
			gameObject.rigidbody.useGravity = false;
			
			
		

		//back to postion(for testing only)
		gameObject.transform.position = new Vector3(Origin.x,Origin.y,Origin.z);
		gameObject.transform.rotation = Quaternion.identity;
		springForce = 0;

	}

	void OnMouseEnter(){
		isHovering = true;
	}

	void OnMouseExit(){
		isHovering = false;
	}
}
