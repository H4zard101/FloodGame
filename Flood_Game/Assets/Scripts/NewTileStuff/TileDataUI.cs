using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public static class TileDataUI
{

    // UI objects
    public static TMP_Text selectedCellUi;
    public static TMP_Text cellDefenceUi;
    public static TMP_Text currentWaterLevelUi;
    public static TMP_Text maxWaterUi;

    public static void SetTileValues(GameObject selectedCell)
    {
        selectedCellUi.text = "Selected Cell: " + selectedCell.GetComponent<Cell>().Celltype;
        cellDefenceUi.text = "Selected Cell: ";
        currentWaterLevelUi.text = "Selected Cell: ";
        maxWaterUi.text = "Selected Cell: ";

    }

}
