using UnityEngine;
using System.Collections;

public class MainMenu_Script : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void NextLevel(){

		StartCoroutine (Go ());
			
	}

	IEnumerator Go(){

		//fade out the game and load a new level
		float fadeTime = GameObject.Find ("_GM").GetComponent<Fading_script> ().BeginFade (1);
		yield return new WaitForSeconds(fadeTime);
		Application.LoadLevel (1);
	}



}
