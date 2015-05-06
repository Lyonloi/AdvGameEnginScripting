using UnityEngine;
using System.Collections;

public class Transparency : MonoBehaviour {

	//referencing 3 tpyes of bullet here
	public GameObject rock;
	public GameObject bomb;
	public GameObject oil;
	//extra reference for getting the right mesh and material
	public GameObject bombMesh;
	public GameObject oilMesh;

	//material arrys for each bullet
	Material[] RockMat;
	Material[] bombMat;
	Material[] oilMat;

	//reference each script for each bullet
	ClickNDrag_script RS;
	ClickNDrag_script BS;
	ClickNDrag_script OS;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//Update References
		UpdateRefs ();

		if(Input.GetMouseButtonDown(0)){
			UpdateColor ();
		}

		if(Input.GetMouseButtonUp(0)){
			UpdateColor ();
		}
	}

	void UpdateRefs(){
		rock = GameObject.FindGameObjectWithTag("bullet");
		bomb = GameObject.FindGameObjectWithTag("bomb");
		oil = GameObject.FindGameObjectWithTag("oil");

		bombMesh = GameObject.FindGameObjectWithTag ("bombMesh");
		oilMesh = GameObject.FindGameObjectWithTag ("oilMesh");
		
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
			bombMat = bombMesh.renderer.materials;
		}
		
		if (oil != null) {
			oilMat = oilMesh.renderer.materials;
		}

	}

	void RockApp(){
		if (RockMat != null) {

			foreach (Material M in RockMat) {
			M.color = new Color (M.color.r, M.color.g, M.color.b, 1f);
			}	
		}
	}

	void RockTran(){

		if (RockMat != null && !RS.isShooted) {
			
			foreach (Material M in RockMat) {
				M.color = new Color (M.color.r, M.color.g, M.color.b, 0.5f);
			}	
		}
	}

	void BombApp(){
		if (bombMat != null) {
			
			foreach (Material M in bombMat) {
				M.color = new Color (M.color.r, M.color.g, M.color.b, 1f);
			}	
		}
	}
	
	void BombTran(){
		
		if (bombMat != null && !BS.isShooted) {
			
			foreach (Material M in bombMat) {
				M.color = new Color (M.color.r, M.color.g, M.color.b, 0.5f);
			}	
		}
	}

	void OilApp(){
		if (oilMat != null) {
			
			foreach (Material M in oilMat) {
				M.color = new Color (M.color.r, M.color.g, M.color.b, 1f);
			}	
		}
	}
	
	void OilTran(){
		
		if (oilMat != null && !OS.isShooted) {
			
			foreach (Material M in oilMat) {
				M.color = new Color (M.color.r, M.color.g, M.color.b, 0.5f);
			}	
		}
	}

	void UpdateColor(){

		if (RS != null && (!RS.isSelected || RS.isShooted)) {
			RockApp();
		}

		if (BS != null && (!BS.isSelected || BS.isShooted)) {
			BombApp();	
		}

		if (OS != null && (!OS.isSelected || OS.isShooted)) {
			OilApp();
		}

		if (RS != null && RS.isSelected) {

			BombTran();
			OilTran();
			RockApp();
		}

		if (BS != null && BS.isSelected) {
			
			RockTran();
			OilTran();
			BombApp();
		}

		if (OS != null && OS.isSelected) {


			RockTran();
			BombTran();
			OilApp();
		}


	}
}
