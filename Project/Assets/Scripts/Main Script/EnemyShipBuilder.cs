using UnityEngine;
using System.Collections;
//This class is a specific order for
//the enemy ship
public class EnemyShipBuilder: EnemyBuilder{
	#region implemented abstract members of EnemyBuilder

	//get enemy type and build
	protected override Enemy makeAnEnemy (int type)
	{
		Enemy theEnemy=null;
		//put the order to different factories according to
		//the input(type)

		if(type==1){
			EnemyFactory theFactory=new Enemy1Factory();
			theEnemy=new Enemy1(theFactory);

		} //end if

		if(type==2){
			EnemyFactory theFactory=new Enemy2Factory();
			theEnemy=new Enemy2 (theFactory);
		} //end if

		return theEnemy;
	} //end makeAnEnemy

	#endregion

} //end class
