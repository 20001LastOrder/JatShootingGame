using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//S is the name of any class can be used in stack
public class TheStack <S> {
	private S[] array;
	private int stackSize;
	private int topOfTheStack=-1;

	public TheStack(int size){
		stackSize=size;
		array=new S[size];
	} //end TheStack

	public void push(S o){
		if(topOfTheStack+1<stackSize){
			topOfTheStack++;
			//Debug.Log("push: "+topOfTheStack);
			array[topOfTheStack]=o;
		}else{
		} //end if

	} //end push

	public void groupPush(List<S> a){
		for(int i=0;i<a.Count;i++){
			push(a[i]);
		} //end loop
	} //end if

	public void pop(){
		if(topOfTheStack>=0){
			array[topOfTheStack]=default(S);
			topOfTheStack--;
		}else{
		} //end if
	} //end pop

	public S peek(){
		if(topOfTheStack>=0){
			return(array[topOfTheStack]);
		}else{
			return default(S);
		}
	} //end peek
	 
	public void popAll(){
		for(int i=topOfTheStack;i>=0;i--){
			pop();
		} //end loop
	} //end popAll

	public int getSize(){
		return stackSize;
	} //end getSize

} //end class
