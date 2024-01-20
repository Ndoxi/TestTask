using System;
using System.Collections;
using System.Collections.Generic;
using TT.Core.Chanels;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace TT.Core.UI
{
    public class InputReaderUI : MonoBehaviour
    {
        [SerializeField] private Joystick _movementJoystick;
        [SerializeField] private Button _jumpButton;
        [SerializeField] private Button _dashButton;
        private InputChanel _inputChanel;

        [Inject]
        private void Construct(InputChanel inputChanel)
        {
            _inputChanel = inputChanel;
        }

        private void OnEnable()
        {
            _jumpButton.onClick.AddListener(OnJumpInput);
            _dashButton.onClick.AddListener(OnDashInput);
        }

        private void OnDisable()
        {
            _jumpButton.onClick.RemoveListener(OnJumpInput);
            _dashButton.onClick.RemoveListener(OnDashInput);
        }

        private void Update()
        {
            _inputChanel.SetMoveInput(_movementJoystick.Direction);
        }

        private void OnJumpInput() => _inputChanel.InvokeOnJump();
        private void OnDashInput() => _inputChanel.InvokeOnDash();

    }
}