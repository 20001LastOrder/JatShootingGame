using UnityEngine;
using System.Collections;
//**********************************
//        Class Description
//this is a clss that contains all 
//properties of enemies.
//************************************
public abstract class Enemy {
	protected int timer; //unique timer
	protected BeamWeapon beam; //beam weapon
	protected RadarDot radarDot; //picture on radar
	protected EnemyJet enemyJet; //the main jet
	protected EnemyFactory factory; //the factory used to create it

	//***********************************
	//purpose: make an enemy
	//parameter: none
	//return: none
	//***********************************
	public void makeEnemy(){
		enemyJet=factory.addJet();
		instantiateEnemy();
		beam=factory.addBeam();
		radarDot=factory.addRadarDot(enemyJet.getTransform());
		radarDot.initiateDot();
	} //end makeEnemy

	//***********************************
	//purpose: fire beam
	//parameter: none
	//return: none
	//***********************************
	public void fireBeam(){
		beam.instantiateTheBeam(enemyJet.getTransform());
	} //end fireBeam

	//***********************************
	//purpose: instantiate the enemy jet
	//parameter: none
	//return: none
	//***********************************
	public void instantiateEnemy(){
		enemyJet .initiateSelf();
	} //end fireBeam

	//***********************************
	//purpose: destroy the enemy
	//parameter: none
	//return: none
	//***********************************
	public void destroyItSelf(){
		enemyJet.destroy();
		GameObject.Destroy(radarDot.getRadarDot());
		GameObject.Destroy(radarDot.getBorderDot());
	} //end destroyItSelf

	//***********************************
	//purpose: get the timer
	//parameter: none
	//return: timer (int)
	//***********************************
	public int getTimer(){
		return timer;
	} //end getTimer

	//***********************************
	//purpose: make the enemy flying
	//parameter: none
	//return: none
	//***********************************
	public void forward(){
		enemyJet.forward();
	} //end forwaed

	//***********************************
	//purpose: get the radar dot
	//parameter: none
	//return: picture on the radar(GameObject)
	//***********************************
	public GameObject getRadarDot(){
		return radarDot.getRadarDot();
	} //end getRadarDot
	
	//***********************************
	//purpose: get the border dot
	//parameter: none
	//return: Picture on the border of the radar(GameObject)
	//***********************************
	public GameObject getBorderDot(){
		return radarDot.getBorderDot();
	} //end getBorderDot

	//***********************************
	//purpose: get the transform
	//parameter: none
	//return: transform of the enemy
	//***********************************
	public Transform getTranform(){
		return enemyJet.getTransform();
	} //end getTranform
} //end class
