using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class NewWorld : MonoBehaviour
{
    public int worldSizeX = 20; 
    public int worldSizeY = 5; 
    public int worldSizeZ = 30;

    private int cellSize = 1;

    public NewCell[,,] cells;

    public void Start()
    {
        cells = new NewCell[worldSizeX,worldSizeY, worldSizeZ];

        // loop through the children of the Grid. This will be the Tilemaps (Level1 , Level2 etc).
        foreach (Transform level in transform)
        {
            
            // loop through the children of the tilemaps. This will be the actual blocks/cells.
            foreach (Transform cell in level)
            {
                
            }
        }        
    }
}
