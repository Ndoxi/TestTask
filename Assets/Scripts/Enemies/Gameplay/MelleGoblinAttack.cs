using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelleGoblinAttack : Attack
{
    [Header("Attack position offset")]
    [SerializeField] private Vector2 _attackOffset;

    private float _faceDirection;


    private void Start()
    {
        _scriptManager.Triggers.AttackCollider.enabled = false;
    }


    private void OnDrawGizmosSelected()
    {
        GetFaceDirection();
        Vector2 attackPosition = new Vector2(transform.position.x, transform.position.y) + _faceDirection *_attackOffset;
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(attackPosition, _attackRadius);
    }


    private void GetFaceDirection()
    {
        bool isFacingRight = _scriptManager.Visuals.IsFacingRight;

        if (isFacingRight) 
        {
            _faceDirection = 1;
            return;
        }

        _faceDirection = -1;
    }


    public override void PerformAttack()
    {
        GetFaceDirection();
        _scriptManager.Triggers.AttackCollider.offset = new Vector2(_faceDirection * _attackOffset.x, _attackOffset.y);
        _scriptManager.Triggers.AttackCollider.radius = _attackRadius;

        StartCoroutine(AttackCoroutine());
    } 
    

    IEnumerator AttackCoroutine()
    {
        _scriptManager.Triggers.AttackCollider.enabled = true;
        yield return new WaitForFixedUpdate();
        _scriptManager.Triggers.AttackCollider.enabled = false;
    }
}