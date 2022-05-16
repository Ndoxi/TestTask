using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MeleeGoblinGoblinStateFabric
{
    private GoblinStateMachine _context;

    private MG_IdleState MG_IdleState;
    private MG_ChaseState MG_ChaseState;
    private MG_AttackState MG_AttackState;
    private MG_DeathState MG_DeathState;
    private MG_WaitState MG_WaitState;

    public MG_IdleState MeleeGoblinIdleState { get { return MG_IdleState; } }
    public MG_ChaseState MeleeGoblinChaseState { get { return MG_ChaseState; } }
    public MG_AttackState MeleeGoblinAttackState { get { return MG_AttackState; } }
    public MG_DeathState MeleeGoblinDeathState { get { return MG_DeathState; } }
    public MG_WaitState MeleeGoblinWaitState { get { return MG_WaitState; } }

    public MeleeGoblinGoblinStateFabric(GoblinStateMachine context)
    {
        this._context = context;

        MG_IdleState = new MG_IdleState(context);
        MG_ChaseState = new MG_ChaseState(context);
        MG_AttackState = new MG_AttackState(context);
        MG_DeathState = new MG_DeathState(context);
        MG_WaitState = new MG_WaitState(context);
    }
}
