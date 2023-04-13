using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SelectedCell : MonoBehaviour
{
    // Gameobjects
    public GameObject selectedCell;
    public GameObject HighlightVisual;
    public GameObject BuildUI;
    public GameObject BuildObjects;

    public bool isLand;
    public bool isWater;

    public bool inMenu;

    public LayerMask layerMask;


    // Tile Ui
    public TMP_Text selectedCellUi;
    public TMP_Text cellDefenceUi;
    public TMP_Text currentWaterLevelUi;
    public TMP_Text maxWaterUi;

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && inMenu == false)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 1000, layerMask))
            {
                selectedCell = hit.collider.gameObject;              
                selectedCell.transform.GetChild(5).gameObject.SetActive(true);
                BuildUI.SetActive(true);
                inMenu = true;
                Debug.Log(selectedCell.GetComponent<Cell>().Celltype);

                selectedCellUi.text = "Selected Cell: " + selectedCell.GetComponent<Cell>().Celltype.ToString();
                cellDefenceUi.text = "Cell Defence: " + selectedCell.GetComponent<Cell>().Celldefence.ToString();
                currentWaterLevelUi.text = "Current Water Level: " + selectedCell.GetComponent<Cell>().CurrentWaterLevel.ToString();
                maxWaterUi.text = "Max Water Level: " + selectedCell.GetComponent<Cell>().MaximumWaterLevel.ToString();               
            }
            else
            {
                selectedCell = null;
            }
                
        }
        UpdateDataUi();

        
    }

    public void UpdateDataUi()
    {
        if (selectedCell != null)
        {
            selectedCellUi.text = "Selected Cell: " + selectedCell.GetComponent<Cell>().Celltype.ToString();
            cellDefenceUi.text = "Cell Defence: " + selectedCell.GetComponent<Cell>().Celldefence.ToString();
            currentWaterLevelUi.text = "Current Water Level: " + selectedCell.GetComponent<Cell>().CurrentWaterLevel.ToString();
            maxWaterUi.text = "Max Water Level: " + selectedCell.GetComponent<Cell>().MaximumWaterLevel.ToString();
        }
        else if (selectedCell == null)
        {
            selectedCellUi.text = "Selected Cell: N/A" ;
            cellDefenceUi.text = "Cell Defence: N/A" ;
            currentWaterLevelUi.text = "Current Water Level: N/A" ;
            maxWaterUi.text = "Max Water Level: N/A" ;
        }

    }
}
