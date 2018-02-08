using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//***********************************
//     Class Description
//this class will creat a UI which can
//be seen during the game
//************************************
public class MainGUI : MonoBehaviour {
	Text txt1;  //txt in the info window
	Text txt2;  //txt in the caution window
	Text score; //txt of the score info
	Text win; //txt of wining
	Text lose; //txt of losing
	Image rect; //txt background
	Image scoreBack; //txt background
	float cautionValue=0; //transparent value controller
	bool increaseAValue=true; // caution txt controller
	//**************************************************
	//purpose: initiate variables
	//parameter: none
	//return: none
	//**************************************************
	void Start () {
		//link the objects to the objects in scenes
		lose=GameObject.Find("lose").GetComponent<Text>();
		win=GameObject.Find("win").GetComponent<Text>();
		txt1=GameObject.Find("Info").GetComponent<Text>();
		txt2=GameObject.Find("Caution").GetComponent<Text>();
		rect=GameObject.Find("Image1").GetComponent<Image>();
		score=GameObject.Find("Score").GetComponent<Text>();
		scoreBack=GameObject.Find("Image2").GetComponent<Image>();
	} //end start

	//**************************************************
	//purpose: show info in txt window 1
	//parameter: string info
	//return: none
	//**************************************************
	public void showInfo(string i){
		txt1.text=i;
	} //end showInfo

	//**************************************************
	//purpose: show score in the score txt window
	//parameter: string score
	//return: none
	//**************************************************
	public void showScore(string i){
		score.text=i;
	} //end showScore

	//**************************************************
	//purpose: show win dialogue when wining
	//parameter: none
	//return: none
	//**************************************************
	public void youWin(){
		win.color=new Color(255,0,0,1);
	} //end youWin

	//**************************************************
	//purpose: show lose dialogue when losing
	//parameter: none
	//return: none
	//**************************************************
	public void youLose(){
		lose.color=Color.blue;
	} //end youLose

	//**************************************************
	//purpose: change UI color to Yellow
	//parameter: none
	//return: none
	//**************************************************
	public void changeToYellow(){
		rect.color=new Color(190,190,0,0.3f);
		scoreBack.color=new Color(190,190,0,0.3f);
		txt1.color=new Color(190,190,0);
		txt2.color=new Color(0,0,0,0);
	} //end changeToYellow

	//**************************************************
	//purpose: change UI color to red
	//parameter: none
	//return: none
	//**************************************************
	public void changeToRed(){
		rect.color=new Color(190,0,0,0.3f);
		scoreBack.color=new Color(190,0,0,0.3f);
		txt1.color=new Color(190,0,0);
	} //end changeToRed

	//**************************************************
	//purpose: change UI color to green
	//parameter: none
	//return: none
	//**************************************************
	public void changeToGreen(){
		rect.color=new Color(0,190,0,0.3f);
		scoreBack.color=new Color(0,190,0,0.3f);
		txt1.color=new Color(0,190,0);
		txt2.color=new Color(0,0,0,0);
	} //end changeToGreen

	//**************************************************
	//purpose: set caution info
	//parameter: none
	//return: none
	//**************************************************
	public void caution(){
		//control the apperence of Caution slogan
		if(cautionValue<=0){
			increaseAValue=true;
		}else if (cautionValue>=1){
			increaseAValue=false;
		} //end if
		//control transparent value of Caution Slogan
		if(increaseAValue){
			txt2.color=new Color(255,0,0,cautionValue);
			cautionValue=cautionValue+0.1f;
		}else{
			txt2.color=new Color(255,0,0,cautionValue);
			cautionValue=cautionValue-0.1f;
		} //end if
	}  //end caution


} //end class
