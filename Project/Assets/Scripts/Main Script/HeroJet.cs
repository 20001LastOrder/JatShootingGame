using UnityEngine;
using System.Collections;
//***********************************
//     Class Description
//The class of the player jet
//************************************
public class HeroJet : MonoBehaviour{

	//*****************class variables*********************
	int hP=100;  //Hp
	int bNum=10;  //beam number
	float bTime=8f;  //beam sword time
	int mNum=10;  //missle time
	int targetScore=1000;  //target socre of the game
	Global dataPass;
	int currentScore=0;  //current score in the game
	GameObject xJet;  //game model
	GameObject beam1; //beam type 1
	GameObject beam2; //beam type2
	GameObject missle; //missle mode
	GameObject target; //on the top of xJet
	Animator anime;  //animation controller
	GameObject aim1,aim2,aim3,aim4; //release point
	GameObject explosion;  // exoplosing effect

	//**************************************************
	//purpose: initialize the class
	//parameter: none
	//return: none
	//**************************************************
	void Awake(){
		if(this!=null){
			dataPass=new Global();
			targetScore=(int)dataPass.getTargetNumber();
		}
	}
	void Start(){

		xJet=GameObject.Find ("X jet");
		target=GameObject.Find ("target");
		aim1=GameObject.Find("aim");
		aim2=GameObject.Find("aim 1");
		aim3=GameObject.Find("aim 2");
		aim4=GameObject.Find("aim 3");
		if(xJet!=null){
			anime = xJet.GetComponent<Animator> ();
		}
		beam1 = (GameObject)Resources.Load ("Beam1",typeof(GameObject));
		beam2 = (GameObject)Resources.Load ("Beam2",typeof(GameObject));
		missle= (GameObject)Resources.Load ("Missle",typeof(GameObject));
		explosion=(GameObject)Resources.Load ("Explosion",typeof(GameObject));
	} //end start

	//*****************begin methods********************

	//*****************accessor*************************
	//**************************************************
	//purpose: get hP
	//parameter: none
	//return: hP
	//**************************************************
	public int getHP(){
		return(hP);
	}  //end getHp

	//**************************************************
	//purpose: set hP
	//parameter: hP
	//return: none
	//**************************************************
	public void setHp(int h){
		hP=h;
	} //end sethP

	//**************************************************
	//purpose: get current score
	//parameter: none
	//return: currentScore
	//**************************************************
	public int getCurrentScore(){
		return currentScore;
	} //end getCurrentScore

	//**************************************************
	//purpose: set current score
	//parameter: new score
	//return: none
	//**************************************************
	public void setCurrentScore(int score){
		currentScore=score;
	}  //end setCurrentScore

	//**************************************************
	//purpose: get target score of the game
	//parameter: none
	//return: targentScore
	//**************************************************
	public int getTargetScore(){
		return targetScore;
	} //end getTargetScore

	//**************************************************
	//purpose: release long beam sword
	//parameter: release point
	//return: none
	//**************************************************
	 void fire1(GameObject aim){
		Instantiate (beam1, aim.transform.position, aim.transform.rotation);
	}  //end fire1

	//**************************************************
	//purpose: fire beam
	//parameter: fire piont
	//return: none
	//**************************************************
	 void fire2(GameObject aim){
		Instantiate (beam2, aim.transform.position, aim.transform.rotation);
	}  //end fire2

	//**************************************************
	//purpose: get beam sword time
	//parameter: none
	//return: bTime
	//**************************************************
	public float getBTime(){
		return bTime;
	} //end getBTime

	//**************************************************
	//purpose: get beam number
	//parameter: none
	//return: bNum
	//**************************************************
	public int getBNum(){
		return bNum;
	} //end get BNum

	//**************************************************
	//purpose: get missile time
	//parameter: none
	//return: mNum
	//**************************************************
	public int getMNum(){
		return mNum;
	} //end getMNum

	//**************************************************
	//purpose: set beam sword time
	//parameter: new time
	//return: none
	//**************************************************
	public void setBTime(float b){
		bTime = b;
	} //end setBTIme

	//**************************************************
	//purpose: set beam number
	//parameter: new beam number
	//return: none
	//**************************************************
	public void setBNum(int b){
		bNum=b;
	} //end setBNum

	//**************************************************
	//purpose: set missile number
	//parameter: new missile numebr
	//return: none
	//**************************************************
	public void setMNum(int m){
		mNum=m;
	} //end setMNum


	//************************mutator********************
	//**************************************************
	//purpose: release beam sword
	//parameter: none
	//return: none
	//**************************************************
	public void releaseBeam(){
		//sword time control
		if (bTime >0) {
			this.fire1 (aim1);
			this.fire1 (aim2);
		} //end if
	} //end releaseBeam
	
	//**************************************************
	//purpose: fire beam missile
	//parameter: none
	//return: none
	//**************************************************
	public void fireBeam(){
		//beam number control
		if (bNum >0) {
			this.fire2 (aim3);
			this.fire2 (aim4);
			bNum--;
		} //end if
	}  //end fireBeam
	
	//**************************************************
	//purpose: lock on the enemies
	//parameter: the transform of player
	//return: none
	//**************************************************
	public void lockOn(Transform t){
		//lock on the Enemy1
		GameObject[] e = GameObject.FindGameObjectsWithTag ("Enemy1");
		doLockCheck(t,e);
		//lock on the Enemy2
		e = GameObject.FindGameObjectsWithTag ("Enemy2");
		doLockCheck(t,e);
		//lock on the Enemy3
		e = GameObject.FindGameObjectsWithTag ("Enemy3");
		doLockCheck(t,e);
	} //end lockOn
	
	//**************************************************
	//purpose: check the conditions of lock on
	//parameter: transform of player, the enemy array
	//return: none
	//**************************************************
	void doLockCheck(Transform t,GameObject[] e){
		foreach(GameObject g in e){
			//get Vector from the object to xJet
			Vector3 line= g.transform.position-xJet.transform.position;
			//get Vector from the top of xJet to xJet
			Vector3 locate=target.transform.position-xJet.transform.position;
			//get the angle between these two vectors
			float angle=Vector3.Angle (locate,line);
			//lock On condition
			if(angle<10){
				t.LookAt(g.transform);
				Debug.Log("Target success");
				break;
			} //end if
		}//end loop
	} //end doLockCheck

	//**************************************************
	//purpose: fire
	//parameter: none
	//return: none
	//**************************************************
	public void fire ()
	{
		if (mNum > 0) {
			mNum=mNum--;
			Vector3 c=target.transform.position;
		 	Instantiate (missle, c, xJet.transform.rotation);
			mNum=mNum-1;
		}
	}  //end fire

	//**************************************************
	//purpose: destroy jey
	//parameter: none
	//return: none
	//**************************************************
	public void explode ()
	{
		if(xJet!=null){
			GameObject e=Instantiate(explosion,xJet.transform.position,xJet.transform.rotation)as GameObject;
			GameObject.Destroy(xJet.gameObject);
			GameObject.Destroy(e,10);
		}
	}  //end explode
	//**************************************************
	//purpose: speed up
	//parameter: none
	//return: none
	//**************************************************
	public void speedUp ()
	{
		if(anime!=null){
			anime.SetBool ("Accelarate", true);
		}
	}  //end speedUp
	//**************************************************
	//purpose: speed normal
	//parameter: none
	//return: none
	//**************************************************
	public void speedNormal(){
		if(anime!=null){
			anime.SetBool ("Accelarate",false);
		}
	} //end Speed normal
	//**************************************************
	//purpose: pass horizontal rotate parameter
	//parameter: inputH
	//return: none
	//**************************************************
	public void setRotateFloat(float h){
		if(anime!=null){
			anime.SetFloat ("inputH", h);
		}
	}  //end setRotateFloat

	//**************************************************
	//purpose: pass vertical rotate parameter
	//parameter: inputV
	//return: none
	//**************************************************
	public void setUpDownFloat(float v)
	{
		if(anime!=null){
			anime.SetFloat ("inputV",v);
		}
	}  //end setUpDownFloat

	public void setTargetScore(int s){
		targetScore=s;
	}

	//****************Collision checker*****************
	//**************************************************
	//purpose: collision check
	//parameter: none
	//return: none
	//**************************************************
	void OnTriggerEnter(Collider other){
		if(other.tag=="Enemy1"||other.tag=="Enemy2"||other.tag=="Enemy3"){
			hP=hP-90;
		}
	} //end OntriggerEnter


}   //end class
