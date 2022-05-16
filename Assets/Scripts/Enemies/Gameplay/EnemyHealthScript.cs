using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthScript : MonoBehaviour
{
    [Header("Enemy script manager")]
    [SerializeField] private EnemyScriptManager _scriptManager;

    private int _maxHealth;
    private int _currentHealth;

    private bool _getHit = false;
    public bool GetHit { get { return _getHit; } }


    private void Start()
    {
        EnemyStats _enemyStats = _scriptManager.GoblinBehaviour.GoslinStats;
        _maxHealth = _enemyStats.maxHealth;
        _currentHealth = _maxHealth;
    }


    public void TakeDamage(int damageAmount)
    {
        _getHit = true;
        _currentHealth -= damageAmount;
    }


    public bool IsDead()
    {
        if (_currentHealth <= 0) { return true; }
        return false;
    }
}
