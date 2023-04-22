using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public enum CellSpace
    {
        Empty,
        Taken,
    }

    public enum CellDefence
    {
        Empty,
        Wall,
        Tree,
        LeakyDam,
        BetterDam,
    }
    public enum CellType
    {
        Mud,
        Water,
        Grass,
        GrassWithWater1,
        GrassWithWater2,
        GrassWithWater3,

    }

    // Cell Data
    public float CurrentWaterLevel = 0.0f;
    public float MaximumWaterLevel = 1.0f;
    public float ExceedingAmount = 0.0f;
    public float ResistanceAmount = 0.0f;

    public bool hasBottomNeighbour = false;

    // Cell Type
    public CellType Celltype;

    // Cell Defence Type
    public CellDefence Celldefence;

    // Cell Space Type
    public CellSpace Cellspace;


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
    public GameObject Urban;

    // Cell ID'S
    public float Cell_X_ID;
    public float Cell_Y_ID;
    public float Cell_Z_ID;


    // Cells Neighbours
    public GameObject UpNeighbour;
    public GameObject DownNeighbour;
    public GameObject ForwardNeighbour;
    public GameObject BackNeighbour;
    public GameObject LeftNeighbour;
    public GameObject RightNeighbour;


    // List of Neighbours
    public List<GameObject> neighbours = new List<GameObject>();


    public World World;
    public SelectedCell selectedCell;
    public void Start()
    {

        World = FindObjectOfType <World>();
        selectedCell = FindObjectOfType<SelectedCell>();

        if (Celltype == CellType.Grass)
        {
            CurrentWaterLevel = 0.2f;
        }
        else if (Celltype == CellType.GrassWithWater1)
        {
            CurrentWaterLevel = 0.4f;
        }
        else if (Celltype == CellType.GrassWithWater2)
        {
            CurrentWaterLevel = 0.6f;
        }
        else if (Celltype == CellType.GrassWithWater3)
        {
            CurrentWaterLevel = 0.8f;
        }
        else if (Celltype == CellType.Water)
        {
            CurrentWaterLevel = 1.0f;
        }

        // Spawn in urban areas
        InitUrbanArea();

        // Find the neighbour cells and add them to the list
        AddNeighbourCells();
    }
    public void Update()
    {
        // This function will update the cell mesh depending on the current water level. Also this change will affect the enum of that particular cell
        UpdateCellType();

        // This function will update the cell defence type and make the diffrent defences visible to the user
        UpdateCellDefence();

        if (CurrentWaterLevel >= MaximumWaterLevel)
        {
            AffectNeighbours();
        }
    }

    public void UpdateCellType()
    {    
        // GRASS BLOCK
        if (CurrentWaterLevel <= 0.2f)
        {
            this.gameObject.GetComponent<MeshFilter>().sharedMesh = grassMeshFilter.sharedMesh;
            Celltype = CellType.Grass;

        }

        // GRASS BLOCK WITH SOME WATER
        else if (CurrentWaterLevel <= 0.4f)
        {
            this.gameObject.GetComponent<MeshFilter>().sharedMesh = grassWithWater1.sharedMesh;
            Celltype = CellType.GrassWithWater1;

        }

        // GRASS BLOCK WITH SOME WATER 2
        else if (CurrentWaterLevel <= 0.6f)
        {
            this.gameObject.GetComponent<MeshFilter>().sharedMesh = grassWithWater2.sharedMesh;
            Celltype = CellType.GrassWithWater2;
        }

        // GRASS BLOCK WITH SOME WATER 2
        else if (CurrentWaterLevel <= 0.8f)
        {
            this.gameObject.GetComponent<MeshFilter>().sharedMesh = grassWithWater3.sharedMesh;
            Celltype = CellType.GrassWithWater3;
        }

        // WATER BLOCK
        else if (CurrentWaterLevel >= 1.0f)
        {
            this.gameObject.GetComponent<MeshFilter>().sharedMesh = waterMeshFilter.sharedMesh;
            Celltype = CellType.Water;
        }
    }

    public void UpdateCellDefence()
    {
        // if nothing is built in this cell;
        if(Celldefence == CellDefence.Empty)
        {
            return;
        }

        else if (Celldefence == CellDefence.Tree)
        {
            Wall.SetActive(false);
            Tree.SetActive(true);
            LeakyDam.SetActive(false);
            BetterDam.SetActive(false);
            ResistanceAmount = 1.5f;
            MaximumWaterLevel = ResistanceAmount;
        }
        else if (Celldefence == CellDefence.Wall)
        {
            Wall.SetActive(true);
            Tree.SetActive(false);
            LeakyDam.SetActive(false);
            BetterDam.SetActive(false);
            ResistanceAmount = 1.5f;
            MaximumWaterLevel = ResistanceAmount;


        }
        else if (Celldefence == CellDefence.LeakyDam)
        {
            Wall.SetActive(false);
            Tree.SetActive(false);
            LeakyDam.SetActive(true);
            BetterDam.SetActive(false);
            ResistanceAmount = 2.0f;
            MaximumWaterLevel = ResistanceAmount;

        }
        else if (Celldefence == CellDefence.BetterDam)
        {
            Wall.SetActive(false);
            Tree.SetActive(false);
            LeakyDam.SetActive(false);
            BetterDam.SetActive(true);
            ResistanceAmount = 3.0f;
            MaximumWaterLevel = ResistanceAmount;

        }

    }

    public void InitUrbanArea()
    {
        if(Cellspace == CellSpace.Taken)
        {
            Urban.SetActive(true);
        }
        else
        {
            Urban.SetActive(false);
        }
    }    
    public void AddNeighbourCells()
    {
        
        for (int i = 0; i < World.cellObject.Count; i++)
        {
            //neighbours = new List<GameObject>();
            if (World.cellObject[i].GetComponent<Cell>().Cell_X_ID == this.Cell_X_ID && World.cellObject[i].GetComponent<Cell>().Cell_Y_ID == this.Cell_Y_ID - 1 &&
                World.cellObject[i].GetComponent<Cell>().Cell_Z_ID == this.Cell_Z_ID)
            {
                // Down Neighbour
                //neighbours.Add(World.cellObject[i].gameObject);
                hasBottomNeighbour = true;

            }


            //if (hasBottomNeighbour)
            //{
                if (World.cellObject[i].GetComponent<Cell>().Cell_X_ID == this.Cell_X_ID && World.cellObject[i].GetComponent<Cell>().Cell_Y_ID == this.Cell_Y_ID - 1 &&
                    World.cellObject[i].GetComponent<Cell>().Cell_Z_ID == this.Cell_Z_ID + 1)
                {
                    // Down Forward Neighbour
                    ForwardNeighbour = World.cellObject[i].gameObject;
                    neighbours.Add(World.cellObject[i].gameObject);
                }

                if (World.cellObject[i].GetComponent<Cell>().Cell_X_ID == this.Cell_X_ID && World.cellObject[i].GetComponent<Cell>().Cell_Y_ID == this.Cell_Y_ID - 1 &&
                    World.cellObject[i].GetComponent<Cell>().Cell_Z_ID == this.Cell_Z_ID - 1)
                {
                    // Down Back Neighbour
                    BackNeighbour = World.cellObject[i].gameObject;
                    neighbours.Add(World.cellObject[i].gameObject);
                    
                }
            //}
            if (!hasBottomNeighbour)
            {
                if (World.cellObject[i].GetComponent<Cell>().Cell_X_ID == this.Cell_X_ID - 1 && World.cellObject[i].GetComponent<Cell>().Cell_Y_ID == this.Cell_Y_ID &&
                    World.cellObject[i].GetComponent<Cell>().Cell_Z_ID == this.Cell_Z_ID)
                {
                    // Left Neighbour
                    neighbours.Add(World.cellObject[i].gameObject);
                }

                if (World.cellObject[i].GetComponent<Cell>().Cell_X_ID == this.Cell_X_ID + 1 && World.cellObject[i].GetComponent<Cell>().Cell_Y_ID == this.Cell_Y_ID &&
                    World.cellObject[i].GetComponent<Cell>().Cell_Z_ID == this.Cell_Z_ID)
                {
                    // Right Neighbour
                    neighbours.Add(World.cellObject[i].gameObject);
                }

                if (World.cellObject[i].GetComponent<Cell>().Cell_X_ID == this.Cell_X_ID && World.cellObject[i].GetComponent<Cell>().Cell_Y_ID == this.Cell_Y_ID &&
                    World.cellObject[i].GetComponent<Cell>().Cell_Z_ID == this.Cell_Z_ID + 1)
                {
                    // Forward Neighbour
                    neighbours.Add(World.cellObject[i].gameObject);
                }

                if (World.cellObject[i].GetComponent<Cell>().Cell_X_ID == this.Cell_X_ID && World.cellObject[i].GetComponent<Cell>().Cell_Y_ID == this.Cell_Y_ID &&
                    World.cellObject[i].GetComponent<Cell>().Cell_Z_ID == this.Cell_Z_ID - 1)
                {
                    // Back Neighbour
                    neighbours.Add(World.cellObject[i].gameObject);
                }
            }


            //// Do we need the UP neighbour
            //if (World.cellObject[i].GetComponent<Cell>().Cell_X_ID == this.Cell_X_ID && World.cellObject[i].GetComponent<Cell>().Cell_Y_ID == this.Cell_Y_ID + 1 && 
            //    World.cellObject[i].GetComponent<Cell>().Cell_Z_ID == this.Cell_Z_ID)
            //{
            //    // Up Neighbour
            //    neighbours.Add(World.cellObject[i].gameObject);
            //}

            //if (World.cellObject[i].GetComponent<Cell>().Cell_X_ID == this.Cell_X_ID && World.cellObject[i].GetComponent<Cell>().Cell_Y_ID == this.Cell_Y_ID - 1 && 
            //    World.cellObject[i].GetComponent<Cell>().Cell_Z_ID == this.Cell_Z_ID)
            //{
            //    // Down Neighbour
            //    neighbours.Add(World.cellObject[i].gameObject);
            //}




        }
    }
    public void AffectNeighbours()
    {
        ExceedingAmount = CurrentWaterLevel - MaximumWaterLevel;
        for (int i = 0; i < neighbours.Count; i++)
        {
            neighbours[i].GetComponent<Cell>().CurrentWaterLevel += ExceedingAmount / neighbours.Count;
        }
        CurrentWaterLevel -= ExceedingAmount;
    }
}
