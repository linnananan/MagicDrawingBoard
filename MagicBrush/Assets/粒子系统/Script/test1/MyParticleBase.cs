using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class MyParticleBase : MonoBehaviour {
    Vector3 velocity;
	Vector3 acceleration;
	public double LifeSpan;

	// Use this for initialization
	void Start () {
		velocity.Set(0, 0, 0);
		LifeSpan = 10;　
	}
	
	// Update is called once per frame
	public virtual void  Update () {		
	}
	public  void  movePa () {
		LifePassThenDie();
		ApplyRandomForce ();
	}
	public  void applyForce(Vector3 force)
	{
		velocity = force; //最简单的牛顿第二定律的实现方式
	}
	void LifePassThenDie ()
	{
		LifeSpan -= 1.0*Time.deltaTime;
		if (LifeSpan < 0.0f) {
			Destroy (gameObject);
		}
	}

	void ApplyRandomForce ()
	{
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		acceleration = acceleration + velocity;     
		rb.AddForce(acceleration);
		acceleration.Set(0, 0, 0);

	}


}
