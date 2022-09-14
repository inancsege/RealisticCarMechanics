using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCarController2: MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float _steerinAngle;

    public WheelCollider frontDriverW, frontPassengerW, rearDriverW, rearPassengerW;
    public Transform frontDriverT, frontPassengerT, rearDriverT, rearPassengerT;
    public float maxSteerAngle = 30f;
    public float motorForce = 50f;

    public void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    private void Steer()
    {
        _steerinAngle = maxSteerAngle * horizontalInput;
        frontDriverW.steerAngle = _steerinAngle;
        frontPassengerW.steerAngle = _steerinAngle;
    }

    private void Accelerate()
    {
        frontDriverW.motorTorque = verticalInput * motorForce;
        frontPassengerW.motorTorque = verticalInput * motorForce;
    }

    private void UpdateWheelPoses()
    {
        UpdateWheelPose(frontDriverW,frontDriverT);
        UpdateWheelPose(frontPassengerW,frontPassengerT);
        UpdateWheelPose(rearDriverW, rearDriverT);
        UpdateWheelPose(rearPassengerW,rearPassengerT);
    }

    private void UpdateWheelPose(WheelCollider _collider, Transform _transform)
    {
        Vector3 _pos = _transform.position;
        Quaternion _quat = _transform.rotation;
        
        _collider.GetWorldPose(out _pos,out _quat);

        _transform.position = _pos;
        _transform.rotation = _quat;
    }

    private void FixedUpdate()
    {
        GetInput();
        Steer();
        Accelerate();
        UpdateWheelPoses();
    }
}
