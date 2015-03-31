using UnityEngine;
using System.Collections;

public class bulletCatcher_script : MonoBehaviour {

	//access to the cannon script
	public Cannons_script Cs;

	//reference the explosion prefeb
	public GameObject explosion;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider C){
		//if the ground catch a rock
		if (C.tag == "bullet") {
			//tell the cannon that it can reload a rock
			Cs.RockOut ();
			//make the rock doesn't kill the enemies when it stays on the ground
			C.gameObject.tag = "rock";

				} 
		//if the ground catch a rock
		else if (C.tag == "bomb") {
			//tell the cannon that it can reload a bomb
			Cs.BombOut ();
			//make an explosion
			Instantiate(explosion, C.gameObject.transform.position, C.gameObject.transform.rotation);
			Destroy(C.gameObject);

				} 
		else if (C.tag == "oil") {
			Cs.OilOut();
			Destroy(C.gameObject);
		}
	}
}
