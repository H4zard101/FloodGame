using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    public List<GameObject> cellObject = new List<GameObject>();
    
    void Awake()
    {
        foreach(GameObject cell in GameObject.FindGameObjectsWithTag("Cell"))
        {
            cellObject.Add(cell);

            for (int i = 0; i < cellObject.Count; i++)
            {
                cell.GetComponent<Cell>().Cell_X_ID = (int)cell.transform.position.x;
                cell.GetComponent<Cell>().Cell_Z_ID = (int)cell.transform.position.z;      
                cell.GetComponent<Cell>().Cell_Y_ID = (int)cell.transform.parent.parent.gameObject.transform.position.y;

            }
        }

    }

}
