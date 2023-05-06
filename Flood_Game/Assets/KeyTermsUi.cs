using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyTermsUi : MonoBehaviour
{
    // Text that will be used to describe the term
    public TextMeshProUGUI termText;

    // Buttons that the user will press
    public GameObject waterShedButton;
    public GameObject tribButton;
    public GameObject mainStreamButton;
    public GameObject sourceButton;
    public GameObject confluenceButton;


    public void waterShed()
    {
        termText.text = "A watershed is an area of land where all water flows to a single stream, river, lake or even ocean.";
    }

    public void trib()
    {
        termText.text = "A tributary is a freshwater stream that feeds into a larger stream.";
    }

    public void mainStream()
    {
        termText.text = "A main stream is where all the water comes originaly pools and feeds down the stream.";
    }

    public void source()
    {
        termText.text = "A source is the beginning or start of the river.";
    }

    public void confluence()
    {
        termText.text = "A confluence is the point at which two rivers or streams join.";
    }


}
