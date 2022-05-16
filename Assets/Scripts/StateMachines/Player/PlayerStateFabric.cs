public class PlayerStateFabric
{
    private PlayerStateMachine _context;

    private IdleState _idleState;
    private MoveState _moveState;
    private CastState _castState;
    private HitState _hitState;
    private DeadState _deathState;

    public IdleState IdleState { get { return _idleState; } }
    public MoveState MoveState { get { return _moveState; } }
    public CastState CastState { get { return _castState; } }
    public HitState HitState { get { return _hitState; } }
    public DeadState DeathState { get { return _deathState; } }

    public PlayerStateFabric(PlayerStateMachine context)
    {
        this._context = context;

        _idleState = new IdleState(context);
        _moveState = new MoveState(context);
        _castState = new CastState(context);
        _hitState = new HitState(context);
        _deathState = new DeadState(context);
    }
}
