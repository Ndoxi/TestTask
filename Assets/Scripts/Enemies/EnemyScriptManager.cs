using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyScriptManager : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private Movement _enemyMovement;

    [Header("Behovior")]
    [SerializeField] private GoblinBehaviour _goblinBehaviour;

    [Header("Animation Controller")]
    [SerializeField] private AnimationController _animationController;

    [Header("Visuals controller")]
    [SerializeField] private VisualsController _visualsController;

    [Header("Attack behaviour")]
    [SerializeField] private Attack _attackBehaviour;

    [Header("Colliders and triggers script")]
    [SerializeField] private Triggers _triggers;

    [Header("Health script")]
    [SerializeField] private EnemyHealthScript _healthScript;

    public Movement Movement { get { return _enemyMovement; } }
    public GoblinBehaviour GoblinBehaviour { get { return _goblinBehaviour; } }
    public AnimationController AnimationController { get { return _animationController; } }
    public VisualsController Visuals { get { return _visualsController; } }
    public Attack AttackBehaviour { get { return _attackBehaviour; } }
    public Triggers Triggers { get { return _triggers; } }
    public EnemyHealthScript HealthScript { get { return _healthScript; } }
}