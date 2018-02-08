using UnityEngine;
using System.Collections;
//***********************************
//     Interface Description
//this is a class of the general enemy 
//factory
//************************************

public interface EnemyFactory  {
	BeamWeapon addBeam();
	RadarDot addRadarDot(Transform t);
	EnemyJet addJet();
} //end interface
