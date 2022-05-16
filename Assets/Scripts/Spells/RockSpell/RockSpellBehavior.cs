using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpellBehavior : MonoBehaviour
{
    [Header("Spell scritp manager")]
    [SerializeField] private RockSpellScriptManager _scriptManager;

    public void DealDamageToPlayer(GameObject player)
    {
        PlayerScriptManager scriptManager = player.GetComponent<PlayerScriptManager>();
        int damageAmount = _scriptManager.Projectile.SpellStats.baseDamage;

        scriptManager.PlayerHealth.TakeDamage(damageAmount);
    }
}
