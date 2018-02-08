using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//***********************************
//     Class Description
// This class will set enemies on the 
// 2 demensional rador.
// and set navigator to the game
//************************************
//Remainder: Enemy may overlap, Beam needs some action, auto-targeting on enemies






public class Radar : MonoBehaviour {
	//**************************Class variables**************
	List<GameObject> aerolites;  //models of aerolitte
	int areaDistance=300;  //initialize area
	int AerolitelLength =0; //length 
	GameObject aero;
	public float radarDistance;//area of rader
	public Transform help; // the position of player
	public Transform herojet;
	theDistanceList objects; //a list store enemies
	GameObject target; //target enemy
	GameObject navigation; //navigator
	Aerolite ae; //target enemy proporty
	public int enemyNeeded = 2;
	List<Enemy> enemies;
	TheStack<Enemy> stack;

	// Use this for initialization
	void Start () {
		navigation=GameObject.Find("Navigation"); //get navigator
		objects=new theDistanceList(); //creat a new list
		aerolites=new List<GameObject>(); //list for aerolite
		aero = (GameObject)Resources.Load ("aerplite",typeof(GameObject)); //load profab

		//creat enemies when game started
		while (AerolitelLength<6){
			createArolites();
			AerolitelLength++;
		}  //end loop

		//put target in navigation list
		for(int i=0;i<aerolites.Count;i++){
			objects.distanceInsert(aerolites[i],help);
		} //end loop

		target=objects.getPointor(); //let navigator point the nearest object
		ae=target.GetComponent<Aerolite>(); //get the script
		changeColor(ae.getBorderObject(),Color.white); //change the color of two kinds of objects
		changeColor(ae.getRadarObject(),Color.white); 
		enemies=new List<Enemy>();
		stack=new TheStack<Enemy>(enemyNeeded);
	}  //end start
	
	// Update is called once per frame
	// It will stop when time.timescale=0

	void FixedUpdate () {
		this.transform.Rotate (0, 0, -90*Time.deltaTime); //rotate the rador
		//creat new enemy when necessary
		for(int i=0;i<enemyNeeded;i++){
			enemies.Add(creatEnemies());
			//stack.push(enemies[i]);
			enemyNeeded--;
		} //end loop

		stack.groupPush(enemies);
		float currentTime=Time.time;
		// do things for enemies
		for(int i=0;i<stack.getSize();i++){
			Enemy e=stack.peek();
			if(e!=null){
			if(e.getTranform()!=null){
					e.getTranform().Translate(e.getTranform().forward*2);
					if(currentTime%e.getTimer()!=0){
						followHero(e.getTranform());
					}else{
						e.getTranform().LookAt(herojet);
						e.fireBeam();

					}
					if(currentTime%1==0){
						e.fireBeam ();
					}
				}
			}
			stack.pop();
		}


		while (AerolitelLength<3){
			createArolites();
			AerolitelLength++;
			//change the color of the old target
			if(target!=null){
				changeColor(ae.getBorderObject(),Color.red);
				changeColor(ae.getRadarObject(),Color.red);
			} //end if
			//target to the new object
			navigate();
		}  //end loop

	
		for(int i=0;i<enemies.Count;i++){
			if(enemies[i].getTranform()!=null){
				Enemy e=enemies[i];
				setRadarDot(e.getTranform(),e.getRadarDot(),e.getBorderDot());
			}else{
				enemies.RemoveAt(i);
				enemyNeeded++;
			} //end if
		} //end loop

		for (int i=0; i<aerolites.Count; i++) {
			//set radarObject to bodrer Object
			if(aerolites[i]!=null){
				Aerolite aerolite=aerolites[i].GetComponent<Aerolite>();
				GameObject radarObject=aerolite.getRadarObject();
				GameObject borderObject=aerolite.getBorderObject();
				//change the performance to the borderObject when the enemy is too far
				setRadarDot(aerolites[i].transform,radarObject,borderObject);
			}else{
				//delete that object if it was destroyed
				aerolites.RemoveAt(i);
				AerolitelLength--;
			} //end
		}  //end loop

		//change to another target
		if(Input.GetKeyDown("e")){

			objects.next();
			changeTarget();
		} //end if

		if(Input.GetKeyDown("q")){
			objects.last();
			changeTarget();
		} //end if

		//let the navigator point to the target
		if(target!=null){
			navigation.transform.LookAt(target.transform);
		} //end if

	}  //end FixedUpdate

	void followHero(Transform t){
		if(herojet!=null){
			Quaternion rotation=Quaternion.LookRotation(herojet.position-t.position);
			t.rotation=Quaternion.Slerp(t.rotation,rotation,6.0f*Time.deltaTime);
		}
	}


	void randomRotate(Transform t){
		float f1=Random.Range(-90,90);
		float f2=Random.Range(-90,90);
		float f3=Random.Range(-90,90);
		Quaternion rotate=new Quaternion(f1,f2,f3,0);
		t.rotation=Quaternion.Slerp(t.rotation,rotate,6);
	}


	Enemy creatEnemies(){
		int n=Random.Range(1,3);
		EnemyBuilder e=new EnemyShipBuilder();
		Enemy enemy=e.orderAnEnemy(n);
		return enemy;
	} //end create Enemies

	void setRadarDot(Transform o,GameObject radarObject,GameObject borderObject){
			//change the performance to the borderObject when the enemy is too far
			if(Vector3.Distance(o.position,this.transform.position)>radarDistance){
				help.LookAt(radarObject.transform);
				borderObject.transform.position=this.transform.position+radarDistance*help.forward;
				borderObject.layer=LayerMask.NameToLayer("player");
				radarObject.layer=LayerMask.NameToLayer("invisible");
			}else{
				//set border Object back to radar Object
				borderObject.layer=LayerMask.NameToLayer("invisible");
				radarObject.layer=LayerMask.NameToLayer("player");
			} //end if
	}
	//end


	//***************************************************************************
	//purpose: create arolite objects
	//parameter:none
	//return:none
	//**************************************************************************
	void createArolites(){
	
		//arolites posision
		Vector3 position=Random.insideUnitSphere*areaDistance+this.transform.position;
		GameObject o=Instantiate(aero,position,this.transform.rotation)as GameObject;
		aerolites.Add (o);
		Aerolite aerolite=o.GetComponent<Aerolite>();
		GameObject borderObject=aerolite.getBorderObject();
		borderObject.layer=LayerMask.NameToLayer("invisible");
	}  //end create Arolites

	//***************************************************************************
	//purpose: set the target (rerange the objects)
	//parameter:none
	//return:none
	//**************************************************************************
	void navigate(){
		objects.emptyAll();
		for(int i=0;i<aerolites.Count;i++){
			objects.distanceInsert(aerolites[i],help);
		}
		target=objects.getPointor();
		ae=target.GetComponent<Aerolite>();
		changeColor(ae.getBorderObject(),Color.white);
		changeColor(ae.getRadarObject(),Color.white);
	} //end navigate

	//***************************************************************************
	//purpose: change the target 
	//parameter:none
	//return:none
	//**************************************************************************
	void changeTarget(){
		changeColor(ae.getBorderObject(),Color.red);
		changeColor(ae.getRadarObject(),Color.red);
		target=objects.getPointor();
		ae=target.GetComponent<Aerolite>();
		changeColor(ae.getBorderObject(),Color.white);
		changeColor(ae.getRadarObject(),Color.white);
	} //end changeTarget

	//***************************************************************************
	//purpose: change color of the objects
	//parameter:object, color
	//return:none
	//**************************************************************************
	void changeColor(GameObject a,Color c){
		a.GetComponent<Renderer>().material.color=c;
	} //end changeColor
} //end class
