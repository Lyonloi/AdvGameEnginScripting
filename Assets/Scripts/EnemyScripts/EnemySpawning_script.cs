using UnityEngine;
using System.Collections;

public class EnemySpawning_script : MonoBehaviour {
	//Vars for refencing this to GameManager
	GameManager_script GMs;
	GameObject GM;

	float SpawningCount = 0f;
	public float SpawningTime = 3f;

	//Spawn points
	int pointSelect;
	public Transform spawnpoint1;
	public Transform spawnpoint2;
	public Transform spawnpoint3;
	public Transform spawnpoint4;

	public GameObject SpawnTarget;

	// Use this for initialization
	void Start () {
		//refence this GM to GameManager
		GM = GameObject.FindGameObjectWithTag ("GM");
		GMs = GM.GetComponent<GameManager_script>();
	}
	
	// Update is called once per frame
	void Update () {

		Debug.Log(SpawningCount);

		SpawningCount += 1 * Time.deltaTime;

		if (SpawningCount >= SpawningTime) {
			SpawnAnEnemy ();
			SpawningCount = 0;
		}
	}

	void SpawnAnEnemy (){
		pointSelect = Random.Range (1, 4);

		if (pointSelect == 1){
			Instantiate(SpawnTarget, spawnpoint1.position, spawnpoint1.rotation);
		}

		if (pointSelect == 2){
			Instantiate(SpawnTarget, spawnpoint2.position, spawnpoint2.rotation);
		}

		if (pointSelect == 3){
			Instantiate(SpawnTarget, spawnpoint3.position, spawnpoint3.rotation);
		}

		if (pointSelect == 4){
			Instantiate(SpawnTarget, spawnpoint4.position, spawnpoint4.rotation);
		}
	}
}
