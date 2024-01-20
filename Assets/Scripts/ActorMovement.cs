using System.Collections;
using System.Collections.Generic;
using TT.Core.Chanels;
using UnityEngine;
using Zenject;

namespace TT.Core
{
    [RequireComponent(typeof(Rigidbody))]
    public class ActorMovement : MonoBehaviour
    {
        private const string ANIMATOR_GROUND_SPEED_KEY = "GroundSpeed";
        private const string ANIMATOR_GROUNDED_KEY = "IsGrounded";

        [SerializeField] private float _runSpeed = 150f;
        [SerializeField] private float _walkSpeed = 50f;

        private Animator _animator;
        private Rigidbody _rigidbody;
        private ActorGroundChecker _actorGroundChecker;
        private InputChanel _inputChanel;
        private Vector3 _previousPos;
        private float _groundSpeed;

        [Inject]
        private void Construct(InputChanel inputChanel)
        {
            _inputChanel = inputChanel;
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();
            _actorGroundChecker = GetComponent<ActorGroundChecker>();

            if (!_animator)
                Debug.LogWarning("An animator cannot be found. Animations will not be played!");
            if (!_actorGroundChecker)
                Debug.LogWarning("A Ground Checker cannot be found. All validations will be skipped!");

            _previousPos = _rigidbody.position;
        }

        private void FixedUpdate()
        {
            ProcessMovement();

            _animator?.SetFloat(ANIMATOR_GROUND_SPEED_KEY, _groundSpeed);
            if (_actorGroundChecker)
            {
                _animator?.SetBool(ANIMATOR_GROUNDED_KEY, _actorGroundChecker.IsGrounded);
            }
        }

        private void ProcessMovement()
        {
            if (!_actorGroundChecker.IsGrounded || _inputChanel.MovementAxis == Vector2.zero)
            {
                _groundSpeed = 0;
                return;
            }

            Vector3 moveDirection = new Vector3(_inputChanel.MovementAxis.x, 0, _inputChanel.MovementAxis.y).normalized;
            Vector3 moveForce;
            if (_inputChanel.MovementAxis.magnitude > 0.4f)
                moveForce = _runSpeed * Time.fixedDeltaTime * moveDirection;
            else
                moveForce = _walkSpeed * Time.fixedDeltaTime * moveDirection;

            Vector3 lookDirection = _rigidbody.position + moveDirection;

            _rigidbody.transform.LookAt(lookDirection, Vector3.up);
            _rigidbody.AddForce(moveForce, ForceMode.VelocityChange);

            _groundSpeed = Vector3.Distance(_rigidbody.position, _previousPos) / Time.fixedDeltaTime;
            _previousPos = _rigidbody.position;
        }
    }
}