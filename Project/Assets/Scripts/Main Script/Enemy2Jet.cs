using UnityEngine;
using System.Collections;
//theis is the class of the second enemy jet
public class Enemy2Jet : EnemyJet {
	//resource
	GameObject myself;
	//real game object
	GameObject enemyJet;
	#region EnemyJet implementation
	//initial the jet
	public void initiateSelf ()
	{
		Vector3 t=GameObject.Find("X jet").GetComponent<Transform>().position;
		//creat the jet in a radom place
		Vector3 position=Random.onUnitSphere*150+t;
		enemyJet= MonoBehaviour.Instantiate(myself,position,new Quaternion(0,0,0,0))as GameObject; 
	} //end initiateSelf

	public Transform getTransform(){
		if(enemyJet!=null){
			return enemyJet.transform;
		}else{
			return null;
		} //end if
	} //end getTransform
	
	#endregion
	
	
	// Use this for initialization
	public Enemy2Jet () {
		myself = (GameObject)Resources.Load ("Enemy2",typeof(GameObject));

	} //end Enemy2Jet(default)

	//destroy the enemy
	public void destroy(){
		GameObject.Destroy(enemyJet);
	} //end destroy

	//moving the enemy
	public void forward(){
		enemyJet.transform.Translate(0,0,2.5f);
	} //end forward
} //end class
