using Spine.Unity;

public class MG_WaitState : GoblinBaseState
{
    public MG_WaitState(GoblinStateMachine context) : base(context) { }


    public override void EnterState()
    {
        AnimationReferenceAsset animation = _context.ScriptManager.AnimationController.IdleAnimation;
        _context.ScriptManager.AnimationController.PlayAnimation(animation);
    }


    public override void UpdateState()
    {
    }
}
