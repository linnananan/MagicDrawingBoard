using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyParticleSystem1 : MonoBehaviour {
	
	public double LifeSpan;
	public float _Chance = 0.3f;
	public GameObject prefab;
	// Use this for initialization
	void Start () {
		LifeSpan = 5.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Random.value < _Chance) {
			GameObject newParticle = Instantiate (prefab) as GameObject;
			newParticle.transform.SetParent (transform);
			newParticle.transform.position = transform.position;
		}
		LifeSpan -= 1.0*Time.deltaTime;
		if (LifeSpan < 0.0f) {
			Destroy (gameObject);
		}
	}
}
