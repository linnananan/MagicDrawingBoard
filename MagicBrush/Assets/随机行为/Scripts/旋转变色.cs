using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 旋转变色 : MonoBehaviour {

    private float[] color = new float[4] { 0, 0, 0, 0 };

    float angle = 0;
    float anglePara = 0;
    // Use this for initialization
    void Start () {
        for (int i = 0; i < 4; i++)
        {
            color[i] = Random.Range(-50.0f, 50.0f);
        }
        anglePara = Random.Range(-50.0f, 50.0f);
    }
	
	// Update is called once per frame
	void Update () {
        float nowTime = Time.realtimeSinceStartup;
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Color nowColor = sr.color;
        nowColor.r = Mathf.PerlinNoise(
            nowTime, color[0]);
        nowColor.g = Mathf.PerlinNoise(
            nowTime, color[1]);
        nowColor.b = Mathf.PerlinNoise(
            nowTime, color[2]);
        nowColor.a = Mathf.PerlinNoise(
            nowTime, color[3]);
        sr.color = nowColor;

        angle = Mathf.PerlinNoise(nowTime, anglePara);
        transform.Rotate(Vector3.forward, angle);
    }
}
