using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStateMachine : MonoBehaviour
{
    [Header("Player script manager")]
    [SerializeField] private PlayerScriptManager _scriptManager;

    private BaseState _currentState;
    private PlayerStateFabric _stateFabric;

    private IdleState _idleState;
    private MoveState _moveState;
    private CastState _castState;
    private DeadState _deathState;
    private HitState _hitState;

    public PlayerScriptManager ScriptManager { get { return _scriptManager; } }

    public IdleState IdleState { get { return _idleState; } }
    public MoveState MoveState { get { return _moveState; } }
    public CastState CastState { get { return _castState; } }
    public HitState HitState { get { return _hitState; } }
    public DeadState DeathState { get { return _deathState; } }

    private void Start()
    {
        _stateFabric = new PlayerStateFabric(this);

        _idleState = _stateFabric.IdleState;
        _moveState = _stateFabric.MoveState;
        _castState = _stateFabric.CastState;
        _hitState = _stateFabric.HitState;
        _deathState = _stateFabric.DeathState;

        _currentState = _idleState;
    }


    private void Update()
    {
        _currentState.UpdateState();
    }


    private void FixedUpdate()
    {
        _currentState.FixedUpdateState();
    }


    public void SetNewState(BaseState newState)
    {
        if (_currentState.Equals(newState))
        {
            Debug.LogWarning($"State machine already in {newState}" );
            return; 
        }

        _currentState.ExitState();
        _currentState = newState;
        newState.EnterState();
    }
}
