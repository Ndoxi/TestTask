using UnityEngine;
using Spine.Unity;


public class IdleState : BaseState
{
    public IdleState(PlayerStateMachine context) : base(context) { }


    public override void EnterState()
    {
        AnimationReferenceAsset animation = _context.ScriptManager.AnimationController.IdleAnimation;
        _context.ScriptManager.AnimationController.PlayAnimation(animation);
    }
    

    public override void UpdateState()
    {
        //TRANSITIONS
        if (_context.ScriptManager.PlayerHealth.IsDead())
        {
            BaseState newState = _context.DeathState;
            _context.SetNewState(newState);
        }

        if (_context.ScriptManager.PlayerHealth.IsPlayerGetHit)
        {
            BaseState newState = _context.HitState;
            _context.SetNewState(newState);
        }

        if (_context.ScriptManager.PlayerMovement.IsMoving())
        {
            BaseState newState = _context.ScriptManager.StateMachine.MoveState;
            _context.ScriptManager.StateMachine.SetNewState(newState);
        }

        if (_context.ScriptManager.InputHandler.IsAttacking && _context.ScriptManager.Combat.InCooldown == false)
        {
            BaseState newState = _context.ScriptManager.StateMachine.CastState;
            _context.ScriptManager.StateMachine.SetNewState(newState);
        }
        //TRANSITIONS
    }


    public override void FixedUpdateState()
    {
        _context.ScriptManager.PlayerMovement.MovePlayer();
    }
}