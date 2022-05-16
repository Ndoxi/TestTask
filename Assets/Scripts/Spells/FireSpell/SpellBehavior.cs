using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpellBehavior : MonoBehaviour
{
    [Header("Spell script manager")]
    [SerializeField] private FireSpellScriptManager _spellScriptManager;

    private int _spellDamage;


    private void Start()
    {
        _spellDamage = _spellScriptManager.Projectile.SpellStats.baseDamage;
    }


    public void DealDamageToEnemy(GameObject enemyGameObject)
    {
        EnemyHealthScript healthScript = enemyGameObject.GetComponent<EnemyScriptManager>().HealthScript;
        healthScript.TakeDamage(_spellDamage);
    }
}
