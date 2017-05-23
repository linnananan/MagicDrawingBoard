using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT风力控制 : MonoBehaviour {

    Vector3 acceleration;
    Vector3 acVary;
    Vector3 windUp;
    Vector3 windDown;
    Vector3 windLeft;
    Vector3 windRight;

    public float windUDScale = 200.0f;
    public float windLRScale = 1.9f;

    public float _速率系数 = 1.0f;
    public Vector2 _噪声速率;
    public Vector2 _噪声起点;
    public float _基准值 = 0.3f, _最大偏移 = 0.1f;

    // Use this for initialization
    void Start () {
        acVary.Set(0, 0, 0);
        windUp.Set(0, windUDScale, 0);
        windDown.Set(0, -windUDScale, 0);
        windLeft.Set(-windLRScale, 0, 0);
        windRight.Set(windLRScale, 0, 0);

        _噪声速率 = Random.insideUnitCircle;
        _噪声起点 = Random.insideUnitCircle * 100.0f;

    }
	
	// Update is called once per frame
	void Update () {

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            return;
        }
        controlWind();
        acceleration = acceleration + acVary;     
        rb.AddForce(acceleration);
        acceleration.Set(0, 0, 0);


        float 时刻 = Time.realtimeSinceStartup;
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Color 当前颜色 = sr.color;

        float 透明度 = 当前颜色.a;
        透明度 = Mathf.PerlinNoise(
            _噪声速率.x * 时刻, _噪声速率.y * 时刻);
        透明度 = AT_MathUtil.map(
            透明度,
            0.0f, 1.0f,
            _基准值 - _最大偏移,
            _基准值 + _最大偏移);
        当前颜色.a = 透明度;

        sr.color = 当前颜色;

    }

    void applyForce(Vector3 force)
    {
        acVary = force; //最简单的牛顿第二定律的实现方式
    }

    void controlWind()
    {   
        if (Input.GetKeyUp(KeyCode.W))
        {
            applyForce(windUp);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            applyForce(windDown);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            applyForce(windLeft);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            applyForce(windRight);
        }   
    }

    [ContextMenu("以当前透明度作为基准")]
    public void 以当前透明度作为基准()
    {
        _基准值 = GetComponent<SpriteRenderer>().color.a;
    }

    [ContextMenu("初始化噪声参数")]
    public void 初始化噪声参数()
    {
        _噪声速率 = Random.insideUnitCircle * _速率系数;
        _噪声起点 = Random.insideUnitCircle * 100.0f;
    }

}
