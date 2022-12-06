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

    public float rotateAmount;

    [SerializeField] private Toggle gridToggle;
    #endregion

    // ASSIGN THE ONLY CAMERA IN THE SCENE
    private void Start()
    {
        playerCamera = FindObjectOfType<Camera>();
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
            if (Input.GetMouseButtonDown(0))
            {                          
                objectSelected = null;
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

        if(Physics.Raycast(ray, out hit, 10000, layerMask))
        {
            objectPos = hit.point;
        }
    }

    // PLACE THE OBJECT
    public void placeObjectInScene(int index)
    {
        objectSelected = Instantiate(buildObjects[index],objectPos,Quaternion.identity);
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
