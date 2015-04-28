using UnityEngine;
using System.Collections;

public class Oil_script : MonoBehaviour {

	public float burnOutTime;
	public float destoryTime;

	bool isCleaning = false;

	// Use this for initialization
	void Start () {
		StartCoroutine (CleanUp ());
		StartCoroutine (DestoryIt ());
	}
	
	// Update is called once per frame
	void Update () {
		if (isCleaning == true){
			gameObject.transform.Translate(Vector3.down*Time.deltaTime*0.25f);
		}
	}

	IEnumerator CleanUp(){
		
		yield return new WaitForSeconds (burnOutTime);
		isCleaning = true;
	}

	IEnumerator DestoryIt(){

		yield return new WaitForSeconds (destoryTime);
		Destroy (gameObject);	
	}


}
