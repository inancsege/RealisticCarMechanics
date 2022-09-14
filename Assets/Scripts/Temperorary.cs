using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temperorary : MonoBehaviour
{
    public GameObject prefab;
    public GameObject car;
    public List<Vector3> vertexPoints;
    public Vector3 myVector;
    public PointSpawn listOfElements;

    private BoxCollider boxCollider;
    private int maxDistanceVector = 0;
    void Start ()
    {
        //listOfElements.GetComponent<PointSpawn>().spawnedObjectList;
        myVector = new Vector3(10f, 0f, 0f);
        vertexPoints = new List<Vector3>();
        boxCollider = gameObject.GetComponent<BoxCollider>();
        Calculate();
        vertexPoints[maxDistanceVector] += myVector;
        Instantiate(prefab,vertexPoints[maxDistanceVector],Quaternion.identity);
        //listOfElements.GetComponent<PointSpawn>().spawnedObjectList.Insert(0,prefab);
        
    }
    private void Calculate()
    {
        vertexPoints.Add(boxCollider.bounds.max);
        vertexPoints.Add(boxCollider.bounds.min);
        vertexPoints.Add(new Vector3(boxCollider.bounds.max.x, boxCollider.bounds.max.y, boxCollider.bounds.min.z));
        vertexPoints.Add(new Vector3(boxCollider.bounds.max.x, boxCollider.bounds.min.y, boxCollider.bounds.min.z));
        vertexPoints.Add(new Vector3(boxCollider.bounds.max.x, boxCollider.bounds.min.y, boxCollider.bounds.max.z));
        vertexPoints.Add(new Vector3(boxCollider.bounds.min.x, boxCollider.bounds.min.y, boxCollider.bounds.max.z));
        vertexPoints.Add(new Vector3(boxCollider.bounds.min.x, boxCollider.bounds.max.y, boxCollider.bounds.max.z));
        vertexPoints.Add(new Vector3(boxCollider.bounds.min.x, boxCollider.bounds.max.y, boxCollider.bounds.min.z));

        float distance = 0;
        var getCollisionPoint = boxCollider.ClosestPointOnBounds(myVector);

        for (var i = 0; i < vertexPoints.Count; i++)
            if (i == 0)
            {
                distance = Vector3.Distance(getCollisionPoint, vertexPoints[i]);
                maxDistanceVector = 0;
            }
            else
            {
                var newDistance = Vector3.Distance(getCollisionPoint, vertexPoints[i]);
                if (!(distance < newDistance)) continue;
                distance = newDistance;
                maxDistanceVector = i;
            }
    }
}
