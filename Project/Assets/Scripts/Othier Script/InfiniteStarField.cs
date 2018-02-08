/*****************************************************************
 * Description:
 * 	This class will use particle system to create aa infinate star 
 * field inside the space scene
 * 
 * ****************************************************************/
using UnityEngine;
using System.Collections;


public class InfiniteStarField : MonoBehaviour {
	private Transform t;    //position of the camera
	private ParticleSystem.Particle[] stars;     //a array list of particles
	private ParticleSystem particle;          //an instance linked to the partical system inside the game
	public int starDistance=100;          //the radius of the sphere where particles are created
	public int max=1000;                  // the total number of particles
	public int starSize=1;                // the size of individual particles
	private int starSqrDistance;          //the square of the starDistance
	public int closeDistance=20;          //the radius of the sphere where particles get smaller until disappeare
	private int closeSqrDistance;        //the square of closeDistance


	// Use this for initialization
	void Start () {
		//link t to the position of camera
		t = transform;
		//link instance "particle" to the particle system
		particle = GameObject.Find ("Particle System").GetComponent<ParticleSystem> ();  

		starSqrDistance=starDistance*starDistance;
		closeSqrDistance = closeDistance * closeDistance;
	}


	// Update is called once per frame
	void Update () {
		//creat stars once at the begining
		if (stars == null) {
			createStars();
		}

		// go through every individual particles
		for (int i=0; i<max; i++) {

			//when the distance of the star is too far away from the camera
			//replace it on the surface of the sphere
			if((stars[i].position-t.position).sqrMagnitude>starSqrDistance){
				replaceStar(i);	
			}  //end if

			//Make the star vanish if it is too close to the camera(smaller the the close Distance)
			if ((stars [i].position - t.position).sqrMagnitude < closeSqrDistance) {
				vanishStar (i);
			}//end if

		}  //end loop


		//set particles in the scene of the game
		particle.SetParticles (stars,stars.Length);
			}

	//**************************Methods*****************************

	//************************************************
	//Purpose:creat stars in random position inside the sphere
	//Parameter:IN:none
	//Return:none
	//************************************************
	private void createStars(){
		stars = new ParticleSystem.Particle [max];
		//creat stars inside the sphere at random position
		for(int i=0;i<max;i++){
			stars[i].position=Random.insideUnitSphere*starDistance+t.position;
			stars[i].color=new Color(1,1,1,1);
			stars[i].size=starSize;
		}   //end of loop
	}   //end creatStars

	//************************************************
	//Purpose:replace star on the sphere 
	//Parameter:IN:Index Number
	//Return:none
	//************************************************
	private void replaceStar(int i){
		stars[i].position=Random.onUnitSphere*starDistance+t.position;

	}  //end replaceStar

	//************************************************
	//Purpose:Make the star vanish 
	//Parameter:IN:Index number
	//Return:none
	//************************************************
	private void vanishStar(int i){

		float rate=(stars[i].position-t.position).sqrMagnitude/closeSqrDistance;
		stars[i].size=stars[i].size*rate;
		stars[i].color=new Color(1,1,1,rate);

	}   //end vanishStar





}    //end class
