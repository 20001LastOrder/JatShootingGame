using UnityEngine;
using System.Collections;
//this is the class of the second enemy beam
public class Enemy2Beam : BeamWeapon{

	//GameObject explode;
	GameObject beam;
	#region BeamWeapon implementation
	//initiate the beam and link it the the model
	public Enemy2Beam(){
		beam=(GameObject)Resources.Load ("EnemyBeam",typeof(GameObject));
	} //end Enemy2Beam(default)
	//instantiate the beam
	public void instantiateTheBeam (Transform n)
	{
		beam=(GameObject)Resources.Load ("EnemyBeam",typeof(GameObject));
		MonoBehaviour.Instantiate(beam,n.position,n.rotation);
	} //end instantiateTheBeam
	#endregion
} //end class
