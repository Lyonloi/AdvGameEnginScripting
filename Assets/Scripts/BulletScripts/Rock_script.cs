using UnityEngine;
using System.Collections;

public class Rock_script : MonoBehaviour {
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

	//if it touches another bullet, back to the position
	void OnTriggerEnter(Collider C){
		if (C.tag == "bomb" && CnDs.isSelected == true) {
			CnDs.BackToPosition();
		}
	}
}
