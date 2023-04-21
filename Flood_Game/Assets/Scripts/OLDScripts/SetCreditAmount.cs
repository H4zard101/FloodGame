using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetCreditAmount : MonoBehaviour
{
    public static float CreditAmount = 50.0f;
    //public static float newCreditAmount;
    public float creditGain = 5;

    public float _Time = 3;
    public float maxTime = 3;

    public TextMeshProUGUI creditText;
    public World world;
    public GameTimeManager gameTimeManager;

    public void Start()
    {
        creditText.text = "Credits : " + CreditAmount;
        gameTimeManager = FindObjectOfType<GameTimeManager>();
        _Time = maxTime / gameTimeManager.gameTimeSlider.value;
        world = FindObjectOfType<World>();
    }

    public void Update()
    {
        if(world.phase == World.Phase.Simulation)
        {
            if (gameTimeManager.isGamePaused == false)
            {
                if (_Time > 0)
                {
                    _Time -= Time.deltaTime;

                }
                else
                {
                    _Time = maxTime / gameTimeManager.gameTimeSlider.value;
                    CreditAmount = CreditAmount + creditGain;

                }
                
            }
        }
        creditText.text = "Credits : " + CreditAmount;

    }
}
