using UnityEngine;
using System.Collections;

public class Beam1 : BeamScript{
	GameObject xJet;
	HeroJet j;
	GameObject explode;
	// Use this for initialization
	void Start () {
		xJet = GameObject.Find ("X jet");
		j=xJet.GetComponent<HeroJet>();
		explode=loadExplosion();
	} //end start
	
	// Update is called once per frame
	void Update () {
		//set the parent transform
		this.transform.parent = xJet.transform;
		//close beam 
		if (j.getBTime()<=0||Input.GetKeyUp("k")) {
			GameObject.Destroy(this.gameObject);
		} //end if
	} //end Update

	// Collision detector
	void OnParticleCollision(GameObject other){
		collisionHappen(other);
	} //end OnParticleCollision

	protected override void hitTarget(GameObject other){
		GameObject e=Instantiate(explode,other.transform.position,other.transform.rotation)as GameObject;
		GameObject.Destroy (other);
		GameObject.Destroy(e,10);
	}

	#region implemented abstract members of BeamScript

	protected override void collisionHappen (GameObject other)
	{
		if(other.tag=="Enemy1"){
			hitTarget(other);
			j.setCurrentScore(j.getCurrentScore()+200);
		}
		if(other.tag=="Enemy2"){
			hitTarget(other);
			j.setCurrentScore(j.getCurrentScore()+300);
		}
		if(other.tag=="Enemy3"){
			hitTarget(other);
			j.setCurrentScore(j.getCurrentScore()+400);
		}
	}

	#endregion
}
