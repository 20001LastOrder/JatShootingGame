using UnityEngine;
using System.Collections;
//               interface description
//this is a interface containing all properties of enemy jet
public interface EnemyJet  {
	void initiateSelf();
	Transform getTransform();
	void destroy();
	void forward();
}
