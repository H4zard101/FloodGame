using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MakeButtonsUsable : MonoBehaviour
{
    public Button button;
    public int cost;

    void Update()
    {
        if(SetCreditAmount.CreditAmount < cost)
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }
    }
}
