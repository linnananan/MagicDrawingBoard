using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ATParticleBase : MonoBehaviour {
	public float _ForcePower = 1.0f;
	public float _ForceOffset = 1.0f;
	public float _LifeSpan = 10.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public virtual void Update () {
		LifePassThenDie ();
		ApplyRandomForce ();
	}

	void LifePassThenDie ()
	{
		_LifeSpan -= Time.deltaTime;
		if (_LifeSpan < 0.0f) {
			Destroy (gameObject);
		}
	}

	void ApplyRandomForce ()
	{
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		rb.AddForceAtPosition (_ForcePower * Random.insideUnitCircle, _ForceOffset * Random.insideUnitCircle);
		//public void AddForceAtPosition(Vector3 force,Vector3 position);
		//public void AddForceAtPosition(Vector3 force, Vector3 position, ForceMode mode = ForceMode.Force);
		//其中参数force为扭矩向量，参数position为作用点坐标值，参数mode为力的作用方式。
		//功能说明：此方法用于为参数position增加一个力force,其参考坐标系为世界坐标系，作用方式为mode，默认值为ForceMode.Force
		//AddForceAtPosition方法是在某个坐标点对刚体施加力，这样很可能会产生扭矩使刚体产生旋转
		//1、当力的作用点在刚体重心时，刚体不会发生旋转；
		// 2、当力的作用点不在刚体重心时，由于作用点的扭矩会使刚体发旋转，但是，当作用力的方向经过刚体 的重心坐标时，不发生旋转。


	}
}
