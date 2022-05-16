using Spine.Unity;


public class MG_DeathState : GoblinBaseState
{
    public MG_DeathState(GoblinStateMachine context) : base(context) { }


    public override void EnterState()
    {
        AnimationReferenceAsset animation = _context.ScriptManager.AnimationController.DeathAnimation;
        Spine.TrackEntry trackEntry = _context.ScriptManager.AnimationController.PlayAnimation(animation, false, 1);
        trackEntry.Complete += OnExitDeathState;
    }


    public override void UpdateState()
    {
    }


    private void OnExitDeathState(Spine.TrackEntry trackEntry)
    {
        _context.ScriptManager.GoblinBehaviour.DestroyGoblin();
    }
}
