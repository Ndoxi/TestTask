using UnityEngine;
using Spine.Unity;


public class MG_AttackState : GoblinBaseState
{
    public MG_AttackState(GoblinStateMachine context) : base(context) { }

    private Spine.TrackEntry _trackEntry;
    private float _animationHalfTime;
    private bool _isPerformed = false;


    public override void EnterState()
    {
        _isPerformed = false;

        AnimationReferenceAsset animation = _context.ScriptManager.AnimationController.CastAnimation;
        _trackEntry = _context.ScriptManager.AnimationController.PlayAnimation(animation, false, 0.75f);
        _animationHalfTime = _trackEntry.Animation.Duration / 2;

        _trackEntry.Complete += OnExitAttackState;
    }


    public override void ExitState()
    {
        _trackEntry.Complete -= OnExitAttackState;
    }


    public override void UpdateState()
    {
        //TRANSITIONS
        if (_context.ScriptManager.HealthScript.IsDead())
        {
            GoblinBaseState newState = _context.DeathState;
            _context.SetNewState(newState);
        }
        //TRANSITIONS

        if (_trackEntry.AnimationTime >= _animationHalfTime && _isPerformed == false)
        {
            _isPerformed = true;
            _context.ScriptManager.AttackBehaviour.PerformAttack();
        }
    }


    private void OnExitAttackState(Spine.TrackEntry trackEntry)
    {
        
        GoblinBaseState newState = _context.ChaseState;
        _context.SetNewState(newState);
    }
}