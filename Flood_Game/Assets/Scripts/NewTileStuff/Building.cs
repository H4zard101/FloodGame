using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public SelectedCell SelectedCell;
    public GameObject selectedObject;

    public bool canPlace;
    public bool outOfMoney;
    public bool canBuild;
    private void Start()
    {
        SelectedCell = FindObjectOfType<SelectedCell>();
        canPlace = true;
        outOfMoney = false;
        canBuild = false;
    }

    private void Update()
    {
        if (canBuild == false)
        {

            if (SetCreditAmount.CreditAmount < BuildingCostToPlace.CostToPlace)
            {
                Debug.Log("hello");
                canPlace = false;
                outOfMoney = true;
            }
            if (canPlace)
            {
                SetCreditAmount.CreditAmount -= BuildingCostToPlace.CostToPlace;
                canBuild = true;
            }
                 
        }
    }
    public void BuildTree()
    {
        selectedObject = SelectedCell.GetComponent<SelectedCell>().selectedCell;
        selectedObject.transform.GetChild(0);
        selectedObject.GetComponent<Cell>().Celldefence = Cell.CellDefence.Tree;
        BuildingCostToPlace.CostToPlace = 5;

        SelectedCell.BuildUI.SetActive(false);
        SelectedCell.BuildObjects.SetActive(false);

        canBuild = false;

    }
    public void BuildLeakyDam()
    {
        selectedObject = SelectedCell.GetComponent<SelectedCell>().selectedCell;
        selectedObject.transform.GetChild(0);
        selectedObject.GetComponent<Cell>().Celldefence = Cell.CellDefence.LeakyDam;
        BuildingCostToPlace.CostToPlace = 10;

        SelectedCell.BuildUI.SetActive(false);
        SelectedCell.BuildObjects.SetActive(false);

        canBuild = false;

    }
    public void BuildBetterDam()
    {
        selectedObject = SelectedCell.GetComponent<SelectedCell>().selectedCell;
        selectedObject.transform.GetChild(0);
        selectedObject.GetComponent<Cell>().Celldefence = Cell.CellDefence.BetterDam;
        BuildingCostToPlace.CostToPlace = 25;

        SelectedCell.BuildUI.SetActive(false);
        SelectedCell.BuildObjects.SetActive(false);

        canBuild = false;
    }
    public void BuildWall()
    {
        selectedObject = SelectedCell.GetComponent<SelectedCell>().selectedCell;
        selectedObject.transform.GetChild(0);
        selectedObject.GetComponent<Cell>().Celldefence = Cell.CellDefence.Wall;
        BuildingCostToPlace.CostToPlace = 10;

        SelectedCell.BuildUI.SetActive(false);
        SelectedCell.BuildObjects.SetActive(false);

        canBuild = false;

    }
}
