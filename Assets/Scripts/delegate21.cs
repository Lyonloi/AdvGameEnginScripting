using UnityEngine;
using System.Collections;

public class delegate21 : MonoBehaviour {

	public delegate void PowerUpHandler(bool isPowerdUp);

	public static event PowerUpHandler onPoweredUp;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		if(GUI.Button(new Rect(10, 10, 500, 100), "Click")){
			if(onPoweredUp != null){
				onPoweredUp(true);
			}
			
		}
		
		if(GUI.Button(new Rect(300, 300, 500, 100), "Click Me")){
			if(onPoweredUp != null){
				onPoweredUp(false);
			}
		}
	}
}
