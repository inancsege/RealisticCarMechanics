using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementVelocity : MonoBehaviour
{ 
    
    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector3(0, 0, 3);
        }
        if (Input.GetKey(KeyCode.S))
        { 
            rb.velocity = new Vector3(0, 0, -3);
        }
        if (Input.GetKey(KeyCode.A)) 
        {
            rb.velocity = new Vector3(-3, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector3(3, 0, 0);
        }
        
    }
}
