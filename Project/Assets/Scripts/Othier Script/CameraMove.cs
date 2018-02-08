using UnityEngine;
using System.Collections;
//***********************************
//     Class Description
//The class of the camera and jet 
//control, use to control the action
//of the camera and the player jet
//************************************
public class CameraMove : MonoBehaviour {
	//class varibles
	HeroJet j; //player class
	float inputH;  //horizontal rotate parameter
	float inputV;  //vertically rotate parameter
	Vector3 speed=new Vector3(0, 0, 2); //speed of motion
	MainGUI myGUI; //GUI Performance
	string info;   // info of the jet
	string scoreDialog; //visual score
	bool chargeBeam; //controller of beam charge
	bool chargeSword; //controller of beam sword charge
	bool chargeMissile; //controller of missile charge
	float lastTime; //record the time of last charging
	RuntimeGUI RUI;

	// Use this for initialization
	void Start () {
		Time.timeScale=0.8f;
		j = GameObject.Find ("X jet").GetComponent<HeroJet> ();

		myGUI=GameObject.Find("ControlTool").GetComponent<MainGUI>();
		RUI=GameObject.Find("Wall 1").GetComponent<RuntimeGUI>();
		lastTime=Time.time;

	} //end start
	
	// Update is called once per frame
	void FixedUpdate () {
		if(j.getHP()>=0){
			rotateHorizontally ();
			rotateupDown ();
			moving ();

			//release beam sword
			if (Input.GetKeyDown("k")) {
				if(!chargeSword){
					j.releaseBeam ();
				} //end if
			}// end if

			//decline sword beam time when hold on "k"
			if(Input.GetKey("k")){
				if(!chargeSword){
					j.setBTime(j.getBTime()-0.1f);
				} //end if
			}

			if(Input.GetKeyDown("f")){
				EnemyBuilder e=new EnemyShipBuilder();
				Enemy enemy1=e.orderAnEnemy(0);
				enemy1.fireBeam();
			}

			// fire beam
			if(Input.GetKeyDown("j")){
				j.fireBeam();

			}//end if

			//fire missle
			if(Input.GetKeyDown("l")){
				j.fire();
			}//end if

			//automatically lock on
			if (Input.GetKey ("i")) {
				j.lockOn (this.transform);
			} //end if

			//change UI color 
			if(j.getHP()<=40){
				myGUI.changeToRed();
				myGUI.caution();
			}else if(j.getHP()>40&&j.getHP()<80){
				myGUI.changeToYellow();
			}else{
				myGUI.changeToGreen();
			} //end if 



			//set info on the screen
			info="Beam Missle Number: "+j.getBNum();
			info+="\nMissle Number: "+j.getMNum();
			info+="\nBeam Sword Time: "+(int)j.getBTime();
			myGUI.showInfo(info);

			//set Score on the screen
			scoreDialog="Target Score:";
			scoreDialog+="\n"+j.getTargetScore();
			scoreDialog+="\nCurrent Score: ";
			scoreDialog+="\n"+j.getCurrentScore();
			myGUI.showScore(scoreDialog);

			// ************charge beam and missile******************
			if(Time.time-lastTime>1f){
				lastTime=Time.time;
				if(chargeBeam){
					j.setBNum(j.getBNum()+1);
				} //end if
				if(chargeMissile){
					j.setMNum(j.getMNum()+1);
				} //end if
				if(chargeSword){
					j.setBTime(j.getBTime()+1f);
				} //end if

				if(j.getHP()<100){
					j.setHp(j.getHP()+5);
				}else{
					j.setHp(100);
				} //end if
			} //end if


			//acceleration
			SpeedUp ();
		} //end if
		
		// ***********set controller value**********************
		if(j.getBNum()<=0){
			chargeBeam=true;
		}else if(j.getBNum()>=10){
			chargeBeam=false;
		} //end if
		if(j.getMNum()<=0){
			chargeMissile=true;
		}else if(j.getMNum()>=10){
			chargeMissile=false;
		} //end if
		if(j.getBTime()<0){
			chargeSword=true;
		}else if(j.getBTime()>8.0f){
			chargeSword=false;
		} //end if
		
		//****************in game GUI****************************
		if(Input.GetKeyDown("p")){
			RUI.paused=true;
		}
		
		if(j.getHP()<=0){
			myGUI.youLose();
			RUI.lose=true;
		}
		
		if(j.getCurrentScore()>=j.getTargetScore()){
			myGUI.youWin();
			RUI.win=true;
			RUI.paused=true;
		}

		//player jet explosion
		if(j.getHP()<=0){
			j.explode();
		} //end if
	}  //end update

	//**************************************************
	//purpose: Horizontally rotate
	//parameter: none
	//return: none
	//**************************************************
	void rotateHorizontally(){
		inputH=Input.GetAxis("Horizontal");
		j.setRotateFloat (inputH);
		float y = inputH * 2f;
		this.transform.Rotate (0, y, 0);
	} //end rotateHorizontally
	//**************************************************
	//purpose: vertically rotate
	//parameter: none
	//return: none
	//**************************************************
	void rotateupDown(){
		inputV=Input.GetAxis("Vertical");
		j.setUpDownFloat (inputV);
		float x = -inputV ;
		this.transform.Rotate (x, 0, 0);
	} //end rotateUpDown

	//**************************************************
	//purpose: automatically moving
	//parameter: none
	//return: none
	//**************************************************

	void moving(){
		this.transform.Translate (speed);
	}  //end moving


	//**************************************************
	//purpose: speed controller
	//parameter: none
	//return: none
	//**************************************************
	void SpeedUp(){
		if (Input.GetKey ("h")) {
			j.speedUp ();
			if (speed.z < 4) {
				speed = new Vector3 (0, 0, speed.z + 0.3f);
			} else {
				speed = new Vector3 (0, 0, 4);
			} //end if
		} else {
			j.speedNormal();
			if (speed.z > 2) {
				speed = new Vector3 (0, 0, speed.z - 0.5f);
			} else {
				speed = new Vector3 (0, 0, 2);
			} //end if
		} //end if
	} //end speedUp




} //end class
