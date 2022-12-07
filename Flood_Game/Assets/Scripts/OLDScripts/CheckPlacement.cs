using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlacement : MonoBehaviour
{
    BuildSystem buildSystem;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Building")
        {
            buildSystem.canPlace = false;
            Debug.Log("Enter");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Building" && buildSystem.outOfMoney == false)
        {
            buildSystem.canPlace = true;
            Debug.Log("Leave");
        }
    }
    void Start()
    {
        buildSystem = GameObject.Find("BuildManager").GetComponent<BuildSystem>();
    }

}
