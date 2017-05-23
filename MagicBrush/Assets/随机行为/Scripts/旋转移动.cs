using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 旋转移动 : MonoBehaviour {

    float speed = 1.0f;
    float angle = 0.0f;
	// Use this for initialization
	void Start () {
        float r = Random.value;
        if (r < 0.3)
        {
            angle = Random.Range(0, 360);
        }
        Destroy(gameObject, 3);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(
            speed * Mathf.Cos(angle) * 0.001f,
            speed * Mathf.Sin(angle) * 0.001f,
    0);
    }
}
