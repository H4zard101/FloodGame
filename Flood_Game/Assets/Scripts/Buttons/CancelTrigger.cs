using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelTrigger : MonoBehaviour
{
    public GameObject cancelButton;
    public void CancelButtons()
    {
        cancelButton.SetActive(false);
    }
}
