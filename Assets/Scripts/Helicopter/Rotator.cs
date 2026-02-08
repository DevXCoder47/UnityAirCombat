using Miscellaneous;
using UnityEngine;

namespace Helicopter
{
    public enum RotationAxis
    {
        X,
        Y,
        Z
    }

    public class Rotator : MonoBehaviour
    {
        [SerializeField] private RotationAxis _axis;
        [SerializeField] private float _minSpeed;
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _acceleration;

        private float _currentSpeed;
        private bool _eventRaised = false;

        void Start()
        {
            _currentSpeed = _minSpeed;
        }

        void Update()
        {
            Accelerate();
            Rotate();
            CheckEvent();
        }

        private void Accelerate()
        {
            if (_currentSpeed < _maxSpeed)
            {
                _currentSpeed += _acceleration * Time.deltaTime;
                _currentSpeed = Mathf.Min(_currentSpeed, _maxSpeed);
            }
        }

        private void Rotate()
        {
            Vector3 rotationAxis = _axis switch
            {
                RotationAxis.X => Vector3.right,
                RotationAxis.Y => Vector3.up,
                RotationAxis.Z => Vector3.forward,
                _ => Vector3.up
            };

            transform.Rotate(rotationAxis, _currentSpeed * Time.deltaTime, Space.Self);
        }

        private void CheckEvent()
        {
            if (_currentSpeed >= _maxSpeed && gameObject.CompareTag("MainPropeller") && !_eventRaised)
            {
                EventBus.RaiseMainPropellerReady();
                _eventRaised = true;
            }
        }
    }
}
