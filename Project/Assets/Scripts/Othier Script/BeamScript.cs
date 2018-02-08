using UnityEngine;
using System.Collections;

public abstract class BeamScript : MonoBehaviour {
	protected abstract void hitTarget(GameObject other);
	protected abstract void collisionHappen(GameObject other);
	protected void translate(){
		this.transform.Translate (new Vector3(0,0,12f));
		GameObject.Destroy (this.gameObject, 5);
	}

	protected GameObject loadExplosion(){
		return (GameObject)Resources.Load ("Explosion",typeof(GameObject));
	}
}
