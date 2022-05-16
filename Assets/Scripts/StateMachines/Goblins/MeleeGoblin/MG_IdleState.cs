using Spine.Unity;


public class MG_IdleState : GoblinBaseState
{
    public MG_IdleState(GoblinStateMachine context) : base(context) { }


    public override void EnterState()
    {
        AnimationReferenceAsset animation = _context.ScriptManager.AnimationController.IdleAnimation;
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

        if (_context.ScriptManager.GoblinBehaviour.InAggroRange() || _context.ScriptManager.HealthScript.GetHit)
        {
            GoblinBaseState newState = _context.ChaseState;
            _context.SetNewState(newState);
        }
        //TRANSITIONS
    }
}