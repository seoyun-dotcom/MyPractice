using System;
using UnityEngine;

public class MathLight : MonoBehaviour
{
    private Light light;
    private float theta;
    [SerializeField] private float power;
    [SerializeField] private float speed;

    void Start()
    {
        light = GetComponent<Light>();
    }

    void Update()
    {
        theta += Time.deltaTime * speed;

        //light.intensity = Mathf.Sin(theta) * power;//삼각함수 그래프

        light.intensity = Mathf.PerlinNoise(theta, 0) * power; // 유명한 노이즈 (고장난 손전등)
    }
}