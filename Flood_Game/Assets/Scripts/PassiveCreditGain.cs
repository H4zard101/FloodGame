using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveCreditGain : MonoBehaviour
{
    public float _Time = 10;
    public float maxTime = 10;
    public int creditGain = 5;

    public SetCreditAmount creditAmount;


    public void Start()
    {
        creditAmount = FindObjectOfType<SetCreditAmount>();
    }
    void Update()
    {
        if(_Time > 0)
        {
            _Time -= Time.deltaTime;
        }

        else
        {
            _Time = maxTime;
            Debug.Log("+1");
            creditAmount.creditText.text = "Credits : " + creditGain;
        }
    }
}
