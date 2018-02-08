using UnityEngine;
using System.Collections;
//***********************************
//     class Description
// this is the class for the building 
// of enemy 1
//************************************
public class Enemy1Factory : EnemyFactory{
	#region EnemyFactory implementation

	public EnemyJet addJet ()
	{
		return new Enemy1Jet();
	} //end addJet

	#endregion

	#region EnemyFactory implementation

	public BeamWeapon addBeam ()
	{
		return new Enemy1Beam();
	} //end addBeam


	public RadarDot addRadarDot (Transform t)
	{
		return new Enemy1RadarDot(t);
	} //end addRadarDot


	#endregion

} //end class
