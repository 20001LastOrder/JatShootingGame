using UnityEngine;
using System.Collections;
//***********************************
//     Class Description
//this class is used to pass info from
//scene to scene
//************************************
public class Global {
	static float targetNumber;

	//***********************************
	//purpuse: set target number of the game
	//parameter: target(float)
	//return: none
	//************************************
	public void setTargetNumber(float target){
		targetNumber=target;
	} //end setTargetNumber

	//***********************************
	//purpuse: get target number of the game
	//parameter: none
	//return: targetNumber(float)
	//************************************
	public float getTargetNumber(){
		return targetNumber;
	} //end getTargetNumber

} //end class
