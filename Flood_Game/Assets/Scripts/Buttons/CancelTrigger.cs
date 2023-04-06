using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelTrigger : MonoBehaviour
{
    public GameObject cancelButton;
    public SelectedCell selectedCell;

    public void Start()
    {
        selectedCell = FindObjectOfType<SelectedCell>();
    }
    public void CancelButtons()
    {
        //selectedCell.transform.GetChild(5).gameObject.SetActive(false);
        selectedCell.inMenu = false;
        selectedCell = null;
        cancelButton.SetActive(false);
    }
}
