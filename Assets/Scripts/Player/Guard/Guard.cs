using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : Entity
{
    public EntityStateMachine StateMachine;
    public GuardIdleState IdleState;
    public GuardRunState RunState;
    public GuardDieState DieState;
    public GuardAttackState AttackState;

    public Transform initialPosition;
    public float PartrolRadius;
    public float AttackRange;
    public Enemy attackTarget = null;

    protected override void Awake()
    {
        base.Awake();

        initialPosition = transform;

        StateMachine = new EntityStateMachine();

        IdleState = new GuardIdleState(StateMachine, this, "Idle");
        RunState = new GuardRunState(StateMachine, this, "Run");
        AttackState = new GuardAttackState(StateMachine, this, "Attack");
        DieState = new GuardDieState(StateMachine, this, "Die");

        navMeshAgent.stoppingDistance = AttackRange;
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

        if(!attackTarget)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, PartrolRadius);
            foreach (var collider in colliders)
            {
                if (collider.CompareTag("Enemy"))
                {
                    Enemy enemy = collider.GetComponent<Enemy>();
                    if (enemy.guard == null)
                    {
                        enemy.guard = this;
                        attackTarget = enemy;
                    }
                }
            }
        }

        if(stats.currentHealth <= 0)
        {
            StateMachine.ChangeState(DieState);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, PartrolRadius);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, AttackRange);
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
