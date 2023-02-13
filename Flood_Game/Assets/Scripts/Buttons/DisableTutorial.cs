using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableTutorial : MonoBehaviour
{
    public GameObject TutorialStuff;
    public GameObject BuildUI;
    public GameObject MapOverView;
    public GameObject DiffrentArea;
    public GameObject Build;
    public GameObject Credit;
    public PanZoom CameraMovement;


    public void Start()
    {
        CameraMovement = FindObjectOfType<PanZoom>();
        CameraMovement.GetComponent<PanZoom>().enabled = false;
    }


    public void disableTut()
    {
        TutorialStuff.SetActive(false);
        BuildUI.SetActive(true);
        MapOverView.SetActive(false);
        CameraMovement.GetComponent<PanZoom>().enabled = true;
    }

    public void enableTut()
    {
        TutorialStuff.SetActive(false);
        MapOverView.SetActive(true);
    }    


    public void SkipTutorial()
    {
        TutorialStuff.SetActive(false);
        Build.SetActive(false);
        MapOverView.SetActive(false);
        DiffrentArea.SetActive(false);
        Credit.SetActive(false);
        BuildUI.SetActive(true);
        CameraMovement.GetComponent<PanZoom>().enabled = true;
    }

    public void MapOverToAreas()
    {
        MapOverView.SetActive(false);
        DiffrentArea.SetActive(true);
    }


    public void AreasToBuild()
    {
        Build.SetActive(true);
        DiffrentArea.SetActive(false);
    }


    public void BuildToCredit()
    {
        Credit.SetActive(true);
        Build.SetActive(false);
    }

    public void FinishTut()
    {
        Credit.SetActive(false);
        BuildUI.SetActive(true);
        CameraMovement.GetComponent<PanZoom>().enabled = true;
    }
}
