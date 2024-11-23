using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : EntityState
{
    protected Enemy enemy;

    public EnemyState(EntityStateMachine entityStateMachine, Enemy enemy, string animationName) : base(entityStateMachine, enemy, animationName)
    {
        this.enemy = enemy;
    }
}
