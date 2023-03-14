using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileData : MonoBehaviour
{
    // water levels
    public float currentTileLevel = 0.1F;
    public float maximumTileLevel = 1.0F;
    public float amountExeding = 0.0f;

    // will be the neighbour tiles
    public List<GameObject> neighbours = new List<GameObject>();

    // Diffrent MeshTypes
    public MeshFilter waterMeshFilter;
    public MeshFilter grassMeshFilter;
    public MeshFilter grassWithWater1;
    public MeshFilter grassWithWater2;
    public MeshFilter grassWithWater3;
    //public MeshFilter mudMeshFilter;

    public void Start()
    {
        //AddNeighbours();
    }
    public void Update()
    {
        UpdateTileMesh();

        if (currentTileLevel >= 1.0f)
        {
            AffectNeighbours();
        }

    }
    public void UpdateTileMesh()
    {
        // GRASS BLOCK
        if (currentTileLevel <= 0.2f)
        {
            this.gameObject.GetComponent<MeshFilter>().sharedMesh = grassMeshFilter.sharedMesh;

        }
        // GRASS BLOCK WITH SOME WATER
        else if (currentTileLevel <= 0.4f)
        {
            this.gameObject.GetComponent<MeshFilter>().sharedMesh = grassWithWater1.sharedMesh;

        }
        // GRASS BLOCK WITH SOME WATER 2
        else if (currentTileLevel <= 0.6f)
        {
            this.gameObject.GetComponent<MeshFilter>().sharedMesh = grassWithWater2.sharedMesh;

        }
        // GRASS BLOCK WITH SOME WATER 2
        else if (currentTileLevel <= 0.8f)
        {
            this.gameObject.GetComponent<MeshFilter>().sharedMesh = grassWithWater3.sharedMesh;

        }
        // WATER BLOCK
        else if (currentTileLevel >= 1.0f)
        {
            this.gameObject.GetComponent<MeshFilter>().sharedMesh = waterMeshFilter.sharedMesh;

        }
    }

    public void AffectNeighbours()
    {
        amountExeding = currentTileLevel - maximumTileLevel;
        for (int i = 0; i < neighbours.Count; i++)
        {
            neighbours[i].GetComponent<TileData>().currentTileLevel += amountExeding;
        }
        currentTileLevel -= amountExeding;
    }
}
