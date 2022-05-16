using UnityEngine;
using Spine.Unity;


public class MoveState : BaseState
{
    public MoveState(PlayerStateMachine context) : base(context) { }


    public override void EnterState()
    {
        AnimationReferenceAsset animation = _context.ScriptManager.AnimationController.MoveAnimation;
        _context.ScriptManager.AnimationController.PlayAnimation(animation, true, 1.6f);
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

        if (_context.ScriptManager.PlayerMovement.IsMoving() == false)
        {
            BaseState newState = _context.ScriptManager.StateMachine.IdleState;
            _context.ScriptManager.StateMachine.SetNewState(newState);
        }

        if (_context.ScriptManager.InputHandler.IsAttacking && _context.ScriptManager.Combat.InCooldown == false)
        {
            BaseState newState = _context.ScriptManager.StateMachine.CastState;
            _context.ScriptManager.StateMachine.SetNewState(newState);
        }
        //TRANSITIONS

        _context.ScriptManager.Visuals.UpdateRotation(_context.ScriptManager.PlayerMovement.Rigidbody.velocity.x);
    }


    public override void FixedUpdateState()
    {
        _context.ScriptManager.PlayerMovement.MovePlayer();    
    }


    public override void ExitState()
    {
        _context.ScriptManager.PlayerMovement.ResetVelocity();
    }
}
