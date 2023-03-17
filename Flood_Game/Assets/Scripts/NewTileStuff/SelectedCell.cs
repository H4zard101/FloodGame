using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCell : MonoBehaviour
{
    public GameObject selectedCell;
    public GameObject HighlightVisual;
    public GameObject BuildUI;
    public GameObject BuildObjects;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hit))
            {
                selectedCell = hit.collider.gameObject;
                BuildUI.SetActive(true);
            }
        }

        
    }
}
