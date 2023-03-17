using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    public List<GameObject> cellObject = new List<GameObject>();
    
    void Start()
    {
        foreach(GameObject cell in GameObject.FindGameObjectsWithTag("Cell"))
        {
            cellObject.Add(cell);

            for (int i = 0; i < cellObject.Count; i++)
            {
                cell.GetComponent<Cell>().CellID++;
            }
        }

    }

}
