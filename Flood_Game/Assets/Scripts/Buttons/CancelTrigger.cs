using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelTrigger : MonoBehaviour
{
    public GameObject cancelButton;
    public SelectedCell selectedCell;
    public GameObject bottomPanel;

    public void Start()
    {
        selectedCell = FindObjectOfType<SelectedCell>();
    }
    public void CancelButtons()
    {
        selectedCell.selectedCell.transform.GetChild(5).gameObject.SetActive(false);
        selectedCell.inMenu = false;
        //selectedCell = null;
        cancelButton.SetActive(false);
        bottomPanel.SetActive(false); 
    }
}
