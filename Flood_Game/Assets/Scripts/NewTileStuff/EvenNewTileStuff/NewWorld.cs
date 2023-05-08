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

    private float Cell_X_ID;
    private float Cell_Y_ID;
    private float Cell_Z_ID;


    public List<GameObject> cellObject = new List<GameObject>();

    public void Start()
    {

        foreach (Transform level in transform)
        {
            foreach (Transform cell in level)
            {
                cellObject.Add(cell.transform.gameObject);

            }
            
        }        
    }

    public void Update()
    {

    }
}
