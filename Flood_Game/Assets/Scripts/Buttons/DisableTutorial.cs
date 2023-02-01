using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableTutorial : MonoBehaviour
{
    public GameObject TutorialStuff;
    public GameObject BuildUI;
    public GameObject MapOverView;
    public void disableTut()
    {
        TutorialStuff.SetActive(false);
        BuildUI.SetActive(true);
        MapOverView.SetActive(false);
    }

    public void enableTut()
    {
        TutorialStuff.SetActive(false);
        MapOverView.SetActive(true);
    }    

    public void MapOverViewUI()
    {

    }
}
