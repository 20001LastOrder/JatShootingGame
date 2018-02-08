using UnityEngine;
using System.Collections;
//***********************************
//     Class Description
// This is a class used to save the 
// info of player, enemies and load
// control.
//************************************
public class Save  {

	//**********************************************
	//purpose: save the infomation of the player
	//parameter:player class(HeroJet)
	//return:none
	//**********************************************
	public void savePlayerInfo(HeroJet jet){
		PlayerPrefs.SetInt("HP",jet.getHP());
		PlayerPrefs.SetInt("bNum",jet.getBNum());
		PlayerPrefs.SetFloat("bTime",jet.getBTime());
		PlayerPrefs.SetInt("mNum",jet.getMNum());
		PlayerPrefs.SetInt("targetScore",jet.getTargetScore());
		PlayerPrefs.SetInt("currentScore",jet.getCurrentScore());
		//write the info to the file
		PlayerPrefs.Save();
	} //end savePlayer

	//**********************************************
	//purpose: save the position of the player
	//parameter:player object class(GameObject)
	//return:none
	//**********************************************
	public void savePlayerPosition(Transform controller){
		PlayerPrefs.SetFloat("Player Position x",controller.position.x);
		PlayerPrefs.SetFloat("Player Position y",controller.position.y);
		PlayerPrefs.SetFloat("Player Position z",controller.position.z);
		PlayerPrefs.SetFloat("Player Rotation w",controller.rotation.w);
		PlayerPrefs.SetFloat("Player Rotation x",controller.rotation.x);
		PlayerPrefs.SetFloat("Player Rotation y",controller.rotation.y);
		PlayerPrefs.SetFloat("Player Rotation z",controller.rotation.z);
		PlayerPrefs.Save();
	} //end savePlayerPosition

	//**********************************************
	//purpose: save the position of an enemy
	//parameter:enemy object class(GameObject),index(int),key (String)
	//return:none
	//**********************************************
	public void saveEnemy(Transform e,int i,string type){
		PlayerPrefs.SetFloat(type+i+" Position x",e.position.x);
		PlayerPrefs.SetFloat(type+i+" Position y",e.position.y);
		PlayerPrefs.SetFloat(type+i+" Position z",e.position.z);
		PlayerPrefs.SetFloat(type+i+" Rotation w",e.rotation.w);
		PlayerPrefs.SetFloat(type+i+" Rotation x",e.rotation.x);
		PlayerPrefs.SetFloat(type+i+" Rotation y",e.rotation.y);
		PlayerPrefs.SetFloat(type+i+" Rotation z",e.rotation.z);
		PlayerPrefs.Save();
	} //end saveEnemy

	//**********************************************
	//purpose: load the infomation of the player
	//parameter:player class(HeroJet)
	//return:none
	//**********************************************
	public void loadPlayerInfo(HeroJet jet){
		jet.setHp(PlayerPrefs.GetInt("HP"));
		jet.setBNum(PlayerPrefs.GetInt("bNum"));
		jet.setBTime(PlayerPrefs.GetFloat("bTime"));
		jet.setMNum(PlayerPrefs.GetInt("mNum"));
		jet.setTargetScore(PlayerPrefs.GetInt("targetScore"));
		jet.setCurrentScore(PlayerPrefs.GetInt("currentScore"));
	} //end loadPlayerInfo

	//**********************************************
	//purpose: load the position of the player
	//parameter:player object class(GameObject)
	//return:none
	//**********************************************
	public void loadPlayerPosition(Transform controller){
		//create the Vector of saved position
		Vector3 position=new Vector3(PlayerPrefs.GetFloat("Player Position x"),
		                             PlayerPrefs.GetFloat("Player Position y"),
		                             PlayerPrefs.GetFloat("Player Position z"));
		//create the Quaternion of saved rotation
		Quaternion rotation=new Quaternion(PlayerPrefs.GetFloat("Player Rotation x"),
		                                   PlayerPrefs.GetFloat("Player Rotation y"),
		                                   PlayerPrefs.GetFloat("Player Rotation z"),
		                                   PlayerPrefs.GetFloat("Player Rotation w"));
		controller.position=position;
		controller.rotation=rotation;

	} //end loadPlayerPosition

	//**********************************************
	//purpose: load the position of an enemy
	//parameter:enemy object class(GameObject), index(int),key (String)
	//return:none
	//**********************************************
	public void loadEnemy(Transform e,int i,string type){
		//read the Enemy only if it exist in data file
		if(PlayerPrefs.HasKey(type+i+" Position x")){
			Vector3 position=new Vector3(PlayerPrefs.GetFloat(type+i+" Position x"),
			                             PlayerPrefs.GetFloat(type+i+" Position y"),
			                             PlayerPrefs.GetFloat(type+i+" Position z"));
			Quaternion rotation=new Quaternion(PlayerPrefs.GetFloat(type+i+" Rotation x",e.rotation.w),
			                                   PlayerPrefs.GetFloat(type+i+" Rotation y",e.rotation.w),
			                                   PlayerPrefs.GetFloat(type+i+" Rotation z",e.rotation.w),
			                                   PlayerPrefs.GetFloat(type+i+" Rotation w",e.rotation.w));
			e.position=position;
			e.rotation=rotation;
				
		} //end if
	} //end loadEnemy

	//**********************************************
	//purpose: Change the load control(whether the game needs to load)
	//parameter:t(boolean)
	//return:none
	//**********************************************
	public void needToLoad(bool t){
		// store the info to String
		if(t){
			PlayerPrefs.SetString("Load","true");
		}else{
			PlayerPrefs.SetString("Load","false");
		} //end if
		PlayerPrefs.Save();
	} //end needToLoad

	//**********************************************
	//purpose: load the load control(whether the game needs to load)
	//parameter:none
	//return:the condition (boolean)
	//**********************************************
	public bool loadControl(){
		return bool.Parse(PlayerPrefs.GetString("Load"));
	} //end loadControl
}

