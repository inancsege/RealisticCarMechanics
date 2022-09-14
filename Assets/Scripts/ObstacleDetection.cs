using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDetection : MonoBehaviour
{
    public SimpleCarFollowing objectReference;
    public float range = 100f;
    public float breakNewton = 300f;
    public LayerMask layer;

    
    private float initmotorforce;
    private Vector3 _forward;

    private void Start()
    {
        initmotorforce = objectReference.GetComponent<SimpleCarFollowing>().motorForce;
    }

    private void Update()
    {
        
        _forward = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, _forward, range,layer))
        {
            
            Debug.Log(objectReference.GetComponent<SimpleCarFollowing>().motorForce);
            /*objectReference.GetComponent<SimpleCarFollowing>().motorForce = 0f;
            objectReference.GetComponent<SimpleCarFollowing>().frontDriverW.brakeTorque = breakNewton;
            objectReference.GetComponent<SimpleCarFollowing>().frontPassengerW.brakeTorque = breakNewton;*/
        }
        else
        {
            objectReference.GetComponent<SimpleCarFollowing>().frontDriverW.brakeTorque = 0f;
            objectReference.GetComponent<SimpleCarFollowing>().frontPassengerW.brakeTorque = 0f;
            objectReference.GetComponent<SimpleCarFollowing>().motorForce = initmotorforce;
        }
    }
}
