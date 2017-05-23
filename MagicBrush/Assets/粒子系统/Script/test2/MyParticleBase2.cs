using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyParticleBase2 : MonoBehaviour {

	public Vector3 acceleration;
	public Vector3 location;
	public Vector3 velocity;
	public float mass;


	// Use this for initialization
	void Start () {
		mass = 1;
		//g = 0.98;
		velocity.Set(0, 0, 0);
		acceleration.Set(0, 0, 0);
	}
	
	// Update is called once per frame
	public virtual void Update () {
		
	}
	public void applyForce(Vector3 force)
	{
		Vector3 f = force / mass;
		acceleration = acceleration + f;
	}
	public virtual  void  movePar (bool inS) {

	}
	public virtual Vector3 attract()
	{
		return Vector3.zero;
	}

}
