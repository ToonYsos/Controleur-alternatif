using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLimits : MonoBehaviour
{
    private float XLimit = 22.15f;   

    void Update()
    {
        if(transform.position.x > XLimit)
        {
            Destroy(gameObject);
        }
    }
}
