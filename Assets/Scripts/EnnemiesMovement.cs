using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiesMovement : MonoBehaviour
{
    public float speed = 2f;
  
    void Update()
    {
        if(gameObject != null)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
    }
}
