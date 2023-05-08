using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class World : MonoBehaviour
{
    public enum Phase
    {
        Pause,
        Build,
        Simulation,
    }

    public Phase phase;

    public int iterations = 0;

    public static int destroyedUrban;
    public void Start()
    {
        phase = Phase.Build;
    }

    // make it cells
    public List<GameObject> cellObject = new List<GameObject>();
    public static List<GameObject> UrbanObject = new List<GameObject>();
    void Awake()
    {
        foreach (GameObject cell in GameObject.FindGameObjectsWithTag("Cell"))
        {
            cellObject.Add(cell);

            for (int i = 0; i < cellObject.Count; i++)
            {
                // Array of ints for the ID'S
                // expensive
                cell.GetComponent<Cell>().Cell_X_ID = (int)cell.transform.position.x;
                cell.GetComponent<Cell>().Cell_Z_ID = (int)cell.transform.position.z;
                cell.GetComponent<Cell>().Cell_Y_ID = (int)cell.transform.parent.parent.gameObject.transform.position.y;
            }
            if (cell.GetComponent<Cell>().Cellspace == Cell.CellSpace.Taken)
            {
                UrbanObject.Add(cell);
            }
        }
    }


    public void Update()
    {
        if (iterations == 2)
        {
            for (int i = 0; i < UrbanObject.Count; i++)
            {
                if (UrbanObject[i].GetComponentInChildren<UrbanAreas>().isDestroyed)
                {
                    destroyedUrban++;
                }
            }
            SceneManager.LoadScene("Results");
        }
    }

}
