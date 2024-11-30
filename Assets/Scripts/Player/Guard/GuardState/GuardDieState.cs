using System.Collections;
using System.Collections.Generic;
using Unity.VRTemplate;
using UnityEngine;

public class GuardDieState : GuardState
{
    public GuardDieState(EntityStateMachine entityStateMachine, Guard guard, string animationName) : base(entityStateMachine, guard, animationName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        guard.rb.useGravity = false;
        guard.rb.velocity = Vector3.zero;
        guard.rb.angularVelocity = Vector3.zero;
        guard.col.enabled = false;
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
            guard.Die();
        }
    }
}
