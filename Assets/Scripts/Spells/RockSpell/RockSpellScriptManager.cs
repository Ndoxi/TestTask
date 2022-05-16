using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpellScriptManager : MonoBehaviour
{
    [Header("Spell behavoiur")]
    [SerializeField] private RockSpellBehavior _spellBehaviour;

    [Header("")]
    [SerializeField] private Projectile _projectile;

    public RockSpellBehavior SpellBehavior { get { return _spellBehaviour; } }
    public Projectile Projectile { get { return _projectile; } }
}
