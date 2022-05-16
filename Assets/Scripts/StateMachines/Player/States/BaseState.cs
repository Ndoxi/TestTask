public abstract class BaseState
{
    protected PlayerStateMachine _context;

    public BaseState(PlayerStateMachine context)
    {
        this._context = context;
    }


    public virtual void EnterState() { }
    public virtual void ExitState() { }
    public virtual void FixedUpdateState() { }

    public abstract void UpdateState();
}