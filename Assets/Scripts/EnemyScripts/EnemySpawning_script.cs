using UnityEngine;
using System.Collections;

public class EnemySpawning_script : MonoBehaviour {

	//Vars for refencing this to GameManager
	GameManager_script GMs;

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
		GMs = GameObject.FindGameObjectWithTag ("GM").GetComponent<GameManager_script>();
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

		if (GMs.currentLV == 1) {
			//spwan an enemy after 0 second
			StartCoroutine( Spawn(0.1f));
		}

		if (GMs.currentLV == 2) {
			//spwan an enemy after 0 second
			StartCoroutine( Spawn(0.1f));
		}

		if (GMs.currentLV == 3) {

			//spwan an enemy after 0 second
			StartCoroutine( Spawn(0.1f));
			//spwan an enemy after 1 second
			StartCoroutine( Spawn(1f));
		}
		
	}

	IEnumerator Spawn(float S){
	
		yield return new WaitForSeconds(S);

		//get a random # based on the length of the array
		pointSelect = Random.Range (0, spawnpoints.Length);
		
		//Instantiate a prefad based on the number just got
		Instantiate (SpawnTarget, spawnpoints [pointSelect].position, spawnpoints [pointSelect].rotation);
	}

	void OnTriggerStay(Collider C){

		SpawningCount = 0;

	}
}
