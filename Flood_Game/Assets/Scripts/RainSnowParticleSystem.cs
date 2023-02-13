using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainSnowParticleSystem : MonoBehaviour
{
    public ParticleSystem rainParticles;
    public ParticleSystem snowParticles;
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
            snowParticles.Stop();

            var emission = rainParticles.emission;
            emission.rateOverTime = 50f;

            var main = rainParticles.main;
            main.startLifetime = 2f;
            main.startSpeed = 10f;
        }
        else
        {
            snowParticles.Play();
            rainParticles.Stop();

            var emission = snowParticles.emission;
            emission.rateOverTime = 20f;

            var main = snowParticles.main;
            main.startLifetime = 5f;
            main.startSpeed = 5f;
        }
    }
}
