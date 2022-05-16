using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Triggers : MonoBehaviour
{
    [Header("Enemy script manager")]
    [SerializeField] private EnemyScriptManager _scriptManager;

    [Header("Attack collider")]
    [SerializeField] private CircleCollider2D _attackCollider;

    public CircleCollider2D AttackCollider { get { return _attackCollider; } }

    private bool _hasCollided;


    private void LateUpdate()
    {
        _hasCollided = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (_hasCollided || collision.gameObject.tag.Equals("Player") == false) { return; }

        _hasCollided = true;

        int damageAmount = _scriptManager.GoblinBehaviour.GoslinStats.damage;
        _scriptManager.AttackBehaviour.DealDamageToPlayer(collision.gameObject, damageAmount);
    }
}