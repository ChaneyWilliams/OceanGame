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
    public Light2D lights;

    private void Start()
    {
        lights = GetComponent<Light2D>();
        startIntensity = lights.intensity;
    }

    private void Update()
    {
        time += Time.deltaTime * (1 - Random.Range(-speedRand, speedRand)) * Mathf.PI;
        lights.intensity = startIntensity + Mathf.Sin(time * flickersPerSec) * flickerIntensity;
    }

    public void SetIntensity(float newInten)
    {
        flickerIntensity = newInten;
    }
    public void SetPerSec(float newPerSec) 
    { 
    
        flickersPerSec = newPerSec;
    }

    public void SetSpeedRand(float newSpeedrand) 
    { 
    
        speedRand = newSpeedrand;
    }
}
