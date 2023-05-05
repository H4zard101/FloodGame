using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameTimeManager : MonoBehaviour
{
    public Slider gameTimeSlider;
    public TextMeshProUGUI gameTimeText;


    public bool isGamePaused = false;
    public TextMeshProUGUI buttonText;
    public TextMeshProUGUI phaseText;


    public World world;

    public void Start()
    {
        world = FindObjectOfType<World>();
    }
    public void Update()
    {
        gameTimeText.text = "X" + gameTimeSlider.value + " Speed";
    }


    public void ResumeGame()
    {

        isGamePaused = false;

        world.phase = World.Phase.Simulation;
    }
    public void PauseGame()
    {

        isGamePaused = true;
        world.phase = World.Phase.Pause;
    }
}
