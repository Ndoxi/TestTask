using UnityEngine;
using Spine.Unity;


public class HitState : BaseState
{
    private Spine.TrackEntry _trackEntry;

    public HitState(PlayerStateMachine context) : base(context) { }

    public override void EnterState()
    {
        AnimationReferenceAsset animation = _context.ScriptManager.AnimationController.HitAnimation;
        _trackEntry = _context.ScriptManager.AnimationController.PlayAnimation(animation, false, 0.8f);

        _trackEntry.Complete += OnExitCastState;
    }


    public override void ExitState()
    {
        _context.ScriptManager.PlayerHealth.IsPlayerGetHit = false;
        _trackEntry.Complete -= OnExitCastState; 
    }


    public override void UpdateState()
    {
        if (_context.ScriptManager.PlayerHealth.IsDead())
        {
            BaseState newState = _context.DeathState;
            _context.SetNewState(newState);
        }
    }


    private void OnExitCastState(Spine.TrackEntry trackEntry)
    {
        BaseState idleState = _context.IdleState;
        _context.SetNewState(idleState);
    }
}