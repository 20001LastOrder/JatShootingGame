using UnityEngine;
using System.Collections;

public class EnemyBeam : BeamScript {
	GameObject explode;
	// Use this for initialization
	void Start () {
		explode=loadExplosion();
	}
	
	// Update is called once per frame
	void Update () {
		translate();
	}

	void OnParticleCollision(GameObject other){
		collisionHappen(other);
	}
	#region implemented abstract members of BeamScript

	protected override void hitTarget (GameObject other)
	{
		GameObject e=Instantiate(explode,other.transform.position,other.transform.rotation)as GameObject;
		GameObject.Destroy (other);
		GameObject.Destroy(e,10);
		Debug.Log ("Collision p succeed");
	}

	protected override void collisionHappen (GameObject other)
	{
		if(other.tag=="Enemy1"){
			hitTarget(other);
		}

		if(other.tag=="Untagged"||other.tag=="Hero"){
			GameObject.Find("X jet").GetComponent<HeroJet>().setHp(other.GetComponent<HeroJet>().getHP()-30);
		}
	}

	#endregion
}
