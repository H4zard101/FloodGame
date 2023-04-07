using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildTrigger : MonoBehaviour
{
    public GameObject buildPanel;

    public void BuildButtons()
    {
        buildPanel.SetActive(true);
    }

}
