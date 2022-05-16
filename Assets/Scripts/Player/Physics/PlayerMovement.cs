using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [Header("Player script manager")]
    [SerializeField] private PlayerScriptManager _playerScriptManager;

    [Header("Character controller")]
    [SerializeField] private Rigidbody2D _charRigidbody;

    public Rigidbody2D Rigidbody { get { return _charRigidbody; } }


    public void MovePlayer()
    {
        Vector2 velocity = _playerScriptManager.InputHandler.MoveInput * _playerScriptManager.PlayerStatsData.PlayerStats.moveSpeed;
        _charRigidbody.velocity = velocity;
    }


    public void ResetVelocity()
    {
        _charRigidbody.velocity = Vector2.zero;
    }


    public bool IsMoving()
    {
        if (_charRigidbody.velocity == Vector2.zero) { return false; }
        return true;
    }
}