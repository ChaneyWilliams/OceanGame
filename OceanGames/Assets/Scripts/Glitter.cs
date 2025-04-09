using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.Rendering.Universal;

public class Glitter : MonoBehaviour
{
    public float flickerIntensity = .2f;
    public float flickersPerSec = 3.0f;
    public float speedRand = 1.0f;

    float time;
    float startIntensity;
    public Light2D light;

    private void Start()
    {
        light = GetComponent<Light2D>();
        startIntensity = light.intensity;
    }

    private void Update()
    {
        time += Time.deltaTime * (1 - Random.Range(-speedRand, speedRand)) * Mathf.PI;
        light.intensity = startIntensity + Mathf.Sin(time * flickersPerSec) * flickerIntensity;
    }
}
