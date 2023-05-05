using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrbanAreas : MonoBehaviour
{
    public int health = 100;
    public bool isFlooding = false;
    public bool isDestroyed = false;

    // Update is called once per frame
    void Update()
    {
        if(isFlooding && !isDestroyed)
        {
            // - health
            health -= 1;

            // - credits
            SetCreditAmount.CreditAmount -= 1;
        }

        if(health == 0)
        {
            isDestroyed = true;
        }
    }
}
