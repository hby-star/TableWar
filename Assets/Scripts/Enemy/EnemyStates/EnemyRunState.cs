using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRunState : EnemyState
{
    public EnemyRunState(EntityStateMachine entityStateMachine, Enemy enemy, string animationName) : base(entityStateMachine, enemy, animationName)
    {
    }

    public override void Enter()
    {
        base.Enter();

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (enemy.Target == Vector3.zero)
        {
            enemy.StateMachine.ChangeState(enemy.IdleState);
        }
        else
        {
            if(enemy.guard)
            {
                float distance = Vector3.Distance(enemy.transform.position, enemy.guard.transform.position);
                if (distance <= enemy.attackRange)
                {
                    enemy.navMeshAgent.SetDestination(enemy.transform.position);
                    enemy.transform.LookAt(enemy.guard.transform);
                    enemy.StateMachine.ChangeState(enemy.AttackState);
                }
                else
                {
                    enemy.navMeshAgent.SetDestination(enemy.guard.transform.position);
                }
            }
            else
            {
                enemy.navMeshAgent.SetDestination(enemy.Target);
            }
        }
    }
}
