using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardRunState : GuardState
{
    public GuardRunState(EntityStateMachine entityStateMachine, Guard guard, string animationName) : base(entityStateMachine, guard, animationName)
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

        if (guard.attackTarget)
        {
            float distance = Vector3.Distance(guard.transform.position, guard.attackTarget.transform.position);
            if(distance <= guard.AttackRange)
            {
                guard.navMeshAgent.SetDestination(guard.transform.position);
                guard.transform.LookAt(guard.attackTarget.transform);
                guard.StateMachine.ChangeState(guard.AttackState);
            }
            else
            {
                guard.navMeshAgent.SetDestination(guard.attackTarget.transform.position);
            }

        }
        else
        {
            guard.navMeshAgent.SetDestination(guard.initialPosition.position);

            if (guard.navMeshAgent.remainingDistance <= guard.navMeshAgent.stoppingDistance)
            {
                guard.StateMachine.ChangeState(guard.IdleState);
            }
        }
    }
}
