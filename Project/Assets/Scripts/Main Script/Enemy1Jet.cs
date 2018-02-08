using UnityEngine;
using System.Collections;
//            class description
//this is the class of the first enemy jet
public class Enemy1Jet : EnemyJet {
	//resource
	GameObject myself;
	//real game object
	GameObject enemyJet;
	#region EnemyJet implementation
	// initial the enemy jet
	public void initiateSelf ()
	{
		Vector3 t=GameObject.Find("X jet").GetComponent<Transform>().position;
		//creat the jet in a radom place
		Vector3 position=Random.onUnitSphere*200+t;
		enemyJet= MonoBehaviour.Instantiate(myself,position,new Quaternion(0,0,0,0))as GameObject; 
	} //end initiateSelf

	// get transform
	public Transform getTransform ()
	{   
		// return the transform only if it exsit
		if(enemyJet!=null){
			return enemyJet.transform;
		}else{
			return null;
		} //end if
	} //end getTransform
	#endregion


	// Use this for initialization
	public Enemy1Jet () {
		myself = (GameObject)Resources.Load ("Enemy1",typeof(GameObject));
	} //end Enemy1Jet(default)

	//destroy the enemy jet
	public void destroy(){
		GameObject.Destroy(enemyJet);
	} //end destroy

	//moving the enemy
	public void forward(){
		enemyJet.transform.Translate(0,0,2);
	} //end forward

} //end class
