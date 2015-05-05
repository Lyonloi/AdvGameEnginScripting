using UnityEngine;
using System.Collections;

public class Cannons_script : MonoBehaviour {

	bool c1HasBullet = true;
	bool c2HasBullet = true;
	bool c3HasBullet = true;

	//referencing 3 tpyes of bullet here
	public GameObject rock;
	public GameObject bomb;
	public GameObject oil;




	//referencing 3 cannons
	public Transform cannon1;
	public Transform cannon2;
	public Transform cannon3;



	//Setting reloading times
	public float rockReloadTime;
	public float bombReloadTime;
	public float oilReloadTime;

	// Use this for initialization
	void Start () {
		//instantiate 3 bullet at the beginning
		Instantiate (rock, cannon1.position, cannon1.rotation);
		Instantiate (bomb, cannon2.position, cannon2.rotation);
		Instantiate (oil, cannon3.position, cannon3.rotation);
		c1HasBullet = true;
		c2HasBullet = true;
		c3HasBullet = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (!c1HasBullet) {

			Invoke("ReloadRock",rockReloadTime);
			c1HasBullet = true;

		}

		if (!c2HasBullet) {

			Invoke("ReloadBomb",bombReloadTime);
			c2HasBullet = true;
			}


		if (!c3HasBullet) {

			Invoke("ReloadOil",oilReloadTime);
			c3HasBullet = true;
		}
	
	}

	public void RockOut(){
		c1HasBullet = false;
	}

	public void BombOut(){
		c2HasBullet = false;
	}

	public void OilOut(){
		c3HasBullet = false;
	}

	void ReloadRock(){
		Instantiate (rock, cannon1.position, cannon1.rotation);
		c1HasBullet = true;
	}

	void ReloadBomb(){
		Instantiate (bomb, cannon2.position, cannon2.rotation);
		c2HasBullet = true;
	}

	void ReloadOil(){
		Instantiate (oil, cannon3.position, cannon3.rotation);
		c3HasBullet = true;
	}
}
