using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ResultsManager : MonoBehaviour
{

    public Image creditsTick;
    public Image completionTick;
    public Image urbanTick;

    [SerializeField]
    private int urbanAreasFlooded;
    [SerializeField]
    private int urbanAreasTotal;


    public TextMeshProUGUI creditText;
    public TextMeshProUGUI urbanAreaText;

    public void Start()
    {

        if (SetCreditAmount.CreditAmount >= 0)
        {
            creditsTick.gameObject.SetActive(true);
        }
        
        completionTick.gameObject.SetActive(true);



        urbanAreasTotal = World.UrbanObject.Count;
        urbanAreasFlooded = World.destroyedUrban;

        if (urbanAreasFlooded < urbanAreasTotal)
        {
            urbanTick.gameObject.SetActive(true);
        }

        creditText.text = "Credits Left: " + SetCreditAmount.CreditAmount.ToString();
        urbanAreaText.text = "Urban areas flooded: " + urbanAreasFlooded.ToString() + " / " + urbanAreasTotal.ToString();
    }

}
