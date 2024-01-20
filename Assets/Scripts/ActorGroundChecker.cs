using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TT.Core
{
    public class ActorGroundChecker : MonoBehaviour
    {
        public bool IsGrounded { get { return IsGroundedInternal(); } }

        [SerializeField] private CapsuleCollider _collider;
        [SerializeField] private LayerMask _groundLayer;

        private bool IsGroundedInternal()
        {
            Vector3 center = _collider.transform.TransformPoint(_collider.center);
            Vector3 direction = -1 * _collider.transform.up;
            float distance = _collider.height / 2 + 0.1f;
            return Physics.Raycast(center, direction, distance, _groundLayer.value);
        }
    }
}