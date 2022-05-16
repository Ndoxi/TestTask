using UnityEngine;
using Spine.Unity;


public class CastState : BaseState
{
    public CastState(PlayerStateMachine context) : base(context) { }

    private Spine.TrackEntry _trackEntry;
    private float _animationHalfTime;
    private bool _isPerformed = false;

    public override void EnterState()
    {
        _isPerformed = false;

        AnimationReferenceAsset animation = _context.ScriptManager.AnimationController.CastAnimation;
        _context.ScriptManager.Combat.PrepareSpell();
        _trackEntry =_context.ScriptManager.AnimationController.PlayAnimation(animation, false, 1.5f);
        _animationHalfTime = _trackEntry.Animation.Duration / 2;

        _trackEntry.Complete += OnExitCastState;
    }


    public override void ExitState()
    {
        _context.ScriptManager.InputHandler.IsAttacking = false;
        _trackEntry.Complete -= OnExitCastState;
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
        //TRANSITIONS

        if (_trackEntry.AnimationTime >= _animationHalfTime && _isPerformed == false)
        {
            _isPerformed = true;
            _context.ScriptManager.Combat.PrepareSpell();
        }
    }


    private void OnExitCastState(Spine.TrackEntry trackEntry)
    {
        _context.ScriptManager.Combat.FireSpell();

        IdleState idleState = _context.IdleState;
        _context.SetNewState(idleState);
    }
}