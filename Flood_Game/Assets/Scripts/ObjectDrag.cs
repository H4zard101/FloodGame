using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDrag : MonoBehaviour
{
    private Vector3 offset;

    private void OnMouseDown()
    {
        offset = transform.position - BuildingSystemV2.GetMouseWorldPosition();
    }
    private void OnMouseDrag()
    {
        Vector3 pos = BuildingSystemV2.GetMouseWorldPosition() + offset;
        transform.position = BuildingSystemV2.current.snapCoordinateToGrid(pos);
        
    }
}
