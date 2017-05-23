using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyParticleInherited : MyParticleBase {
	//public float _TorquePower = 1.0f;
	//float time;
	// Use this for initialization
	Vector3 ran1,ran2,ran3,ran4;

	void Start () {
		ran1.Set (1,0,0);
		ran2.Set (-1,0,0);
		ran3.Set (0,1,0);
		ran3.Set (0,-1,0);
	}
	public override void  Update () {

		movePa ();
	}
	// Update is called once per frame
	public  void  movePa() {
		controlWind ();
		base.movePa ();
	}
	void controlWind()
	{   
		if (Random.value < 0.2) {
			applyForce (ran1);
		}else if(Random.value < 0.4){
			applyForce (ran2);
		}else if(Random.value < 0.8){
			applyForce (ran3);
		}else{
			applyForce (ran4);
		}
	}

}
