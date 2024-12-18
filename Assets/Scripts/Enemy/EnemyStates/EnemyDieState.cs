using System.Collections;
using System.Collections.Generic;
using Unity.VRTemplate;
using UnityEngine;

public class EnemyDieState : EnemyState
{
    public EnemyDieState(EntityStateMachine entityStateMachine, Enemy enemy, string animationName) : base(entityStateMachine, enemy, animationName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        enemy.rb.useGravity = false;
        enemy.rb.velocity = Vector3.zero;
        enemy.rb.angularVelocity = Vector3.zero;
        enemy.col.enabled = false;
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
            enemy.Die();
        }
    }

}
