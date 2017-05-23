using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyParticleSystem2 : MyParticleBase2 {

	bool inScale;
	public float g;
	public GameObject prefab;
	private GameObject tar;
	public double LifeSpan;
	float distance;
	List<GameObject> list;
	int index = 0;

	// Use this for initialization
	void Start () {
		LifeSpan = 5.0f;
		inScale = true;
		g = 0.0098f;
		list = new List<GameObject>();
		Vector3 pos = transform.position + new Vector3(Random.Range(-0.1f,0.5f), Random.Range(-0.1f, 0.5f), 0);
		//tar = (GameObject)Instantiate(prefab);
		//tar.transform.position = pos;
		tar = GameObject.Instantiate(prefab, pos, Quaternion.identity) as GameObject;
		list.Add(tar);
		index++;
	}
	
	// Update is called once per frame
	public override void Update () {
		movePar (inScale);
		LifeSpan -= 2.0*Time.deltaTime;
		if (LifeSpan < 0.0f) {
			
			for (int i = 0; i < index; i++)
			{
				Destroy(list[i].gameObject);
			}
			Destroy (gameObject);
			index = 0;
		}
	}
	public override  void  movePar (bool inS) {
		if (inS)
		{
			Vector3 force = attract();
			applyForce(force);
			velocity = velocity + acceleration;
			location = velocity + location;
			//transform.position = location;
			acceleration = acceleration * 0;
		}

	}
	public override Vector3 attract()
	{
		distance = Vector3.Distance(transform.position, tar.transform.position);
		Vector3 f = transform.position - tar.transform.position;
		if (distance > -0.1f && distance <0.5f)
		{
			float strength = (g * mass * 1.0f) / (distance * distance*1000);
			f = f.normalized;
			f = f * strength;
			return f;
		}
		if (distance < -0.1f || distance > 0.5f)
		{
			for (int i = 0; i < index; i++)
			{
				Destroy(list[i].gameObject);
			}
			Destroy(this.gameObject);
			inScale = false;
		}
		acceleration = acceleration * 0;
		return Vector3.zero;
	}

}
