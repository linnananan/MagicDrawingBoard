using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle4 : MonoBehaviour {

	private ParticleSystem[] particleSystems;
	// Use this for initialization
	void Start () {
		particleSystems = GetComponentsInChildren<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		bool allStopped = true;

		foreach (ParticleSystem ps in particleSystems)
		{
			if (!ps.isStopped)
			{
				allStopped = false;
			}
		}

		if (allStopped)
			GameObject.Destroy(gameObject);
	
	}
}
