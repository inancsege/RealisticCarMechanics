using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementAddForce : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public float m_Thrust = 20f;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _rigidbody.AddForce(Vector3.forward * m_Thrust);
        }
        if (Input.GetKey(KeyCode.S))
        { 
            _rigidbody.AddForce(-1 * Vector3.forward * m_Thrust);
        }
        if (Input.GetKey(KeyCode.A)) 
        { 
            _rigidbody.AddForce(-1 * transform.right * m_Thrust);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _rigidbody.AddForce(transform.right * m_Thrust);
        }
    }
}
