using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildSystem : MonoBehaviour
{
    #region variables
    public GameObject[] buildObjects; // LIST OF ALL BUILD OBJECTS
 
    [SerializeField] private LayerMask layerMask; // ONLY PLACE OBJECTS ON A PARTICULAR LAYER

    public Vector3 objectPos; // POSITION OF THE OBJECT

    public GameObject objectSelected; // STORE THE OBJECTS THAT IS SELECTED

    public Camera playerCamera; // PlayerCamera

    public float gridSize;

    public bool gridOn;

    public bool canPlace;

    public float rotateAmount;

    public bool outOfMoney;

    [SerializeField] private Toggle gridToggle;
    #endregion

    // ASSIGN THE ONLY CAMERA IN THE SCENE
    private void Start()
    {
        playerCamera = FindObjectOfType<Camera>();
        canPlace = true;
        outOfMoney = false;
    }

    // INPUT HANDELING
    public void Update()
    {
        if(objectSelected != null)
        {
            if(gridOn)
            {
                objectSelected.transform.position = new Vector3(RoundToNearestGrid(objectPos.x), RoundToNearestGrid(objectPos.y), RoundToNearestGrid(objectPos.z));
            }
            else
            {
                objectSelected.transform.position = objectPos;
            }
            if (Input.GetMouseButtonDown(0) && canPlace)
            {                          
                objectSelected = null;
                SetCreditAmount.creditAmount -= BuildingCostToPlace.CostToPlace;

                if(SetCreditAmount.creditAmount <= 0)
                {
                    canPlace = false;
                    outOfMoney = true;
                }
                
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                RotateObject();
            }
        }

    }


    // CAMERA PHYSICS
    public void FixedUpdate()
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 1000000, layerMask))
        {
            objectPos = hit.point;
        }
    }

    // PLACE THE OBJECT
    public void placeObjectInScene(int index)
    {
        objectSelected = Instantiate(buildObjects[index], objectPos, Quaternion.identity);

        if (index == 0)
        {
            BuildingCostToPlace.CostToPlace = 5;
        }
        else if(index == 1)
        {
            BuildingCostToPlace.CostToPlace = 10;
        }
        else if (index == 2)
        {
            BuildingCostToPlace.CostToPlace = 25;
        }
        else if (index == 3)
        {
            BuildingCostToPlace.CostToPlace = 10;
        }
    }
    public void RotateObject()
    {
        objectSelected.transform.Rotate(Vector3.up, rotateAmount);
    }

    public void ToggleGrid()
    {
        if(gridToggle.isOn)
        {
            gridOn = true;
        }
        else if(!gridToggle.isOn)
        {
            gridOn = false;
        }
    }
    float RoundToNearestGrid(float pos)
    {
        float xDiff = pos % gridSize;
        pos -= xDiff;

        if(xDiff > (gridSize / 2))
        {
            pos += gridSize;
        }
        return pos;
    }
}
