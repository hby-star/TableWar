using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class Enemy : Entity
{
    [Header("Attack Info")]
    public float interceptRange;
    public float attackRange;
    [NonSerialized] public Vector3 Target = Vector3.zero;
    [NonSerialized] public Guard guard = null;

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

        navMeshAgent.stoppingDistance = attackRange;
    }

    protected override void Start()
    {
        base.Start();

        StateMachine.Initialize(IdleState);
    }

    protected override void Update()
    {
        base.Update();

        StateMachine.CurrentState.Update();

        if(stats.currentHealth <= 0)
        {
            StateMachine.ChangeState(DieState);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, interceptRange);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }


    public void Die()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    public void AnimationFinished()
    {
        StateMachine.CurrentState.AnimationFinished();
    }
}