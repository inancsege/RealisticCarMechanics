using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PointSpawn : MonoBehaviour
{
    public List<GameObject> spawnedObjectList;
    public GameObject prefab;
    public LayerMask layer;
    public SimpleCarFollowing objectToFollow;
    public GameObject objectToSpawn;
    public GameObject carItself;
    
    private SimpleCarFollowing _pointReference;
    private GameObject objectSpawned;
    private void Start()
    {
        spawnedObjectList = new List<GameObject>();
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = new Ray();
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layer))
            {
                objectSpawned = Instantiate(prefab,hit.point,Quaternion.identity,objectToSpawn.transform);
                spawnedObjectList.Add(objectSpawned);
                objectToFollow.GetComponent<SimpleCarFollowing>().carToFollow = spawnedObjectList.First();
            }
        }
        
        
        
    }
}
