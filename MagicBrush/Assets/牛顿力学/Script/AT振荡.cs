using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT振荡 : AT周期行为基类 {

    Vector3 angle;
    Vector3 velocity;
    Vector3 amplitude;
    Vector3 pos;

    // Use this for initialization
    void Start () {
        初始化基准时刻();
        angle.Set(0, 0, 0);
        velocity.Set(Random.Range(-0.01f, 0.01f), Random.Range(-0.01f, 0.01f), 0);
        amplitude.Set(Random.Range(0.1f, 0.8f), Random.Range(0.1f, 0.8f), 0);
        //pos = transform.localPosition;

    }
	
	// Update is called once per frame
	void Update () {
        float time = Time.realtimeSinceStartup - _基准时刻;
        oscillate();
        float x = Mathf.Sin(angle.x * time) * amplitude.x;//x轴振荡
        float y = Mathf.Sin(angle.y * time) * amplitude.y;//y轴振荡

        //Vector3 newPos = new Vector3(x, y, 0);
        //newPos = newPos + pos;
        //transform.localPosition = newPos;
        transform.Translate(Vector3.up * y * Time.deltaTime *0.5f, Space.World);
        //transform.Rotate(x, y, 0);
        
    }

    void oscillate()
    {
        angle = angle + velocity;
    }

}
