using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableTutorial : MonoBehaviour
{
    public GameObject TutorialStuff;
    public void disableTut()
    {
        TutorialStuff.SetActive(false);
    }
}
