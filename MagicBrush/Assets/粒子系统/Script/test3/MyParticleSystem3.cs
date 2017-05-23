using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyParticleSystem3 : MonoBehaviour {
// Use this for initialization
	public float _Chance = 0.01f;
	public GameObject _Prefab;
	public double LifeSpan;
	// Use this for initialization
	void Start () {
		LifeSpan = 5.0f;
	}

	// Update is called once per frame
	void Update () {
		if (Random.value < _Chance) {
			GameObject newParticle = Instantiate (_Prefab) as GameObject;
			newParticle.transform.SetParent (transform);
			newParticle.transform.position = transform.position;
		}
		LifeSpan -= 1.0*Time.deltaTime;
		if (LifeSpan < 0.0f) {
			Destroy (gameObject);
		}

	}
}
