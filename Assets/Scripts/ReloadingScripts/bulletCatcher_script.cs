using UnityEngine;
using System.Collections;

public class bulletCatcher_script : MonoBehaviour {

	public Cannons_script Cs;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider C){
		if (C.tag == "bullet") {
			Cs.RockOut ();
			C.gameObject.tag = "rock";

				} 
		else if (C.tag == "bomb") {
			Cs.BombOut ();
				} 
		else if (C.tag == "bomb") {
			Cs.OilOut();
		}
	}
}
