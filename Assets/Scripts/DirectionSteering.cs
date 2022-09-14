using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DirectionSteering : MonoBehaviour
{
    public GameObject carItself;
    public LayerMask layer;
    public GameObject prefab;
    public PointSpawn listofTheObjects;
    public SimpleCarFollowing dodgePoint;
    public GameObject spawner;
    
    private PointSpawn _listToDerive;
    private Vector3 _forwardOfTheVehicle;
    private RaycastHit _hit;
    private List<Vector3> vertexPoints;
    private Vector3 myVector;
    private int _maxDistanceVector = 0;
    private bool flag;
    
    
    private void Start()
    {
        vertexPoints = new List<Vector3>();
        _forwardOfTheVehicle = carItself.transform.TransformDirection(Vector3.forward);
        myVector = new Vector3(10f, 0f, 10f);
        flag = false;
        //_hit.collider.gameObject= gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Physics.Raycast(carItself.transform.position,_forwardOfTheVehicle, out _hit, 30f, layer))
        {
            
            InıtiatePoints();
            float distance = 0;
            var getCollisionPoint = _hit.collider.ClosestPointOnBounds(myVector);

            for (var i = 0; i < vertexPoints.Count; i++)
                if (i == 0)
                {
                    distance = Vector3.Distance(getCollisionPoint, vertexPoints[i]);
                    _maxDistanceVector = 0;
                }
                else
                {
                    var newDistance = Vector3.Distance(getCollisionPoint, vertexPoints[i]);
                    if (!(distance < newDistance)) continue;
                    distance = newDistance;
                    _maxDistanceVector = i;
                }

            if (flag == false)
            {
                vertexPoints[_maxDistanceVector] += myVector;
                prefab = Instantiate(prefab,vertexPoints[_maxDistanceVector],Quaternion.identity,spawner.transform);
                listofTheObjects.gameObject.GetComponent<PointSpawn>().spawnedObjectList.Insert(0,prefab);
                dodgePoint.gameObject.GetComponent<SimpleCarFollowing>().carToFollow = listofTheObjects.gameObject
                    .GetComponent<PointSpawn>().spawnedObjectList.First();
                
                flag = true;
            }
            
        }
    }

    private void InıtiatePoints()
    {
        vertexPoints.Add(_hit.collider.bounds.max);
        vertexPoints.Add(_hit.collider.bounds.min);
        vertexPoints.Add(new Vector3(_hit.collider.bounds.max.x, _hit.collider.bounds.max.y, _hit.collider.bounds.min.z));
        vertexPoints.Add(new Vector3(_hit.collider.bounds.max.x, _hit.collider.bounds.min.y, _hit.collider.bounds.min.z));
        vertexPoints.Add(new Vector3(_hit.collider.bounds.max.x, _hit.collider.bounds.min.y, _hit.collider.bounds.max.z));
        vertexPoints.Add(new Vector3(_hit.collider.bounds.min.x, _hit.collider.bounds.min.y, _hit.collider.bounds.max.z));
        vertexPoints.Add(new Vector3(_hit.collider.bounds.min.x, _hit.collider.bounds.max.y, _hit.collider.bounds.max.z));
        vertexPoints.Add(new Vector3(_hit.collider.bounds.min.x, _hit.collider.bounds.max.y, _hit.collider.bounds.min.z));
    }
}
