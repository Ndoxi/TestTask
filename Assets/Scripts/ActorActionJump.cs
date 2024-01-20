using System.Collections;
using System.Collections.Generic;
using TT.Core.Chanels;
using UnityEngine;
using Zenject;

namespace TT.Core
{
    public class ActorActionJump : ActorAction
    {
        private const string ANIMATOR_JUMP_KEY = "Jump";

        [SerializeField] private float _jumpForce = 5f;

        private InputChanel _inputChanel;

        [Inject]
        private void Construct(InputChanel inputChanel)
        {
            _inputChanel = inputChanel;
        }

        private void OnEnable()
        {
            _inputChanel.OnJumpInput += PerformAction;
        }

        private void OnDisable()
        {
            _inputChanel.OnJumpInput -= PerformAction;
        }

        protected override void PerformAction()
        {
            if (!_actorGroundChecker || !_actorGroundChecker.IsGrounded)
                return;

            _animator.SetTrigger(ANIMATOR_JUMP_KEY);
            Vector3 force = _rigidbody.transform.up * _jumpForce;
            _rigidbody.AddForce(force, ForceMode.Impulse);
        }
    }
}