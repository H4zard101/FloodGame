/*using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WaterDrawing : MonoBehaviour
{
    public List<Tilemap> waterTilemaps; // List of Tilemaps for water on different levels
    public TileBase waterTile; // Water tile to be placed on the tilemap

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            PlaceWaterTile(mouseWorldPos);
        }
        else if (Input.GetMouseButton(1))
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RemoveWaterTile(mouseWorldPos);
        }
    }

    private void PlaceWaterTile(Vector3 mouseWorldPos)
    {
        foreach (var waterTilemap in waterTilemaps)
        {
            Vector3Int cellPos = waterTilemap.WorldToCell(mouseWorldPos);

            // Place water tile at the selected tile position
            waterTilemap.SetTile(cellPos, waterTile);

            // Change the size of the water tile
            GameObject tileGameObject = waterTilemap.GetInstantiatedObject(cellPos);
            if (tileGameObject != null)
            {
                Transform tileTransform = tileGameObject.transform;
                tileTransform.localScale = GetTileScale(waterTilemap);
            }
        }
    }

    private void RemoveWaterTile(Vector3 mouseWorldPos)
    {
        foreach (var waterTilemap in waterTilemaps)
        {
            Vector3Int cellPos = waterTilemap.WorldToCell(mouseWorldPos);

            // Remove water tile at the selected tile position
            waterTilemap.SetTile(cellPos, null);
        }
    }

    private Vector3 GetTileScale(Tilemap tilemap)
    {
        // Get the grid cell size from the GridLayout
        GridLayout gridLayout = tilemap.GetComponentInParent<GridLayout>();
        Vector3 cellSize = gridLayout.cellSize;

        // Adjust the scale based on cell size
        Vector3 scale = new Vector3(cellSize.x / 32f, cellSize.y / 32f, 1f); // Assuming the tile size is 32x32 pixels

        return scale;
    }
}*///1st 
/*using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WaterDrawing : MonoBehaviour
{
    public List<Tilemap> waterTilemaps; // List of Tilemaps for water on different levels
    public TileBase waterTile; // Water tile to be placed on the tilemap

    private Camera mainCamera;
    private GridLayout gridLayout;

    private void Start()
    {
        mainCamera = Camera.main;
        gridLayout = FindObjectOfType<GridLayout>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            PlaceWaterTile();
        }
        else if (Input.GetMouseButton(1))
        {
            RemoveWaterTile();
        }
    }

    private void PlaceWaterTile()
    {
        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int cellPos = gridLayout.WorldToCell(mouseWorldPos);

        foreach (var waterTilemap in waterTilemaps)
        {
            // Place water tile at the selected tile position
            waterTilemap.SetTile(cellPos, waterTile);
        }
    }

    private void RemoveWaterTile()
    {
        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int cellPos = gridLayout.WorldToCell(mouseWorldPos);

        foreach (var waterTilemap in waterTilemaps)
        {
            // Remove water tile at the selected tile position
            waterTilemap.SetTile(cellPos, null);
        }
    }
}*/ //drawing is better
/*using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WaterDrawing : MonoBehaviour
{
    public List<Tilemap> waterTilemaps; // List of Tilemaps for water on different levels
    public TileBase waterTile; // Water tile to be placed on the tilemap

    private Camera mainCamera;
    private GridLayout gridLayout;

    private void Start()
    {
        mainCamera = Camera.main;
        gridLayout = FindObjectOfType<GridLayout>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            PlaceWaterTile();
        }
        else if (Input.GetMouseButton(1))
        {
            RemoveWaterTile();
        }
    }

    private void PlaceWaterTile()
    {
        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int cellPos = gridLayout.WorldToCell(mouseWorldPos);

        foreach (var waterTilemap in waterTilemaps)
        {
            // Place water tile at the selected tile position
            if (waterTilemap.HasTile(cellPos))
            {
                // Water tile already exists; skip placing it
                continue;
            }
            waterTilemap.SetTile(cellPos, waterTile);
        }
    }

    private void RemoveWaterTile()
    {
        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int cellPos = gridLayout.WorldToCell(mouseWorldPos);

        foreach (var waterTilemap in waterTilemaps)
        {
            // Remove water tile at the selected tile position
            waterTilemap.SetTile(cellPos, null);
        }
    }
}*/
/*using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WaterDrawing : MonoBehaviour
{
    public List<Tilemap> waterTilemaps; // List of Tilemaps for water on different levels
    public TileBase waterTile; // Water tile to be placed on the tilemap
    public float waterTileScale = 0.3f; // Desired water tile scale

    private Camera mainCamera;
    private GridLayout gridLayout;

    private void Start()
    {
        mainCamera = Camera.main;
        gridLayout = FindObjectOfType<GridLayout>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            PlaceWaterTile();
        }
        else if (Input.GetMouseButton(1))
        {
            RemoveWaterTile();
        }
    }

    private void PlaceWaterTile()
    {
        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int cellPos = gridLayout.WorldToCell(mouseWorldPos);

        foreach (var waterTilemap in waterTilemaps)
        {
            // Place water tile at the selected tile position
            if (waterTilemap.HasTile(cellPos))
            {
                // Water tile already exists; skip placing it
                continue;
            }
            waterTilemap.SetTile(cellPos, waterTile);

            // Adjust the scale of the placed water tile
            GameObject tileGameObject = waterTilemap.GetInstantiatedObject(cellPos);
            if (tileGameObject != null)
            {
                Transform tileTransform = tileGameObject.transform;
                tileTransform.localScale = new Vector3(waterTileScale, waterTileScale, 1f);
            }
        }
    }

    private void RemoveWaterTile()
    {
        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int cellPos = gridLayout.WorldToCell(mouseWorldPos);

        foreach (var waterTilemap in waterTilemaps)
        {
            // Remove water tile at the selected tile position
            waterTilemap.SetTile(cellPos, null);
        }
    }
}*/
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WaterDrawing : MonoBehaviour
{
    public Tilemap waterTilemap; // Tilemap for water
    public TileBase waterTile; // Water tile to be placed on the tilemap
    public Vector2Int gridMin; // Minimum grid position (inclusive)
    public Vector2Int gridMax; // Maximum grid position (inclusive)

    private Camera mainCamera;
    private GridLayout gridLayout;

    private void Start()
    {
        mainCamera = Camera.main;
        gridLayout = FindObjectOfType<GridLayout>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            PlaceWaterTile();
        }
        else if (Input.GetMouseButton(1))
        {
            RemoveWaterTile();
        }
    }

    private void PlaceWaterTile()
    {
        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int cellPos = gridLayout.WorldToCell(mouseWorldPos);

        // Check if cellPos is within the defined grid bounds
        if (IsInsideGridBounds(cellPos))
        {
            // Place water tile at the selected tile position
            if (waterTilemap.HasTile(cellPos))
            {
                // Water tile already exists; skip placing it
                return;
            }
            waterTilemap.SetTile(cellPos, waterTile);
        }
    }

    private void RemoveWaterTile()
    {
        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int cellPos = gridLayout.WorldToCell(mouseWorldPos);

        // Check if cellPos is within the defined grid bounds
        if (IsInsideGridBounds(cellPos))
        {
            // Remove water tile at the selected tile position
            waterTilemap.SetTile(cellPos, null);
        }
    }

    private bool IsInsideGridBounds(Vector3Int cellPos)
    {
        // Check if the cell position is within the defined grid bounds
        return cellPos.x >= gridMin.x && cellPos.x <= gridMax.x &&
               cellPos.y >= gridMin.y && cellPos.y <= gridMax.y;
    }
}
