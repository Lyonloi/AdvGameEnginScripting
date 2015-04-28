using UnityEngine;
using System.Collections;

public class Bomb_script : MonoBehaviour {
	//var for referencing to its ClickNDrag_script
	ClickNDrag_script CnDs;

	// Use this for initialization
	void Start () {
		// reference to its ClickNDrag_script
		CnDs = gameObject.GetComponent<ClickNDrag_script>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider C){
		// the bomb hits any of these thing, back to possition
		if (C.tag != "ground" && C.tag != "wall" && C.tag != "enemy" && C.tag != "rock" && C.tag != "oilOnGround" && C.tag != "boss") {

			CnDs.BackToPosition();
		}
	}
}
