using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RangeGoblinGoblinStateFabric
{
    private GoblinStateMachine _context;

    private RG_IdleState RG_IdleState;
    private RG_ChaseState RG_ChaseState;
    private RG_AttackState RG_AttackState;
    private RG_DeathState RG_DeathState;

    public RG_IdleState RangeGoblinIdleState { get { return RG_IdleState; } }
    public RG_ChaseState RangeGoblinChaseState { get { return RG_ChaseState; } }
    public RG_AttackState RangeGoblinAttackState { get { return RG_AttackState; } }
    public RG_DeathState RangeGoblinDeathState { get { return RG_DeathState; } }


    public RangeGoblinGoblinStateFabric(GoblinStateMachine context)
    {
        this._context = context;
    }
}
