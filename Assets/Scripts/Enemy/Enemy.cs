using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class Enemy : Entity
{
    [Header("Attack Info")] public int damage;
    public float attackRange;
    public Transform target;
    public Transform attackPoint;

    public EntityStateMachine StateMachine;
    public EnemyIdleState IdleState;
    public EnemyRunState RunState;
    public EnemyAttackState AttackState;
    public EnemyDieState DieState;

    protected override void Awake()
    {
        base.Awake();

        StateMachine = new EntityStateMachine();

        IdleState = new EnemyIdleState(StateMachine, this, "Idle");
        RunState = new EnemyRunState(StateMachine, this, "Run");
        AttackState = new EnemyAttackState(StateMachine, this, "Attack");
        DieState = new EnemyDieState(StateMachine, this, "Die");
    }

    protected override void Start()
    {
        base.Start();

        StateMachine.Initialize(IdleState);
    }

    protected override void Update()
    {
        base.Update();

        if(Input.GetKeyDown(KeyCode.W))
        {
            StateMachine.ChangeState(RunState);
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            StateMachine.ChangeState(IdleState);
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            StateMachine.ChangeState(AttackState);
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            StateMachine.ChangeState(DieState);
        }
    }
}