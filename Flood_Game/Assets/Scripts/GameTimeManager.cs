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

    public GameObject stopButton;
    public GameObject startButton;
    public void Update()
    {
        gameTimeText.text = "X" + gameTimeSlider.value + " Speed";


    }


    public void ResumeGame()
    {
        stopButton.SetActive(true);
        startButton.SetActive(false);
        isGamePaused = false;
    }
    public void PauseGame()
    {
        stopButton.SetActive(false);
        startButton.SetActive(true);
        isGamePaused = true;
    }
}
