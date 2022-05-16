using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class GoblinStateMachine : MonoBehaviour
{
    [Header("Script manager")]
    [SerializeField] private EnemyScriptManager _scriptManager;

    protected GoblinBaseState _idleState;
    protected GoblinBaseState _chaseState;
    protected GoblinBaseState _attackState;
    protected GoblinBaseState _deathState;
    protected GoblinBaseState _waitState;

    protected GoblinBaseState _currentState;
    
    public EnemyScriptManager ScriptManager { get { return _scriptManager; } }
    public GoblinBaseState IdleState { get { return _idleState; } }
    public GoblinBaseState ChaseState { get { return _chaseState; } }
    public GoblinBaseState AttackState { get { return _attackState; } }
    public GoblinBaseState DeathState { get { return _deathState; } }
    public GoblinBaseState WaitState { get { return _waitState; } }

    protected void Start()
    {
        OnStart();
    }


    protected void Update()
    {
        _currentState.UpdateState();
    }


    protected abstract void OnStart();


    public void SetNewState(GoblinBaseState newState)
    {
        if (_currentState.Equals(newState)) { return; }

        _currentState.ExitState();
        _currentState = newState;
        newState.EnterState();
    }
}