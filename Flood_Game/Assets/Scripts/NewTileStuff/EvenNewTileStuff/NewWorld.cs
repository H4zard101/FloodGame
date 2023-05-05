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


    //[SerializeField]
    //public Cell[,,] cells;

    Grid grid;
    private float Cell_X_ID;
    private float Cell_Y_ID;
    private float Cell_Z_ID;


    public List<GameObject> cellObject = new List<GameObject>();

    public void Start()
    {
        //cells = new Cell[worldSizeX, worldSizeY, worldSizeZ];

        // loop through the children of the Grid. This will be the Tilemaps (Level1 , Level2 etc).
        foreach (Transform level in transform)
        {

            // loop through the children of the tilemaps. This will be the actual blocks/cells.
            foreach (Transform cell in level)
            {
                cellObject.Add(cell.transform.gameObject);
                //cells[(int)(cell.transform.position.x - 20.5), (int)cell.transform.position.y, (int)(cell.transform.position.z - 36.5)] = cell.gameObject.GetComponentInChildren<Cell>();
                
                // Get positions in the grid rather than world positions
            }
            
        }        
    }

    public void Update()
    {

    }
}
