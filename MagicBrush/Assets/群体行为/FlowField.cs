using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowField : MonoBehaviour {

    Vector3 acceleration2;
    Vector3 velocity2;
    Vector3 location2;

    public float maxspeed2 = 0.01f;//最大速率
    public float maxforce2 = 0.1f;//最大转向力


    Vector3[,] field;//存放向量的二维数组
    int cols;
    int rows;//网络中的行列
    int resolution;//网络的分辨率，与屏幕宽高有关

	// Use this for initialization
	void Start () {

        velocity2.Set(0, 0, 0);
        acceleration2.Set(0, 0, 0);
        location2 = transform.localPosition;

        //流场屏幕设置
        resolution = 100;
        cols = Screen.width / resolution;
        rows = Screen.height / resolution;
        //流场数据结构
        field=new Vector3[cols,rows];
        init();

	}

    void init() {
        //流场组成
        float xoff = 0;
        for (int i = 0; i < cols; i++)
        {
            float yoff = 0;
            for (int j = 0; j < rows; j++)
            {
                float theta = Mathf.PerlinNoise(xoff, yoff) * Mathf.PI * 2;
                field[i, j] = new Vector3(Mathf.Cos(theta), Mathf.Sin(theta),0);
                yoff += 0.1f;
            }
            xoff += 0.1f;
        }
    }

	// Update is called once per frame
	void Update () {
        applyForce(lookup(transform.localPosition));

        velocity2 = velocity2 + acceleration2;

        if (velocity2.magnitude > maxspeed2)
        {
            velocity2 = velocity2.normalized * maxspeed2;
        }
        location2 = velocity2 + location2;
        transform.localPosition = location2;
        acceleration2 *= 0;

	}

    //根据位置返回所需速度向量
    Vector3 lookup(Vector3 lookup) { 
        int column=(int)(Mathf.Clamp(lookup.x/resolution,0,cols-1));
        int row=(int)(Mathf.Clamp(lookup.y/resolution,0,rows-1));
        Vector3 pos=new Vector3(field[column,row].x,field[column,row].y,0);
        return pos;
    }
    void applyForce(Vector3 force)
    {
        acceleration2 = acceleration2 + force;
    }
    //流场跟随
    public Vector3 follow(Vector3 lookupPos)
    {
        Vector3 desired = lookupPos;
        desired = desired.normalized;
        desired *= maxspeed2;
        Vector3 steer = desired - velocity2;

        if (steer.magnitude > maxforce2)
        {
            steer = steer.normalized * maxforce2;
        }
        return steer;
    }
}
