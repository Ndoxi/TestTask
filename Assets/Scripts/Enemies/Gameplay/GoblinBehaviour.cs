using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GoblinBehaviour : MonoBehaviour
{
    [Header("Enemy script manager")]
    [SerializeField] protected EnemyScriptManager _scriptManager;

    [Header("Enemy stats")]
    [SerializeField] private EnemyStats _goblinStats;

    [Header("Arggo range")]
    [SerializeField] private float _aggroRange = 7.5f;

    [Header("Goblin")]
    [SerializeField] private GameObject _goblinGameObject;

    private GameObject _playerGameObject;
    private float _distance;
    private float _attackRange;

    public EnemyStats GoslinStats { get { return _goblinStats; } }
    public float DistanceToPlayer { get { return _distance; } }
    

    private void Start()
    {
        _playerGameObject = SingletonScript.Instance.Player;

        _distance = Vector3.Distance(transform.position, _playerGameObject.transform.position);
        _attackRange =_scriptManager.AttackBehaviour.AttackRadius + 1;
    }


    private void Update()
    {
        _distance = Vector3.Distance(transform.position, _playerGameObject.transform.position);
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _aggroRange);
    }


    public void DestroyGoblin()
    {
        Destroy(_goblinGameObject);
    }


    public bool InAggroRange()
    {
        return _distance <= _aggroRange;
    }


    public bool InAttackRange()
    {
        return _distance <= _attackRange;
    }
}