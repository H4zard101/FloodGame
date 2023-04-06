
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanZoom : MonoBehaviour
{
    Vector3 touchStart;
    public float zoomOutMin = 1;
    public float zoomOutMax = 120;
    public float cameraSpeed = 0;
    public float rotateSpeed = 5;
    public Camera playerCamera;

    private Quaternion targetRotation;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = playerCamera.ScreenToWorldPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 direction = touchStart - playerCamera.ScreenToWorldPoint(Input.mousePosition);
            playerCamera.transform.position += direction;
        }

        // Zoom in/out
        playerCamera.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * cameraSpeed;
        playerCamera.orthographicSize = Mathf.Clamp(playerCamera.orthographicSize, zoomOutMin, zoomOutMax);

        // Rotate camera
        if (Input.GetMouseButton(1))
        {
            float rotationX = Input.GetAxis("Mouse X") * rotateSpeed;
            float rotationY = Input.GetAxis("Mouse Y") * rotateSpeed;

            targetRotation = Quaternion.Euler(playerCamera.transform.rotation.eulerAngles + new Vector3(-rotationY, rotationX, 0));
        }

        playerCamera.transform.rotation = Quaternion.Lerp(playerCamera.transform.rotation, targetRotation, Time.deltaTime * 5f);
    }
}*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanZoom : MonoBehaviour
{
    Vector3 touchStart;
    public float zoomOutMin = 1;
    public float zoomOutMax = 120;
    public float cameraSpeed = 0;
    public float rotateSpeed = 5;
    public Camera playerCamera;

    public static bool isMoving = false;
    private Quaternion targetRotation;
    private Vector3 pivotPoint;

    void Start()
    {
        pivotPoint = playerCamera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = playerCamera.ScreenToWorldPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 direction = touchStart - playerCamera.ScreenToWorldPoint(Input.mousePosition);
            playerCamera.transform.position += direction;
            pivotPoint += direction;
            if(direction.x >= 0 || direction.y >= 0 || direction.z >= 0)
            {
                isMoving = true;
            }
            else
            {
                isMoving = false;
            }
        }

        // Zoom in/out
        playerCamera.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * cameraSpeed;
        playerCamera.orthographicSize = Mathf.Clamp(playerCamera.orthographicSize, zoomOutMin, zoomOutMax);

        // Rotate camera
        if (Input.GetMouseButton(1))
        {
            float rotationX = Input.GetAxis("Mouse X") * rotateSpeed;
            float rotationY = Input.GetAxis("Mouse Y") * rotateSpeed;

            targetRotation = Quaternion.Euler(playerCamera.transform.rotation.eulerAngles + new Vector3(-rotationY, rotationX, 0));
            playerCamera.transform.RotateAround(pivotPoint, Vector3.up, rotationX);
            playerCamera.transform.RotateAround(pivotPoint, Vector3.right, -rotationY);
        }

        playerCamera.transform.rotation = Quaternion.Lerp(playerCamera.transform.rotation, targetRotation, Time.deltaTime * 5f);
    }
}

