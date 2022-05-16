using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObjects/Enemies/EnemyStats")]
public class EnemyStats : ScriptableObject
{
    public int maxHealth;
    public float speed;
    public int damage;
}
