using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardState : EntityState
{
    protected Guard guard;

    public GuardState(EntityStateMachine entityStateMachine, Guard guard, string animationName) : base(entityStateMachine, guard, animationName)
    {
        this.guard = guard;
    }
}
