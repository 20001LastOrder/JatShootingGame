using UnityEngine;
using System.Collections;

public class EnemyJetScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if(other.tag=="Hero"||other.tag=="Untagged"){
			GameObject.Destroy(this.gameObject);
		} //end if
	} 

}
