using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanZoom : MonoBehaviour
{
    Vector3 touchStart;
    public float zoomOutMin = 1;
    public float zoomOutMax = 120;
    public float cameraSpeed = 0;
    public Camera playerCamera;

    // Update is called once per frame

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = playerCamera.ScreenToWorldPoint(Input.mousePosition);
        }
        //if (Input.touchCount == 2)
        //{
        //    Touch touchZero = Input.GetTouch(0);
        //    Touch touchOne = Input.GetTouch(1);

        //    Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
        //    Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

        //    float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
        //    float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

        //    float difference = currentMagnitude - prevMagnitude * cameraSpeed * Time.deltaTime;


        //    zoom(difference * 0.01f);
        //}
        else if (Input.GetMouseButton(0))
        {
            Vector3 direction = touchStart - playerCamera.ScreenToWorldPoint(Input.mousePosition);
            playerCamera.transform.position += direction;
        }
        //zoom(Input.GetAxis("Mouse ScrollWheel"));

        playerCamera.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * cameraSpeed;
        playerCamera.orthographicSize = Mathf.Clamp(playerCamera.orthographicSize - Input.GetAxis("Mouse ScrollWheel"), zoomOutMin, zoomOutMax);
    }

    //void zoom(float increment)
    //{
    //    Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
    //}
}