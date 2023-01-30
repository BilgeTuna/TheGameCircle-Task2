using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3f;

    void Start()
    {
        
    }


    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
    }
}
