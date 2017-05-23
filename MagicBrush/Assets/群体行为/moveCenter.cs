using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCenter : MonoBehaviour{
    
    Vector3 acceleration;
    Vector3 velocity;
    Vector3 location;

    public float maxspeed = 0.1f;//最大速率
    public float maxforce = 0.1f;//最大转向力
	// Use this for initialization
	public void Start () {
        velocity.Set(0, 0, 0);
        acceleration.Set(0, 0, 0);
        location = transform.localPosition;
	}
	
	// Update is called once per frame
	public  void Update () {
        
        applyForce(seek(Vector3.zero));
        velocity = velocity + acceleration;

        if (velocity.magnitude > maxspeed)
        {
            velocity = velocity.normalized * maxspeed;
        }
        location = velocity + location;
        transform.localPosition = location;
        acceleration *= 0;
        
	}
    public void applyForce(Vector3 force)
    {
        acceleration = acceleration + force;
    }
    //寻找目标转向力算法
    public Vector3 seek(Vector3 target)
    {
        Vector3 desired = target - location;
        desired = desired.normalized;
        desired *= maxspeed;
        Vector3 steer = desired - velocity;

        if (steer.magnitude > maxforce)
        {
            steer = steer.normalized * maxforce;
        }
        return steer;
    }
}
