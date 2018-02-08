using UnityEngine;
using System.Collections;
//***********************************
//     Class Description
//The class for aerolite objects with
//behaviours and other stuffs
//************************************

public class Aerolite : MonoBehaviour {
	int hp=100;
	GameObject explode; //explosion effect
	GameObject load;
	GameObject radarObject;
	GameObject borderObject;
	// Use this for initialization
	void Awake () {

		explode=(GameObject)Resources.Load ("Explosion",typeof(GameObject));
		load=(GameObject)Resources.Load ("radarPoint",typeof(GameObject));
		radarObject=Instantiate(load,this.transform.position,this.transform.rotation)as GameObject;
		radarObject.transform.parent=this.transform;
		borderObject=Instantiate(load,this.transform.position,this.transform.rotation)as GameObject;
		borderObject.transform.parent=this.transform;

	} //end start
	
	// Update is called once per frame
	void Update () {
		//destroy the object when hp < 0
		if(hp<=0){
			GameObject e=Instantiate(explode,this.transform.position,this.transform.rotation)as GameObject;
			GameObject.Destroy (this.gameObject);
			GameObject.Destroy(e,10);
		} //end if
	} //end Update

	//**********************accessor********************
	//**************************************************
	//purpose: Get hp value
	//parameter: none
	//return: hp value
	//**************************************************
	public int getHP(){
		return(hp);
	} //end getHP

	//**************************************************
	//purpose: set hp value
	//parameter: hP value
	//return: none
	//**************************************************
	public void setHP(int h){
		hp=h;
	} //end setHP

	
	//**************************************************
	//purpose: get radar object
	//parameter: none
	//return: radar object
	//**************************************************
	public GameObject getRadarObject(){
		return(this.radarObject);
	} //end getRadarObject

	//**************************************************
	//purpose: get border object
	//parameter: none
	//return: radar object
	//**************************************************
	public GameObject getBorderObject(){
		return(this.borderObject);
	} //end getRadarObject



	//********************collision checker*************
	//collision check
	void OnTriggerEnter(Collider other){
		hp=hp-40;
	} //end OntriggerEnter

} //end class
