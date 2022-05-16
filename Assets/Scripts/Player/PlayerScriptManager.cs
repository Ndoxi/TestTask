using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerScriptManager : MonoBehaviour
{
    [Header("Player state machine")]
    [SerializeField] private PlayerStateMachine _playerStateMachine;

    [Header("Player input")]
    [SerializeField] private HandleInput _inputHandler;

    [Header("Animation controller")]
    [SerializeField] private AnimationController _animationController;

    [Header("Visuals controller")]
    [SerializeField] private VisualsController _visualsController;

    [Header("Player movement")]
    [SerializeField] private PlayerMovement _playerMovement;

    [Header("Combat")]
    [SerializeField] private CombatScript _combatScript;

    [Header("Player stats")]
    [SerializeField] private PlayerStatsData _playerStatsData;

    [Header("Player health script")]
    [SerializeField] private PlayerHealthScript _healthScript;

    public PlayerStateMachine StateMachine { get { return _playerStateMachine; } }
    public HandleInput InputHandler { get { return _inputHandler; } }
    public AnimationController AnimationController { get { return _animationController; } }
    public VisualsController Visuals { get { return _visualsController; } }
    public PlayerMovement PlayerMovement { get { return _playerMovement; } }
    public CombatScript Combat { get { return _combatScript; } }
    public PlayerStatsData PlayerStatsData { get { return _playerStatsData; } }
    public PlayerHealthScript PlayerHealth { get { return _healthScript; } }
}
