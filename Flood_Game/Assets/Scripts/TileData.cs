using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileData : MonoBehaviour
{
    public float currentTileLevel = 0.1F;
    public float maximumTileLevel = 1.0F;
    public bool isOverFlooded = false;

    public MeshFilter objectMesh;
    public void Update()
    {
        // WATER BLOCK
        if(currentTileLevel >= 0.9f)
        {
            
        }
        // MUD BLOCK
        if (currentTileLevel >= 0.7f)
        {

        }
        // GRASS BLOCK
        if (currentTileLevel <= 0.5f)
        {

        }
    }
}
