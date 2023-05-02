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


    public List<GameObject> cellObjects = new List<GameObject>();

    private float Cell_X_ID;
    private float Cell_Y_ID;
    private float Cell_Z_ID;

    public void Start()
    {
        

        // loop through the children of the Grid. This will be the Tilemaps (Level1 , Level2 etc).
        foreach (Transform level in transform)
        {
            
            // loop through the children of the tilemaps. This will be the actual blocks/cells.
            foreach (Transform cell in level)
            {
                cellObjects.Add(cell.gameObject);
                //SetIndex(cell.);
            }
        }        
    }

    public void Update()
    {
        for (int i = 0; i < cellObjects.Count; i++)
        {
            
        }
    }
}
