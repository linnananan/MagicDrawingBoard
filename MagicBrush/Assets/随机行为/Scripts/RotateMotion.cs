using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMotion : MonoBehaviour {
    float r = 0.01f;
    float theta = 0.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float x =  r * Mathf.Cos(theta)*0.01f;
        float y =  r * Mathf.Sin(theta)*0.01f;
        transform.Translate(x, y, 0);
        r += Random.Range(0, 0.0005f);
        theta += 0.01f;
    }
}
