using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MeleeGoblinStateMachine : GoblinStateMachine
{
    private MeleeGoblinGoblinStateFabric _stateFabric;

    private void OnEnable()
    {
        DeadState.EnteredDeathState += EnterWaitState;
    }


    private void OnDisable()
    {
        DeadState.EnteredDeathState -= EnterWaitState;
    }


    private void EnterWaitState()
    {
        SetNewState(_waitState);
    }


    protected override void OnStart()
    {
        _stateFabric = new MeleeGoblinGoblinStateFabric(this);

        _idleState = _stateFabric.MeleeGoblinIdleState;
        _chaseState = _stateFabric.MeleeGoblinChaseState;
        _attackState = _stateFabric.MeleeGoblinAttackState;
        _deathState = _stateFabric.MeleeGoblinDeathState;
        _waitState = _stateFabric.MeleeGoblinWaitState;

        _currentState = _idleState;
    }
}