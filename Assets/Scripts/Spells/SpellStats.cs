using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Spells/SpellStats")]
public class SpellStats : ScriptableObject
{
    public float speed;
    public int baseDamage;
    public float cooldown;
}
