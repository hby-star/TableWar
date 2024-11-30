using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardIdleState : GuardState
{
    public GuardIdleState(EntityStateMachine entityStateMachine, Guard guard, string animationName) : base(entityStateMachine, guard, animationName)
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
            guard.navMeshAgent.stoppingDistance = guard.AttackRange;
            guard.StateMachine.ChangeState(guard.RunState);
        }
        else
        {
            float distance = Vector3.Distance(guard.transform.position, guard.initialPosition.position);
            if (distance <= guard.navMeshAgent.stoppingDistance)
            {
                guard.transform.rotation = guard.initialPosition.rotation;
            }
            else
            {
                guard.navMeshAgent.stoppingDistance = 0.01f;
                guard.navMeshAgent.SetDestination(guard.initialPosition.position);
            }
        }
    }
}
