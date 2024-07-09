/*using System.Collections;
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
    public AudioSource soundEffectSource;



    public World world;

    public void Start()
    {
        world = FindObjectOfType<World>();
        // Pause the sound effect at the start
        PauseGame();
    }
    public void Update()
    {
        gameTimeText.text = "X" + gameTimeSlider.value + " Speed";
    }


    public void ResumeGame()
    {

        isGamePaused = false;

        world.phase = World.Phase.Simulation;
        // Play sound effect when the game is resumed
        soundEffectSource.Play();
    }
    public void PauseGame()
    {

        isGamePaused = true;
        world.phase = World.Phase.Pause;
        // Play sound effect when the game is paused
        soundEffectSource.Pause();
    }
}*/

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
    public AudioSource soundEffectSource;

    public World world;

    public void Start()
    {
        world = FindObjectOfType<World>();

        // Pause the sound effect at the start
        PauseGame();
    }

    public void Update()
    {
        gameTimeText.text = "X" + gameTimeSlider.value + " Speed";
    }

    public void ResumeGame()
    {
        isGamePaused = false;
        world.phase = World.Phase.Simulation;
        soundEffectSource.Play();
    }

    public void PauseGame()
    {
        isGamePaused = true;
        world.phase = World.Phase.Pause;
        soundEffectSource.Pause();
    }
}

