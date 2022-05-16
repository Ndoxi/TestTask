using UnityEngine;
using Spine.Unity;
using System;


public class DeadState : BaseState
{
    public static event PlayerEventManager.PlayerDied EnteredDeathState;

    public DeadState(PlayerStateMachine context) : base(context) { }


    public override void EnterState()
    {
        EnteredDeathState?.Invoke();

        AnimationReferenceAsset animation = _context.ScriptManager.AnimationController.DeathAnimation;
        _context.ScriptManager.AnimationController.PlayAnimation(animation, false, 1);
    }


    public override void UpdateState()
    {
    }
}