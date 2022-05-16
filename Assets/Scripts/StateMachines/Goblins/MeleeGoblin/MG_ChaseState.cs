using UnityEngine;
using Spine.Unity;


public class MG_ChaseState : GoblinBaseState
{
    public MG_ChaseState(GoblinStateMachine context) : base(context) { }


    public override void EnterState()
    {
        _context.ScriptManager.Movement.IsStoped = false;
        AnimationReferenceAsset animation = _context.ScriptManager.AnimationController.MoveAnimation;
        _context.ScriptManager.AnimationController.PlayAnimation(animation);
    }

    public override void UpdateState()
    {
        //TRANSITIONS
        if (_context.ScriptManager.HealthScript.IsDead())
        {
            GoblinBaseState newState = _context.DeathState;
            _context.SetNewState(newState);
        }

        if (_context.ScriptManager.GoblinBehaviour.InAttackRange())
        {
            GoblinBaseState newState = _context.AttackState;
            _context.SetNewState(newState);
        }
        //TRANSITIONS

        _context.ScriptManager.Movement.MoveGoblin();
    }


    public override void ExitState()
    {
        _context.ScriptManager.Movement.IsStoped = true;
    }
}
