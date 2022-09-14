using System;
using Unity.VisualScripting;
using UnityEngine;

public class SimpleCarFollowing : MonoBehaviour
{
    public float accelerateDown = 1f;
    public WheelCollider frontDriverW, frontPassengerW, rearDriverW, rearPassengerW;
    public Transform frontDriverT, frontPassengerT, rearDriverT, rearPassengerT;
    public float maxSteerAngle = 30f;
    public float motorForce = 50f;
    public GameObject carToFollow;
    public float breakTroque = 5000f;
    public float rangeOfTheRay;
    public LayerMask layer;
    
    private float _steerinAngle;
    private Vector3 _forwardOfTheVehicle;
    private Rigidbody rb;
    private RaycastHit hit;
    

    private void FixedUpdate()
    {
        
        //GetInput();
        Steer();
        //Accelerate();
        VehicleControl();
        UpdateWheelPoses();
    }
    private void Start()
    {
        _forwardOfTheVehicle = transform.TransformDirection(Vector3.forward);
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Steer()
    {
        try
        {
            var relativeVector = transform.InverseTransformPoint(carToFollow.transform.position);
            var newSteer = relativeVector.x / relativeVector.magnitude * maxSteerAngle;
            _steerinAngle = newSteer;
            //Debug.Log("Max Steering: " + maxSteerAngle + " Current steering: " + newSteer);
            //Debug.Log(relativeVector.magnitude);                                                                                   
            frontDriverW.steerAngle = _steerinAngle;
            frontPassengerW.steerAngle = _steerinAngle;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
        
        
    }

    private void VehicleControl()
    {
        if (Math.Abs(_steerinAngle) < 5)
        {
            frontDriverW.motorTorque = accelerateDown * motorForce;
            frontPassengerW.motorTorque = accelerateDown * motorForce;
        }
        else if (Math.Abs(_steerinAngle) < 15 && Math.Abs(_steerinAngle) >= 5)
        {
            frontDriverW.motorTorque = accelerateDown * motorForce * 0.75f;
            frontPassengerW.motorTorque = accelerateDown * motorForce * 0.75f;
            if (rb.velocity.magnitude > 3f)
            {
                frontDriverW.brakeTorque = breakTroque * 0.5f;
                frontPassengerW.brakeTorque = breakTroque * 0.5f;
            }
            

        }
        else if (Math.Abs(_steerinAngle) < 30 && Math.Abs(_steerinAngle) >= 15)
        {
            frontDriverW.motorTorque = accelerateDown * motorForce * 0.5f;
            frontPassengerW.motorTorque = accelerateDown * motorForce * 0.5f;
            if (rb.velocity.magnitude > 3f)
            {
                frontDriverW.brakeTorque = breakTroque;
                frontPassengerW.brakeTorque = breakTroque;
            }
            
        }
    }

    /*private void Accelerate()
    {
        frontDriverW.motorTorque = accelerateDown * motorForce;
        frontPassengerW.motorTorque = accelerateDown * motorForce;
    }*/

    private void UpdateWheelPoses()
    {
        UpdateWheelPose(frontDriverW, frontDriverT);
        UpdateWheelPose(frontPassengerW, frontPassengerT);
        UpdateWheelPose(rearDriverW, rearDriverT);
        UpdateWheelPose(rearPassengerW, rearPassengerT);
    }

    private void UpdateWheelPose(WheelCollider _collider, Transform _transform)
    {
        var _pos = _transform.position;
        var _quat = _transform.rotation;

        _collider.GetWorldPose(out _pos, out _quat);

        _transform.position = _pos;
        _transform.rotation = _quat;
    }
}