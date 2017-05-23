using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 旋转 : MonoBehaviour {

    public float _速率系数 = 1.0f;
    public float _随机变化速率 = 1.0f;
    private float _噪声参数y;
    private float[] _偏移量 =
    new float[4] { 0, 0, 0, 0 };
    // Use this for initialization
    void Start()
    {
        _噪声参数y = Random.value * 100.0f;
        for (int i = 0; i < 4; i++)
        {
            _偏移量[i] =
                Random.Range(-100.0f, 100.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float 当前时刻_秒 = Time.realtimeSinceStartup;
        float 方向角度 =
            Mathf.PerlinNoise(
                当前时刻_秒 * _随机变化速率, _噪声参数y) * 1500.0f;
        transform.rotation =
            Quaternion.AngleAxis(方向角度, Vector3.forward);

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Color 当前颜色 = sr.color;
        当前颜色.r = Mathf.PerlinNoise(
               当前时刻_秒, _偏移量[0]);
        当前颜色.g = Mathf.PerlinNoise(
            当前时刻_秒, _偏移量[1]);
        当前颜色.b = Mathf.PerlinNoise(
            当前时刻_秒, _偏移量[2]);
        当前颜色.a = Mathf.PerlinNoise(
            当前时刻_秒, _偏移量[3]);
        sr.color = 当前颜色;
    }

    [ContextMenu("随机化噪声参数")]
    public void 随机化噪声参数()
    {
        _随机变化速率 = _速率系数 * Random.value;
        _噪声参数y = Random.value * 100.0f;
    }

}
