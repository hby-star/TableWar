using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    public EnemyIdleState(EntityStateMachine entityStateMachine, Enemy enemy, string animationName) : base(entityStateMachine, enemy, animationName)
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

        if (enemy.Target != Vector3.zero)
        {
            enemy.StateMachine.ChangeState(enemy.RunState);
        }
    }
}
