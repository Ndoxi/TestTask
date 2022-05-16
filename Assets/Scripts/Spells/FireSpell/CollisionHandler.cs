using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollisionHandler : MonoBehaviour
{
    [Header("Spell script manager")]
    [SerializeField] private FireSpellScriptManager _spellScriptManager;

    [Header("Prefab")]
    [SerializeField] private GameObject _spellPrefab;

    private string _staticObjectsTag = "StaticObject";
    private string _enemyTag = "Enemy";

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(_enemyTag))
        {
            _spellScriptManager.SpellBehavior.DealDamageToEnemy(collision.gameObject);
            Destroy(_spellPrefab);
            return;
        }

        if (collision.gameObject.CompareTag(_staticObjectsTag))
        {
            Destroy(_spellPrefab);
            return;
        }
    }
}
