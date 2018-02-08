using UnityEngine;
using System.Collections;
//this is the class of enemy2's radar dot
public class Enemy2RadarDot :  RadarDot {
	//the transform of the enemy jet
	Transform enemyJet;
	//radar dots
	GameObject radarDot;
	GameObject borderDot;
	#region RadarDot implementation
	//initiate the radar dot
	public void initiateDot ()
	{
		GameObject dot = (GameObject)Resources.Load ("Enemy1Radar",typeof(GameObject));
		radarDot=MonoBehaviour.Instantiate(dot,enemyJet.position,enemyJet.rotation)as GameObject;
		//set parent object to the enemy jet
		radarDot.transform.parent=enemyJet;
		borderDot=MonoBehaviour.Instantiate(dot,enemyJet.position,enemyJet.rotation)as GameObject;
		borderDot.transform.parent=enemyJet;
		//make the borderDot invisible at this time
		borderDot.layer=LayerMask.NameToLayer("invisible");
	} //end initiateDot

	public GameObject getRadarDot(){
		return radarDot;
	} //end getRadarDot

	public GameObject getBorderDot(){
		return borderDot;
	} //end getBorderdDot

	//add the transform of the jet to the radar dot
	public Enemy2RadarDot(Transform t){
		enemyJet=t;

	} //end Enemy1RadarDot(initated)

	#endregion

} //end class
