using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class WayPointControl : MonoBehaviour
{
    public PointSpawn listControl;
    public SimpleCarFollowing pointControl;
    public GameObject despawningTheFirstElement;
    public GameObject wayPoint;

    private void Start()
    {
        listControl.GetComponent<PointSpawn>().spawnedObjectList.Add(wayPoint);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TriggerEnter!!!");
        if (other.gameObject.CompareTag("Waypoint"))
        {
            try
            {
                listControl.GetComponent<PointSpawn>().spawnedObjectList.RemoveAt(0);
                Destroy(despawningTheFirstElement.transform.GetChild(0).gameObject);
                pointControl.GetComponent<SimpleCarFollowing>().carToFollow =
                listControl.GetComponent<PointSpawn>().spawnedObjectList.First();
            }
            catch (Exception e)
            {
                Debug.Log(e);
              
            }
        }
    }
}
