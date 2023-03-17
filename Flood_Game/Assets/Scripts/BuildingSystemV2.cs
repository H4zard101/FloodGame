using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingSystemV2 : MonoBehaviour
{

    public static BuildingSystemV2 current;

    public GridLayout gridLayout;
    private Grid grid;

    [SerializeField] private Tilemap mainTilemap;
    [SerializeField] private TileBase whiteTile;

    public GameObject treePrefab;
    public GameObject damPrefab;
    public GameObject damPrefabV2;
    public GameObject wallPrefab;

    //private PlaceableObject objectToPlace;

    [SerializeField] private LayerMask layerMask;
    public void Awake()
    {
        current = this;
        grid = gridLayout.gameObject.GetComponent<Grid>();
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            InitializeWithObject(treePrefab);
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            InitializeWithObject(damPrefab);
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            InitializeWithObject(damPrefabV2);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            InitializeWithObject(wallPrefab);
        }
    }

    #region Utils
    public static Vector3 GetMouseWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            return raycastHit.point;
        }
        else
        {
            return Vector3.zero;
        }
    }


    public Vector3 snapCoordinateToGrid(Vector3 position)
    {
        Vector3Int cellPos = gridLayout.WorldToCell(position);
        position = grid.GetCellCenterWorld(cellPos);
        return position;
    }

    #endregion

    #region BuildingPlacement

    public void InitializeWithObject(GameObject prefab)
    {
        Vector3 position = snapCoordinateToGrid(Vector3.zero);

        GameObject obj = Instantiate(prefab, position, Quaternion.identity);
        //objectToPlace = obj.GetComponent<PlaceableObject>();
        obj.AddComponent<ObjectDrag>();
    }
    #endregion
}
