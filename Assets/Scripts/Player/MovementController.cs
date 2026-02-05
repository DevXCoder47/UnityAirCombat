using UnityEngine;

namespace Player
{
    public class MovementController : MonoBehaviour
    {
        [Header("VFX")]
        [SerializeField] private GameObject _combustion;

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

        void Start()
        {
            _currentSpeed = _averageSpeed;
            if (_combustion != null)
                _combustion.SetActive(false);
        }

        void Update()
        {
            HandleSpeed();
            HandleRotation();
            MoveForward();
        }

        private void HandleSpeed()
        {
            float targetSpeed = _averageSpeed;

            if (Input.GetKey(KeyCode.W))
            {
                targetSpeed = _maxSpeed;
                if (_combustion != null)
                    _combustion.SetActive(true);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                targetSpeed = _minSpeed;
                if (_combustion != null)
                    _combustion.SetActive(false);
            }
            else
            {
                if (_combustion != null)
                    _combustion.SetActive(false);
            }

            _currentSpeed = Mathf.MoveTowards(
                _currentSpeed,
                targetSpeed,
                _acceleration * Time.deltaTime
            );
        }

        private void HandleRotation()
        {
            if (Input.GetKey(KeyCode.A))
                YawLeft();
            if (Input.GetKey(KeyCode.D))
                YawRight();

            if (Input.GetKey(KeyCode.UpArrow))
                PitchDown();
            if (Input.GetKey(KeyCode.DownArrow))
                PitchUp();

            if (Input.GetKey(KeyCode.LeftArrow))
                RollLeft();
            if (Input.GetKey(KeyCode.RightArrow))
                RollRight();
        }

        private void MoveForward()
        {
            transform.position += transform.forward * _currentSpeed * Time.deltaTime;
        }

        private void RollLeft()
        {
            transform.Rotate(Vector3.forward * _rollSpeed * Time.deltaTime, Space.Self);
        }

        private void RollRight()
        {
            transform.Rotate(Vector3.back * _rollSpeed * Time.deltaTime, Space.Self);
        }

        private void PitchUp()
        {
            transform.Rotate(Vector3.left * _pitchSpeed * Time.deltaTime, Space.Self);
        }

        private void PitchDown()
        {
            transform.Rotate(Vector3.right * _pitchSpeed * Time.deltaTime, Space.Self);
        }

        private void YawLeft()
        {
            transform.Rotate(Vector3.down * _yawSpeed * Time.deltaTime, Space.Self);
        }

        private void YawRight() 
        {
            transform.Rotate(Vector3.up * _yawSpeed * Time.deltaTime, Space.Self);
        }
    }
}
