using System;
using UnityEngine;

namespace TT.Core.Chanels
{
    public class InputChanel
    {
        public event Action OnJumpInput;
        public event Action OnDashInput;
        public Vector2 MovementAxis => _movementAxis;

        private Vector2 _movementAxis;

        public void SetMoveInput(Vector2 input) => _movementAxis = input;
        public void InvokeOnJump() => OnJumpInput?.Invoke();
        public void InvokeOnDash() => OnDashInput?.Invoke();
    }
}