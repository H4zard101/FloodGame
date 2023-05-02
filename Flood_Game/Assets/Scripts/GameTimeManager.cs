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

    public GameObject stopButton;
    public GameObject startButton;
    public GameObject pausedMenuPanelUi;

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
        stopButton.SetActive(true);
        startButton.SetActive(false);
        isGamePaused = false;
        pausedMenuPanelUi.SetActive(false);
        phaseText.text = "Current Phase : Simulation";
        world.phase = World.Phase.Simulation;
    }
    public void PauseGame()
    {
        stopButton.SetActive(false);
        startButton.SetActive(true);
        isGamePaused = true;
        pausedMenuPanelUi.SetActive(true);
        phaseText.text = "Current Phase : Simulation";
        world.phase = World.Phase.Pause;
    }
}
