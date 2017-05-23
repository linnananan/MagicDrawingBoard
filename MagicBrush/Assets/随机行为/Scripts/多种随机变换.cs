using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 多种随机变换 : MonoBehaviour {


    float maxScale = 1.5f, minScale = 0.5f;

    float noisePara;
    Vector3 preSize = Vector3.zero;

    private float[] color = new float[4] { 0, 0, 0, 0 };

    // Use this for initialization
    void Start () {
        noisePara = Random.value * 100.0f;
        preSize = transform.localScale;

        for (int i = 0; i < 4; i++)
        {
            color[i] = Random.Range(-100.0f, 100.0f);
        }
    }
	
	// Update is called once per frame
	void Update () {
        float nowTime = Time.realtimeSinceStartup;

        float scale = Mathf.PerlinNoise(nowTime, noisePara);
        scale = AT_MathUtil.map(scale, 0.0f, 1.0f, minScale, maxScale);
        Vector3 v3 = preSize * scale;
        transform.localScale = v3;

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
    }
}
