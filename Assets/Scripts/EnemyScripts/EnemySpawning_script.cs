using UnityEngine;
using System.Collections;

public class EnemySpawning_script : MonoBehaviour {
	//vars of spawning timer
	float SpawningCount = 0f;
	public float SpawningTime = 3f;

	//Spawn points
	int pointSelect;
	public Transform[] spawnpoints;

	//spawntarget
	public GameObject SpawnTarget;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {


		//spawn an emeny after a certain time
		SpawningCount += 1 * Time.deltaTime;

		if (SpawningCount >= SpawningTime) {
			SpawnAnEnemy ();
			SpawningCount = 0;
		}
	}

	//spawn an emeny at a ramdom spawnpoint
	void SpawnAnEnemy (){
		//get a random # based on the length of the array
		pointSelect = Random.Range (0, spawnpoints.Length);
		//Instantiate a prefad based on the number just got
		Instantiate(SpawnTarget, spawnpoints[pointSelect].position, spawnpoints[pointSelect].rotation);

		
	}

	void OnTriggerStay(Collider C){

		SpawningCount = 0;

	}
}
