using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CamaraGUI : MonoBehaviour {
	StartGUI thisUI; //UI controller
	GameObject jet; //the jet object
	Animator anime; //the jew animator
	GameObject UI; //the UI window
	bool setting; //setting value
	bool play=false; //animator controller
	Text txt; //txt of the socre
	Text txtII; //txt of the setting notice info
	public GameObject visuleScore;
	public GameObject notice;
	Global dataPass;
	// do once when game started
	void Start(){
		dataPass=new Global();
		txt=visuleScore.GetComponent<Text>();
		txtII=notice.GetComponent<Text>();
		thisUI=GameObject.Find("Control").GetComponent<StartGUI>();
		jet=GameObject.Find ("Jet");
		UI=GameObject.Find("Canvas");
		anime=jet.GetComponent<Animator>();
	} //end start
	// Update is called once per frame
	void Update () {
		//get current setting value
		setting=thisUI.getSetting();
		//parse score to the txt
		txt.text= ""+thisUI.getScore();
		//camera move every time
		if(!play){
			this.transform.Translate(10*Time.deltaTime,0,0);
		} //end if
		//animation before game
		if(play){
			//destroy UI window
			GameObject.Destroy(UI);
			//reset the position of the camera
			this.transform.position=new Vector3(0,0,0);
			jet.transform.parent=null;
			//stop moving 
			this.transform.Translate(0,0,0);
			this.transform.LookAt(jet.transform);
			//play animation
			anime.SetBool("go",true);
		} //end if
		//start game when animation done
		if(jet.transform.position.sqrMagnitude-this.transform.position.sqrMagnitude>300000){
			thisUI.startGame();
		} //end if

		dataPass.setTargetNumber(thisUI.getScore());
	} //end Update

	//pass to the botton event
	public void startPlay(){
		if(setting){
			play=true;
		}else{
			txtII.text="Please set game at left side";
		} //end if
	} //end startPlay


} //end class
