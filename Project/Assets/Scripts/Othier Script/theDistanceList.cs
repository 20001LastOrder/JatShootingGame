using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//***********************************
//     Class Description
//the class is used to arrange and 
//store objects based on the distance
//from the player to that object
//************************************
public class theDistanceList  {
	private List<GameObject> queue;
	private int index;

	//constructor
	public theDistanceList(){
		queue=new List<GameObject>();
	} //end theDistanceList

	//***************************************************************************
	//purpose: get length of the list
	//parameter:none
	//return:length
	//**************************************************************************
	public int getLength(){
		return(queue.Count);
	} //end getLength

	//***************************************************************************
	//purpose: get the pointed object
	//parameter:none
	//return:object
	//**************************************************************************
	public GameObject getPointor(){
		return(queue[index]);
	} //end getPointor

	//***************************************************************************
	//purpose: insert a new object
	//parameter:new object
	//return:none
	//**************************************************************************
	public void insert(GameObject target){
		queue.Add(target);
	} //end insert

	//***************************************************************************
	//purpose: point to the next onject
	//parameter:none
	//return:none
	//**************************************************************************
	public void next(){
		if(index<queue.Count-1){
			index++;
		}else{
			index=0;
		} //end if
	} //end next

	//***************************************************************************
	//purpose: point to last object
	//parameter:none
	//return:none
	//**************************************************************************
	public void last(){
		if(index>0){
			index--;
		}else{
			index=queue.Count-1;
		} //end if
	} //end last

	//***************************************************************************
	//purpose: get distance between two objects
	//parameter:target object, player object
	//return:distance
	//**************************************************************************
	public float getDistance(GameObject target,Transform my){
		float distance=Vector3.Distance(target.transform.position,my.position);
		return distance;
	} //end getDistance

	//***************************************************************************
	//purpose: clear the list
	//parameter:none
	//return:none
	//**************************************************************************
	public void emptyAll(){
		queue.Clear();
		index=0;
	} //end empty all

	//***************************************************************************
	//purpose: arrange the object based on the distance
	//parameter:target object, player object
	//return:none
	//**************************************************************************
	public void distanceInsert(GameObject target,Transform my){
		float distance=Vector3.Distance(target.transform.position,my.position);
		int i;
		if(queue.Count==0){
			this.insert(target);
		}else{
			for(i=0;i<queue.Count;i++){
				if(distance<getDistance(queue[i],my)){
					queue.Insert(i,target);
					break;
				} //end if
			} //end if 
			//add the object to the end of the list if it cannot be inserted
			if(i==queue.Count){
				queue.Add (target);
			} //end if
		} //end if 

	} //end distanceInsert
} //end class
