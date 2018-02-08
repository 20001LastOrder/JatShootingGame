using UnityEngine;
using System.Collections;
//              class destription
//this is the beam weapon of the first enemy
public class Enemy1Beam :BeamWeapon {
	GameObject beam;
	#region BeamWeapon implementation
	//initiate the beam and link it the the model
	public Enemy1Beam(){
		beam=(GameObject)Resources.Load ("EnemyBeam",typeof(GameObject));
	} //end Enemy1Beam(default)
	//Creat the beam 
	public void instantiateTheBeam (Transform n)
	{
		MonoBehaviour.Instantiate(beam,n.position,n.rotation);
	} //end instantiateTheBeam


	#endregion

} //end class
