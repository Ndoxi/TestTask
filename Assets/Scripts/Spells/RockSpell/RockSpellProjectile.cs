using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpellProjectile : MonoBehaviour
{
    [Header("Spell transform")]
    [SerializeField] private GameObject _parent;

    [Header("Spell stats")]
    [SerializeField] private SpellStats _spellStats;

    private Vector2 _flyDirection;

    public SpellStats SpellStats { get { return _spellStats; } }


    public void Setup(Vector2 flyDirection)
    {
        _flyDirection = flyDirection;
    }


    private void Move()
    {
        float currentXPos = _parent.transform.position.x;
        float currentYPos = _parent.transform.position.y;
        Vector2 newPosition = new Vector2(currentXPos, currentYPos) + _flyDirection * _spellStats.speed * Time.deltaTime;

        _parent.transform.position = newPosition;
    }


    private void Update()
    {
        Move();
    }


    private void Start()
    {
        Destroy(_parent, 1.5f);
    }
}
