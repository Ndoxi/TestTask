using System.Collections;
using System.Collections.Generic;
using TT.Core.Chanels;
using UnityEngine;
using Zenject;

namespace TT.Core
{
    public class ActorDashAction : ActorAction
    {
        private const string ANIMATOR_DASH_TRIGGER_KEY = "Dash";
        private const string ANIMATOR_DASH_KEY = "Dashing";

        [SerializeField] private float _dashForce = 10f;
        [SerializeField] private float _dashDuration = 0.5f;

        private InputChanel _inputChanel;
        private bool _dashing;

        [Inject]
        private void Construct(InputChanel inputChanel)
        {
            _inputChanel = inputChanel;
        }

        private void OnEnable()
        {
            _inputChanel.OnDashInput += PerformAction;
        }

        private void OnDisable()
        {
            _inputChanel.OnDashInput -= PerformAction;
        }

        protected override void PerformAction()
        {
            if (_dashing)
                return;

            StartCoroutine(nameof(DashCo));
        }

        private IEnumerator DashCo()
        {
            _dashing = true;
            _animator.SetBool(ANIMATOR_DASH_KEY, true);
            _animator.SetTrigger(ANIMATOR_DASH_TRIGGER_KEY);
            float startTime = Time.time;

            while (_dashDuration > Time.time - startTime)
            {
                Vector3 force = _rigidbody.transform.forward * _dashForce;
                _rigidbody.AddForce(force, ForceMode.Impulse);
                yield return new WaitForFixedUpdate();
            }

            _dashing = false;
            _animator.SetBool(ANIMATOR_DASH_KEY, false);
        }
    }
}