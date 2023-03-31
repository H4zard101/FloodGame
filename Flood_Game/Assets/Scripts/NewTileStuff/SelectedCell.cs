using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCell : MonoBehaviour
{
    public GameObject selectedCell;
    public GameObject HighlightVisual;
    public GameObject BuildUI;
    public GameObject BuildObjects;

    public bool isLand;
    public bool isWater;

    public LayerMask layerMask;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hit, 1000,layerMask))
            {
                selectedCell = hit.collider.gameObject;            
                BuildUI.SetActive(true);
            }
                
        }

        
    }
}
