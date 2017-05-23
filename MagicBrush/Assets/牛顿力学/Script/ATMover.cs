using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATMover : MonoBehaviour {

    Vector3 pos;
    Vector3 radius;

    Vector3 vel;

    float noisePara;


    // Use this for initialization
    void Start () {
        pos = transform.localPosition;
        radius = new Vector3(Random.Range(0.25f, 0.5f), 0.0f, 0.0f);//随机两个物体间的距离
        Vector3 newPos = pos + radius;
        transform.localPosition = newPos;

        vel = new Vector3();
        noisePara = Random.value * 100.0f;  
    }
	
	// Update is called once per frame
	void Update () {
        float nowTime = Time.realtimeSinceStartup;
        float angle = Mathf.PerlinNoise(nowTime, noisePara);
        angle = AT_MathUtil.map(angle, 0.0f, 1.0f, 0, 180);
        transform.Rotate(Vector3.forward, angle);

        float x = radius.x * Mathf.Sin(2 * nowTime);
        float y = radius.x * Mathf.Cos(2 * nowTime);

        Vector3 nowPos = new Vector3( x, y, 0.0f);
        nowPos += pos;
        transform.localPosition = nowPos;
        

    }

}
