using UnityEngine;
using System.Collections;
//          calss description
//this is the class of the first enemy

public class Enemy1 : Enemy {
	public Enemy1(EnemyFactory f){
		//define which factory this enemy belongs to 
		factory=f;
		timer=Random.Range(8,15);
		makeEnemy();

	} //end Enemy1 (initiated)	
} //end class
