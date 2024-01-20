using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TT.Core
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class ActorAction : MonoBehaviour
    {
        protected Animator _animator;
        protected Rigidbody _rigidbody;
        protected ActorGroundChecker _actorGroundChecker;

        protected void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();
            _actorGroundChecker = GetComponent<ActorGroundChecker>();

            if (!_animator)
                Debug.LogWarning("An animator cannot be found. Animations will not be played!");
            if (!_actorGroundChecker)
                Debug.LogWarning("A Ground Checker cannot be found. All validations will be skipped!");
        }

        protected abstract void PerformAction();
    }
}