using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public float degreesPerSecond;
    public float m_Thrust = 20f;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _rigidbody.AddForce(transform.forward * m_Thrust);
        }
        if (Input.GetKey(KeyCode.S))
        { 
            _rigidbody.AddForce(-1 * transform.forward * m_Thrust);
        }
        if (Input.GetKey(KeyCode.A)) 
        { 
            transform.Rotate(new Vector3(0, -degreesPerSecond, 0) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, degreesPerSecond, 0) * Time.deltaTime);
        }
    }
}

