using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardAttackState : GuardState
{
    public GuardAttackState(EntityStateMachine entityStateMachine, Guard guard, string animationName) : base(
        entityStateMachine, guard, animationName)
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

        if (IsAnimationFinished())
        {
            if (guard.attackTarget)
            {
                guard.attackTarget.stats.TakeDamage(guard.stats.damage);
            }

            guard.StateMachine.ChangeState(guard.RunState);
        }
    }
}