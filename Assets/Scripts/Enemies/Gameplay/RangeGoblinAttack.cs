using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeGoblinAttack : Attack
{
    [Header("Prijectile prefab")]
    [SerializeField] private GameObject _spellPrefab;

    private GameObject _player;


    private void Start()
    {
        _player = SingletonScript.Instance.Player;
    }


    private void OnDrawGizmosSelected()
    {
        Vector2 attackPosition = new Vector2(transform.position.x, transform.position.y);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(attackPosition, _attackRadius);
    }


    public override void PerformAttack()
    {
        Vector2 shootPosition = _player.transform.position;
        Vector2 currentPos = new Vector2(transform.position.x, transform.position.y);
        Vector2 firePosition = (shootPosition - currentPos).normalized;

        Quaternion spellRotation = Quaternion.FromToRotation(transform.right, firePosition);

        GameObject spellGameObject = Instantiate(_spellPrefab, transform.position, spellRotation);

        spellGameObject.GetComponent<RockSpellScriptManager>().Projectile.Setup(firePosition);
    }
}
