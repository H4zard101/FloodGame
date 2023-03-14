using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum CellType
{
    Mud,
    Water,
    Grass,
    GrassWithWater1,
    GrassWithWater2,
    GrassWithWater3,
    
}

public enum CellDefence
{
    Empty,
    Wall,
    Tree,
    LeakyDam,
    BetterDam,
    Urban,
}


public class Cell : MonoBehaviour
{
    // Cell Data
    public float CurrentWaterLevel = 0.0f;
    public float MaximumWaterLevel = 1.0f;
    public float ExceedingAmount = 0.0f;
    public float ResistanceAmount = 0.0f;


    // Cell Type
    public CellType CellType;

    // Cell Defence Type
    public CellDefence CellDefence;


    // Cell Meshes
    public MeshFilter waterMeshFilter;
    public MeshFilter grassMeshFilter;
    public MeshFilter grassWithWater1;
    public MeshFilter grassWithWater2;
    public MeshFilter grassWithWater3;

    // Cell Defence Objects
    public GameObject Wall;
    public GameObject Tree;
    public GameObject LeakyDam;
    public GameObject BetterDam;


    public void Update()
    {
        // This function will update the cell mesh depending on the current water level. Also this change will affect the enum of that particular cell
        UpdateCellType();

        // This function will update the cell defence type and make the diffrent defences visible to the user
        UpdateCellDefence();
    }

    public void UpdateCellType()
    {    
        // GRASS BLOCK
        if (CurrentWaterLevel <= 0.2f)
        {
            this.gameObject.GetComponent<MeshFilter>().sharedMesh = grassMeshFilter.sharedMesh;
            CellType = CellType.Grass;

        }

        // GRASS BLOCK WITH SOME WATER
        else if (CurrentWaterLevel <= 0.4f)
        {
            this.gameObject.GetComponent<MeshFilter>().sharedMesh = grassWithWater1.sharedMesh;
            CellType = CellType.GrassWithWater1;

        }

        // GRASS BLOCK WITH SOME WATER 2
        else if (CurrentWaterLevel <= 0.6f)
        {
            this.gameObject.GetComponent<MeshFilter>().sharedMesh = grassWithWater2.sharedMesh;
            CellType = CellType.GrassWithWater2;
        }

        // GRASS BLOCK WITH SOME WATER 2
        else if (CurrentWaterLevel <= 0.8f)
        {
            this.gameObject.GetComponent<MeshFilter>().sharedMesh = grassWithWater3.sharedMesh;
            CellType = CellType.GrassWithWater3;
        }

        // WATER BLOCK
        else if (CurrentWaterLevel >= 1.0f)
        {
            this.gameObject.GetComponent<MeshFilter>().sharedMesh = waterMeshFilter.sharedMesh;
            CellType = CellType.Water;
        }
    }

    public void UpdateCellDefence()
    {
        // if nothing is built in this cell;
        if(CellDefence == CellDefence.Empty)
        {
            return;
        }

        else if (CellDefence == CellDefence.Tree)
        {
            Wall.SetActive(false);
            Tree.SetActive(true);
            LeakyDam.SetActive(false);
            BetterDam.SetActive(false);
        }
        else if (CellDefence == CellDefence.Wall)
        {
            Wall.SetActive(true);
            Tree.SetActive(false);
            LeakyDam.SetActive(false);
            BetterDam.SetActive(false);
        }
        else if (CellDefence == CellDefence.LeakyDam)
        {
            Wall.SetActive(false);
            Tree.SetActive(false);
            LeakyDam.SetActive(true);
            BetterDam.SetActive(false);
        }
        else if (CellDefence == CellDefence.BetterDam)
        {
            Wall.SetActive(false);
            Tree.SetActive(false);
            LeakyDam.SetActive(false);
            BetterDam.SetActive(true);
        }
        else if(CellDefence == CellDefence.Urban)
        {
            return;
        }

    }
}
