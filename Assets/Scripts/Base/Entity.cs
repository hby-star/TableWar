using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Entity : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Rigidbody rb;
    public Collider col;
    public Animator anim;
    public Stats stats;

    protected virtual void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        anim = GetComponent<Animator>();
        stats = GetComponent<Stats>();
    }

    protected virtual void Start()
    {
    }

    protected virtual void Update()
    {
    }


}