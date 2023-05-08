using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    public void OnParticleCollision(GameObject other)
    {
        
        other.GetComponent<Cell>().CurrentWaterLevel += 0.05f;
    }

}
