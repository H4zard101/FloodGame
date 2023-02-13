using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetCreditAmount : MonoBehaviour
{
    public static float creditAmount = 50.0f;

    public TextMeshProUGUI creditText;


    public void Update()
    {
        creditText.text = "Credits : " + creditAmount;
    }
}
