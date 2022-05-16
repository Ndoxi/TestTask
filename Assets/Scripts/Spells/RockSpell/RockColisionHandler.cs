using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockColisionHandler : MonoBehaviour
{
    [Header("Spell script manager")]
    [SerializeField] private RockSpellScriptManager _spellScriptManager;

    [Header("Prefab")]
    [SerializeField] private GameObject _spellPrefab;

    private string _staticObjectsTag = "StaticObject";
    private string _playerTag = "Player";


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(_playerTag))
        {
            _spellScriptManager.SpellBehavior.DealDamageToPlayer(collision.gameObject);
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
