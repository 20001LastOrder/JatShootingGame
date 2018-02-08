using UnityEngine;
using System.Collections;

public class Beam2 : BeamScript{
	GameObject explode;
	HeroJet j;
	// Use this for initialization
	void Start () {
		explode=loadExplosion();
		j=GameObject.Find("X jet").GetComponent<HeroJet>();
	}
	
	// Update is called once per frame
	void Update () {
		translate();
	}
	void OnParticleCollision(GameObject other){
		collisionHappen(other);
	}

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
