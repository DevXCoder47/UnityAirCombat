using UnityEngine;

namespace NPC
{
    public enum VerticalDirection
    {
        Up,
        Down
    }

    public enum HorizontalDirection
    {
        Left,
        Right
    }

    public enum Movement
    {
        Idle,
        Accelerated,
        Delayed
    }

    public class NPCController : MonoBehaviour
    {
        [Header("VFX")]
        [SerializeField] private GameObject _combustion;

        [Header("Height")]
        [SerializeField] private float _minHeight;

        [Header("Speed")]
        [SerializeField] private float _minSpeed;
        [SerializeField] private float _averageSpeed;
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _acceleration;

        [Header("Rotation")]
        [SerializeField] private float _rollSpeed;
        [SerializeField] private float _pitchSpeed;
        [SerializeField] private float _yawSpeed;

        private float _currentSpeed;
        private float _targetSpeed;
        private StateMachine _fsm;

        public float CurrentHeight => transform.position.y;
        public float MinHeight => _minHeight;

        private void Awake()
        {
            _fsm = new StateMachine();
        }

        private void Start()
        {
            _currentSpeed = _averageSpeed;
            if (_combustion != null)
                _combustion.SetActive(false);

            _fsm.SetState(new MoveState(Movement.Idle, _fsm, this));
        }

        private void Update()
        {
            _fsm.Update();
        }

        public void MoveIdle()
        {
            _targetSpeed = _averageSpeed;
            if (_combustion != null)
                _combustion.SetActive(false);
        }

        public void Accelerate()
        {
            _targetSpeed = _maxSpeed;
            if (_combustion != null)
                _combustion.SetActive(true);
        }

        public void Decelerate()
        {
            _targetSpeed = _minSpeed;
            if (_combustion != null)
                _combustion.SetActive(false);
        }

        public void HandleSpeed()
        {
            _currentSpeed = Mathf.MoveTowards(
                _currentSpeed,
                _targetSpeed,
                _acceleration * Time.deltaTime
            );
        }

        public void MoveForward()
        {
            transform.position += transform.forward * _currentSpeed * Time.deltaTime;
        }

        public void RollLeft()
        {
            transform.Rotate(Vector3.forward * _rollSpeed * Time.deltaTime, Space.Self);
        }

        public void RollRight()
        {
            transform.Rotate(Vector3.back * _rollSpeed * Time.deltaTime, Space.Self);
        }

        public void PitchUp()
        {
            transform.Rotate(Vector3.left * _pitchSpeed * Time.deltaTime, Space.Self);
        }

        public void PitchDown()
        {
            transform.Rotate(Vector3.right * _pitchSpeed * Time.deltaTime, Space.Self);
        }

        public void YawLeft()
        {
            transform.Rotate(Vector3.down * _yawSpeed * Time.deltaTime, Space.Self);
        }

        public void YawRight()
        {
            transform.Rotate(Vector3.up * _yawSpeed * Time.deltaTime, Space.Self);
        }

        public bool IsTooLow()
        {
            return CurrentHeight <= MinHeight;
        }

        public bool IsNearGround()
        {
            return CurrentHeight <= MinHeight + 50f;
        }
    }
}
