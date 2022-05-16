using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStatsData : MonoBehaviour
{
    [Header("Player script manager")]
    [SerializeField] private PlayerScriptManager _playerScriptManager;

    [Header("Palyer stats")]
    [SerializeField] private PlayerStats _playerStats;

    public PlayerStats PlayerStats { get { return _playerStats; } }
}
