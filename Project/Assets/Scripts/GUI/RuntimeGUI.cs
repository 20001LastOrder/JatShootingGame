using UnityEngine;
using System.Collections;
//***********************************
//     Class Description
//this class will provide a inside game
//GUI (Pause, win and lose)
//************************************
public class RuntimeGUI : MonoBehaviour {
	public bool paused=false; //whether game is pauseds
	public bool win=false; //whether game is won
	public bool lose=false; //wether game is lost
	bool saved=false; //whether the player clicked the save
	bool showNotice=false; //to control the appearence of notice
	bool doOnceOnly;  //do once only to load the game when necessary
	private Save saver; 
	private HeroJet jet;
	GameObject controller; // the gameobject of player

	//there are windows for inside game GUI
	private Rect pauseWindow=new Rect(600,200,250,400);
	private Rect noticeWindow=new Rect(600,300,200,200);
	private Rect loseWindow=new Rect(600,200,250,400);
	private Rect winWindow=new Rect(600,200,250,400);
	//initialize all objects
	void Start(){
		saver=new Save();
		jet=GameObject.Find("X jet").GetComponent<HeroJet>();
		controller=GameObject.Find("Controller");
		doOnceOnly=saver.loadControl();
	}  //Enemy1RadarDot start

	//used to call pause method
	void Update(){
	
		if(paused){
			Time.timeScale=0;
		} //end if
		if(doOnceOnly){
			//do this when we need to load
			//load info
			if(saver.loadControl()){
				//load info of player
				saver.loadPlayerInfo(jet);
				saver.loadPlayerPosition(controller.transform);
				//load info of enemies
				GameObject[] enemy1=GameObject.FindGameObjectsWithTag("Enemy1");
				loadEnemy(enemy1,"Enemy1");
				GameObject[] enemy2=GameObject.FindGameObjectsWithTag("Enemy2");
				loadEnemy(enemy2,"Enemy2");
				GameObject[] enemy3=GameObject.FindGameObjectsWithTag("Enemy3");
				loadEnemy(enemy3,"Enemy3");
				//close load
				saver.needToLoad(false);
				//never do this during runtime
				doOnceOnly=false;
			} //end if
		} //end if
	} //end Update

	//used for GUI (run once per frame)
	void OnGUI(){
		//creat pause menu
		if(paused&&!win&&!lose){
			GUI.Window(0,pauseWindow,pausedMenu,"Game paused!");
		} //end if
		//creat notice menu
		if(showNotice){
			GUI.Window (1,noticeWindow,notice,"");
		} //end if
		//creat lose menu
		if(lose){
			GUI.Window (2,loseWindow,loseMenu,"");
		} //end if
		//creat win menue
		if(win&&paused){
			GUI.Window(3,winWindow,winMenu,"");
		} //end is
	} //end OnGUI

	//**********************************************
	//purpose: creat the stuff in the paused window
	//parameter:Id of the window
	//return:none
	//**********************************************
	void pausedMenu(int windowID){
		//back to game
		if(GUI.Button(new Rect(50,70,150,50),"Back to Game")){
			paused=false;
			Time.timeScale=0.8f;
		} //end  if
		//save game 
		if(GUI.Button(new Rect(50,140,150,50),"Save")){
			saved=true;
			//save infomation of player
			saver.savePlayerInfo(jet);
			saver.savePlayerPosition(controller.transform);
			//save infomation of enemies
			GameObject[] enemy1=GameObject.FindGameObjectsWithTag("Enemy1");
			saveEnemy(enemy1,"Enemy1");
			GameObject[] enemy2=GameObject.FindGameObjectsWithTag("Enemy2");
			saveEnemy(enemy2,"Enemy2");
			GameObject[] enemy3=GameObject.FindGameObjectsWithTag("Enemy3");
			saveEnemy(enemy3,"Enemy3");

		} //end  if

		//back to main menu
		if(GUI.Button(new Rect(50,210,150,50),"Back to Main")){
			if(saved){
				restart();
				loadMain();
			}else{
				showNotice=true;
			} //end if

		} //end  if
	} //end pausedMenu

	//**********************************************
	//purpose:creat stuffs in the lose window
	//parameter:window id
	//return:none
	//**********************************************
	void loseMenu(int windowID){
		//load game
		if(GUI.Button(new Rect(50,70,150,50),"Load")){
			//open load
			PlayerPrefs.SetString("Load","true");
			//reload this scene
			Application.LoadLevel(1);
		} //end  if
		if(GUI.Button(new Rect(50,140,150,50),"Back to Main")){
			restart();
			loadMain();
		} //end  if
	} //end loseMenu

	//**********************************************
	//purpose: creat stuffs in the win menu
	//parameter:window ID
	//return:none
	//**********************************************
	void winMenu(int windowID){
		if(GUI.Button(new Rect(50,140,150,50),"Back to Main")){
			restart();
			loadMain();
		} //end  if
	} //end winMenu

	//**********************************************
	//purpose: creat stuff in the notice menu
	//parameter:window ID
	//return:none
	//**********************************************
	void notice(int windowID){

		GUI.Label(new Rect(0,0,200,100),"You do not save your game.\n Are you sure to quit?");
		if(GUI.Button(new Rect(0,80,60,20),"Yes")){
			restart();
			loadMain();
		} //end  if
		if(GUI.Button(new Rect(0,120,60,20),"No")){
			showNotice=false;
		} //end  if
	} //end notice

	//**********************************************
	//purpose: pause the game
	//parameter:none
	//return:none
	//**********************************************
	void pause(){
			Time.timeScale=0;
	} //end pause

	//**********************************************
	//purpose: restart the game
	//parameter:none
	//return:none
	//**********************************************
	void restart(){
		paused=false;
		Time.timeScale=0.8f;
	} //end restart

	//**********************************************
	//purpose: load the main menu
	//parameter:none
	//return:none
	//**********************************************
	void loadMain(){
		Application.LoadLevel(0);
	} //end load main

	//**********************************************
	//purpose: save an array of enemies
	//parameter:array enemys (array),key(string)
	//return:none
	//**********************************************
	void saveEnemy(GameObject[] e,string type){
		//save each enemy saperately
		for(int i=0;i<e.Length;i++){
			saver.saveEnemy(e[i].transform,i,type);
		} //end loop
	} //end saveEnemy

	//**********************************************
	//purpose: load an array of enemies
	//parameter:array enemys (array),key(string)
	//return:none
	//**********************************************
	void loadEnemy(GameObject[] e,string type){
		//load each enemy saperately
		for(int i=0;i<e.Length;i++){
			saver.loadEnemy(e[i].transform,i,type);
		} //end loop	 
	} //end loadEnemy

} //end class
