using UnityEngine;
using System.Collections;
//******************Class Discription**********************
//This class is like a ording machine for creating a enemy 
//ship with some properties and nothing else.
//It will pass the construction information to specific 
//builder.
//*********************************************************
public abstract class EnemyBuilder  {
	//When we call a new enemy is made. the specific type
	//are based on the string inputed.
	protected abstract Enemy makeAnEnemy(int type);

	//***********************************
	//purpose: order an enemy
	//parameter: enemy type
	//return: enemy
	//***********************************
	public Enemy orderAnEnemy(int type){
		Enemy theEnemy= makeAnEnemy(type);
		return theEnemy;
	} //end orderAnEnemy

} //end class
