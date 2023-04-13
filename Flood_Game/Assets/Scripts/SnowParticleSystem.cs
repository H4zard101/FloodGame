using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowParticleSystem : MonoBehaviour
{
    public ParticleSystem snowParticles;
    public float weatherChangeInterval = 30f;
    private float weatherChangeTimer;
    private bool isSnowing;

    private void Start()
    {
        weatherChangeTimer = weatherChangeInterval;
        isSnowing = Random.Range(0, 2) == 0;
        ChangeWeather();
    }

    private void Update()
    {
        weatherChangeTimer -= Time.deltaTime;
        if (weatherChangeTimer <= 0)
        {
            isSnowing = !isSnowing;
            ChangeWeather();
            weatherChangeTimer = weatherChangeInterval;
        }
    }

    private void ChangeWeather()
    {
        if (isSnowing)
        {
            snowParticles.Play();

            var emission = snowParticles.emission;
            emission.rateOverTime = 20f;

            var main = snowParticles.main;
            main.startLifetime = 5f;
            main.startSpeed = 5f;
        }
        else
        {
            snowParticles.Stop();
        }
    }
}
