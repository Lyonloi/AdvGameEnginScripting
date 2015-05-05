using UnityEngine;
using System.Collections;

public class Transparency : MonoBehaviour {

	//referencing 3 tpyes of bullet here
	public GameObject rock;
	public GameObject bomb;
	public GameObject oil;

	Material[] RockMat;
	Material[] bombMat;
	Material[] oilMat;

	ClickNDrag_script RS;
	ClickNDrag_script BS;
	ClickNDrag_script OS;

	// Use this for initialization
	void Start () {





		rock = GameObject.FindGameObjectWithTag("bullet");
		bomb = GameObject.FindGameObjectWithTag("bomb");
		oil = GameObject.FindGameObjectWithTag("oil");

		if (rock != null) {
			RS = rock.GetComponent<ClickNDrag_script> ();
		}
		
		if (bomb != null) {
			BS = bomb.GetComponent<ClickNDrag_script> ();
		}
		
		if (oil != null) {
			OS = oil.GetComponent<ClickNDrag_script> ();
		}

		if (rock != null) {
			RockMat = rock.renderer.materials;
		}
		
		if (bomb != null) {
			bombMat = bomb.renderer.materials;
		}
		
		if (oil != null) {
			oilMat = oil.renderer.materials;
		}

	}
	
	// Update is called once per frame
	void Update () {
		rock = GameObject.FindGameObjectWithTag("bullet");
		bomb = GameObject.FindGameObjectWithTag("bomb");
		oil = GameObject.FindGameObjectWithTag("oil");

		if (rock != null) {
			RS = rock.GetComponent<ClickNDrag_script> ();
		}

		if (bomb != null) {
			BS = bomb.GetComponent<ClickNDrag_script> ();
		}

		if (oil != null) {
			OS = oil.GetComponent<ClickNDrag_script> ();
		}

		if (rock != null) {
			RockMat = rock.renderer.materials;
		}
		
		if (bomb != null) {
			bombMat = bomb.renderer.materials;
		}
		
		if (oil != null) {
			oilMat = oil.renderer.materials;
		}




		UpdateColor ();
	}

	void UpdateColor(){

		if (RS.isSelected) {

			foreach (Material M in bombMat) {
				M.color = new Color(M.color.r,M.color.g,M.color.b,0.5f);
			}

			foreach (Material M in oilMat) {
				M.color = new Color(M.color.r,M.color.g,M.color.b,0.5f);
			}
		
			foreach (Material M in RockMat) {
				M.color = new Color(M.color.r,M.color.g,M.color.b,1f);
			}
		}

		if (BS.isSelected) {
			
			foreach (Material M in RockMat) {
				M.color = new Color(M.color.r,M.color.g,M.color.b,0.5f);
			}
			
			foreach (Material M in oilMat) {
				M.color = new Color(M.color.r,M.color.g,M.color.b,0.5f);
			}

			foreach (Material M in bombMat) {
				M.color = new Color(M.color.r,M.color.g,M.color.b,1f);
			}
		}

		if (OS.isSelected) {
			
			foreach (Material M in RockMat) {
				M.color = new Color(M.color.r,M.color.g,M.color.b,0.5f);
			}
			
			foreach (Material M in bombMat) {
				M.color = new Color(M.color.r,M.color.g,M.color.b,0.5f);
			}

			foreach (Material M in oilMat) {
				M.color = new Color(M.color.r,M.color.g,M.color.b,1f);
			}
		}


	}
}
