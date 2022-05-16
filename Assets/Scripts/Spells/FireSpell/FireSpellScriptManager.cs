using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FireSpellScriptManager : MonoBehaviour
{
    [Header("Projectile script")]
    [SerializeField] private Projectile _projectile;

    [Header("Spell behavior")]
    [SerializeField] private SpellBehavior _spellBehavior;


    public Projectile Projectile { get { return _projectile; } }
    public SpellBehavior SpellBehavior { get { return _spellBehavior; } }
}
