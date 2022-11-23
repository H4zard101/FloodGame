using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] int width = 100;
    [SerializeField] int height = 100;

    [SerializeField] GameObject tilePrefab;


    [SerializeField] Transform camera;

    private void Start()
    {
        GenerateGrid();
        SetCamera();
    }
    void GenerateGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                Instantiate(tilePrefab, new Vector3(x, 0, z), Quaternion.identity);
            }
        }

    }

    void SetCamera()
    {
        camera.transform.position = new Vector3(width / 2 - 0.5F, height / 2 - 0.5F, -4);
        camera.transform.rotation = Quaternion.Euler(45, 0, 0);
    }
}
