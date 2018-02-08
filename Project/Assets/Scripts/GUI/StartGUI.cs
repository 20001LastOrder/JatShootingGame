using UnityEngine;
using System.Collections;
//***********************************
//     Class Description
//Controller of the Start Menu UI
//************************************
public class StartGUI :MonoBehaviour {
	bool setting=false; //whether finish setting or not
	float score =1000;     //the target score setting

	//**********************************************
	//purpose: change setting value when finish setting
	//parameter:none
	//return:none
	//**********************************************
	public void finishSetting(){
		setting=true;
	} //end FinishSetting

	//**********************************************
	//purpose: end game
	//parameter:none
	//return:none
	//**********************************************
	public void endGame(){
		Application.Quit();
	} //end endGame

	//**********************************************
	//purpose: set target score
	//parameter:the target score
	//return:none
	//**********************************************
	public void setScore(float theScore){
		score=theScore;
	} //end setScore

	//**********************************************
	//purpose: get the target score
	//parameter:none
	//return:target score
	//**********************************************
	public float getScore(){
		return(score);
	} //end getScore

	//**********************************************
	//purpose: get the setting value
	//parameter:none
	//return:setting
	//**********************************************
	public bool getSetting(){
		return(setting);
	} //end getSetting

	//**********************************************
	//purpose: start game
	//parameter:none
	//return:none
	//**********************************************
	public void startGame(){
		Application.LoadLevel(1);
	} //end startGame

	//**********************************************
	//purpose: change the load condition to true when needed
	//parameter:none
	//return:none
	//**********************************************
	public void loadGame(){
		PlayerPrefs.SetString("Load","true");
		Application.LoadLevel(1);
	} //end loadGame
} //end class
