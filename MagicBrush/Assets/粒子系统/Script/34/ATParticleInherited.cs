using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATParticleInherited : ATParticleBase {
	public float _TorquePower = 1.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public override void Update () {
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		//rb.velocity *= 0.99;

		base.Update ();
		//Random.value between 0.0 [inclusive] and 1.0 [inclusive] 
		rb.AddTorque (Random.value * _TorquePower);//AddTorque (torque : Vector3, mode : ForceMode = ForceMode.Force) : void 
		//添加一个力矩到刚体。
		//rigidbody.AddTorque (Vector3.up * 10);
		//作为结果刚体将绕着torque轴旋转。
	}
}
