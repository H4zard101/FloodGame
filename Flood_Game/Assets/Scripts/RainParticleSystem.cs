using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainParticleSystem : MonoBehaviour
{
    public ParticleSystem rainParticles;
    public float weatherChangeInterval = 30f;
    private float weatherChangeTimer;
    private bool isRaining;

    private void Start()
    {
        weatherChangeTimer = weatherChangeInterval;
        isRaining = Random.Range(0, 2) == 0;
        ChangeWeather();
    }

    private void Update()
    {
        weatherChangeTimer -= Time.deltaTime;
        if (weatherChangeTimer <= 0)
        {
            isRaining = !isRaining;
            ChangeWeather();
            weatherChangeTimer = weatherChangeInterval;
        }
    }

    private void ChangeWeather()
    {
        if (isRaining)
        {
            rainParticles.Play();

            var emission = rainParticles.emission;
            emission.rateOverTime = 50f;

            var main = rainParticles.main;
            main.startLifetime = 2f;
            main.startSpeed = 10f;
        }
        else
        {
            rainParticles.Stop();
        }
    }
}
