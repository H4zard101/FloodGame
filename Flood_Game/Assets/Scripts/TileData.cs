using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileData : MonoBehaviour
{
    public float currentTileLevel = 0.1F;
    public float maximumTileLevel = 1.0F;
    public bool isOverFlooded = false;

    public MeshFilter waterMeshFilter;
    public MeshFilter grassMeshFilter;
    public MeshFilter mudMeshFilter;
    public void Update()
    {

        // GRASS BLOCK
        if (currentTileLevel <= 0.5f)
        {
            this.gameObject.GetComponent<MeshFilter>().sharedMesh = grassMeshFilter.sharedMesh;
        }
        // WATER BLOCK
        else if (currentTileLevel >= 0.9f)
        {
            this.gameObject.GetComponent<MeshFilter>().sharedMesh = waterMeshFilter.sharedMesh;


        }
        // MUD BLOCK
        else if (currentTileLevel >= 0.7f)
        {
            this.gameObject.GetComponent<MeshFilter>().sharedMesh = mudMeshFilter.sharedMesh;
        }
    }
}
