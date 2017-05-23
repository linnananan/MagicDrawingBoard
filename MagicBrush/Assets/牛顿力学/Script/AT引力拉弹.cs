using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT引力拉弹 : MonoBehaviour {

    Vector3 acceleration;
    Vector3 location;
    Vector3 velocity;
    float mass;
    float distance;
    float g;

    bool inScale;
    public GameObject prefab;
    private GameObject tar;
    List<GameObject> list;
    int index = 0;

    // Use this for initialization
    void Start () {

        g = -0.098f;
        mass = 1;
        velocity.Set(0, 0, 0);
        acceleration.Set(0, 0, 0);
        location = transform.position;
        inScale = true;

        list = new List<GameObject>();

        Vector3 pos = transform.position + new Vector3(Random.Range(0.3f,0.8f),0,0);
        //tar = (GameObject)Instantiate(prefab);
        //tar.transform.position = pos;
        tar = GameObject.Instantiate(prefab, pos, Quaternion.identity) as GameObject;
        list.Add(tar);
        index++;


    }
    // Update is called once per frame
    void Update () {
        if (inScale)
        {
            Vector3 force = attract();
            applyForce(force);
            velocity = velocity + acceleration;
            location = velocity + location;
            transform.position = location;
            acceleration = acceleration * 0;
        }

    }

    void applyForce(Vector3 force)
    {
        Vector3 f = force / mass;
        acceleration = acceleration + f;
    }

    Vector3 attract()
    {
       
        distance = Vector3.Distance(transform.position, tar.transform.position);
        Vector3 f = transform.position - tar.transform.position;
        if (distance > 0.3f && distance < 0.8f)
        {
             float strength = (g * mass * 1.0f) / (distance * distance*1000);
             f = f.normalized;
             f = f * strength;
             return f;
        }
        if (distance > 1.0f || distance < 0f)
        {
            for (int i = 0; i < index; i++)
            {
                Destroy(list[i].gameObject);
            }
            Destroy(this.gameObject);
            inScale = false;
        }
        acceleration = acceleration * 0;
        

        return Vector3.zero;
    }

}
