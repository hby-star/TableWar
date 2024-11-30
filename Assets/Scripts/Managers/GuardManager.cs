using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GuardManager : MonoBehaviour
{
    public float guardSpawnTime = 5f;
    private float lastGuardSpawnTime = 0f;
    public GameObject guardPrefab;
    private int guardCount = 0;
    public GameObject[] guards;
    private Vector3 [] guardSpawnPoints;
    private Quaternion guardRotation = Quaternion.identity;

    private void Awake()
    {
        if (transform.childCount > 0)
        {
            guardRotation = transform.GetChild(0).rotation;
        }

        guardCount = transform.childCount;
        guards = new GameObject[guardCount];
        guardSpawnPoints = new Vector3[guardCount];
        for(int i = 0; i < transform.childCount; i++)
        {
            guards[i] = transform.GetChild(i).gameObject;
            guardSpawnPoints[i] = guards[i].transform.position;
        }
    }

    void Update()
    {
        if(Time.time - lastGuardSpawnTime >= guardSpawnTime)
        {
            lastGuardSpawnTime = Time.time;
            for(int i = 0; i < guardCount; i++)
            {
                if(!guards[i])
                {
                    guards[i] = Instantiate(guardPrefab, guardSpawnPoints[i], guardRotation, transform);
                    break;
                }
            }
        }
    }
}
