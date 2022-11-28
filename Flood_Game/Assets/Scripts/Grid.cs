using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] int width = 100;
    [SerializeField] int height = 100;

    [SerializeField] GameObject tilePrefab;


    [SerializeField] Transform camera;
    [SerializeField] Camera _camera;

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
                Instantiate(tilePrefab, new Vector3(x , 0, z), Quaternion.identity);
            }
        }

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit raycastHit;
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out raycastHit, 100.0f))
            {
                
            }
        }
    }
    void SetCamera()
    {
        camera.transform.position = new Vector3(width / 2 - 0.5F, height / 2 - 0.5F, -5);
        camera.transform.rotation = Quaternion.Euler(45, 0, 0);
    }
}
