using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class HandleInput : MonoBehaviour
{
    [Header("Player script manager")]
    [SerializeField] private PlayerScriptManager _playerScriptManager;

    private Vector2 _moveInput;
    private Vector2 _scrollInput;
    private Vector2 _mousePosition;
    private bool _isAttacking = false;
  
    public Vector2 MoveInput { get { return _moveInput; } }
    public Vector2 ScrollInput { get { return _scrollInput; } }
    public Vector2 MousePosition { get { return _mousePosition; } }
    public bool IsAttacking { get { return _isAttacking; } set { _isAttacking = value; } }


    public void Move(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
    }


    public void Zoom(InputAction.CallbackContext context)
    {
        if (context.performed == false) 
        {
            _scrollInput = Vector2.zero;
            return; 
        }

        _scrollInput = context.ReadValue<Vector2>();
    } 


    public void Attack(InputAction.CallbackContext context)
    {
        if (context.performed == false) { return; }

        _isAttacking = true;
        _mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
    }


    public bool IsMovePerformed()
    {
        if (_moveInput == Vector2.zero) { return false; }
        return true;
    }
}