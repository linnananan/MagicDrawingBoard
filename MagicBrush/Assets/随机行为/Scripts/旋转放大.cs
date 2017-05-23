using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 旋转放大 : MonoBehaviour {
    float maxScale = 1.2f, minScale = 0.8f;

    float noisePara;
    Vector3 preSize = Vector3.zero;

    float angle;
    // Use this for initialization
    void Start () {
        noisePara = Random.value * 100.0f;
        preSize = transform.localScale;
        angle = 0;
    }
	
	// Update is called once per frame
	void Update () {
        float nowTime = Time.realtimeSinceStartup;

        float scale = Mathf.PerlinNoise(nowTime, noisePara);
        scale = AT_MathUtil.map(scale, 0.0f, 1.0f, minScale, maxScale);
        Vector3 v3 = preSize * scale;
        transform.localScale = v3;

        angle++;
        transform.Rotate(Vector3.forward, angle);
    }
}
