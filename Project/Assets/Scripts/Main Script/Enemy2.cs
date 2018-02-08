using UnityEngine;
using System.Collections;
// This is the class for enemy 2
public class Enemy2 : Enemy {
	public Enemy2(EnemyFactory f){
		factory=f;
		makeEnemy();
		timer=Random.Range(8,15);
	} //end Enmey2 (Initiated)

} //end class
