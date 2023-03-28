
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
    private Vector3 touchStart;
    public float zoomOutMin = 1f;
    public float zoomOutMax = 120f;
    public float cameraSpeed = 1f;
    public float rotateSpeed = 5f;
    public Camera playerCamera;

    private Quaternion targetRotation;
    private float xRotation = 0f;
    private float yRotation = 0f;

    void Start()
    {
        targetRotation = playerCamera.transform.rotation;
        xRotation = targetRotation.eulerAngles.x;
        yRotation = targetRotation.eulerAngles.y;
    }

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
            targetRotation *= Quaternion.Euler(0, rotationX, 0);
        }

        playerCamera.transform.rotation = Quaternion.Lerp(playerCamera.transform.rotation, targetRotation, Time.deltaTime * 5f);
    }
}





