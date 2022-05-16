public abstract class GoblinBaseState
{
    public GoblinStateMachine _context;

    public GoblinBaseState(GoblinStateMachine context)
    {
        this._context = context;
    }

    public virtual void EnterState() { }
    public virtual void ExitState() { }

    public abstract void UpdateState();
}
