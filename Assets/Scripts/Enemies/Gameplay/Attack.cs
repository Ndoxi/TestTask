using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Attack : MonoBehaviour
{
    [Header("Enemy script manager")]
    [SerializeField] protected EnemyScriptManager _scriptManager;

    [Header("Attack radius")]
    [SerializeField] protected float _attackRadius;

    public float AttackRadius { get { return _attackRadius; } }


    public abstract void PerformAttack();

    public void DealDamageToPlayer(GameObject player, int damageAmount)
    {
        PlayerScriptManager scriptManager = player.GetComponent<PlayerScriptManager>();
        scriptManager.PlayerHealth.TakeDamage(damageAmount);
    }
}