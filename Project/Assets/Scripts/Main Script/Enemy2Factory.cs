using UnityEngine;
using System.Collections;
//***********************************
//     class Description
// this is the class for the building 
// of enemy 2
//************************************
public class Enemy2Factory : EnemyFactory {
	#region EnemyFactory implementation
	public BeamWeapon addBeam ()
	{
		return new Enemy2Beam();
	} //end addBeam
   

	public RadarDot addRadarDot (Transform t)
	{
		return new Enemy2RadarDot(t);
	} //end addRadarDot

	public EnemyJet addJet ()
	{
		return new Enemy2Jet();
	} //end addJet

	#endregion



} //end class
