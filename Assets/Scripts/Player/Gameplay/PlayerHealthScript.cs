using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHealthScript : MonoBehaviour
{
    [Header("Enemy script manager")]
    [SerializeField] private PlayerScriptManager _scriptManager;

    private int _maxHealth;
    private int _currentHealth;
    private bool _isPlayerGetHit = false;

    public bool IsPlayerGetHit { 
        get { return _isPlayerGetHit; } 
        set { _isPlayerGetHit = value; } }


    private void Start()
    {
        PlayerStats _enemyStats = _scriptManager.PlayerStatsData.PlayerStats;
        _maxHealth = _enemyStats.maxHealth;
        _currentHealth = _maxHealth;

        UIManager.Instance.SetHealthBar(_maxHealth);
    }


    public void TakeDamage(int damageAmount)
    {
        _isPlayerGetHit = true;
        _currentHealth -= damageAmount;
        UIManager.Instance.SetHealthBarValue(_currentHealth);
    }


    public bool IsDead()
    {
        if (_currentHealth <= 0) { return true; }
        return false;
    }
}