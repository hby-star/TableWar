using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    public EnemyAttackState(EntityStateMachine entityStateMachine, Enemy enemy, string animationName) : base(
        entityStateMachine, enemy, animationName)
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
            if (enemy.guard)
            {
                enemy.guard.stats.TakeDamage(enemy.stats.damage);
            }

            enemy.StateMachine.ChangeState(enemy.RunState);
        }
    }
}