using Miscellaneous;
using UnityEngine;

namespace Helicopter
{
    public class HeliMovementController : MonoBehaviour
    {
        [Header("Speed")]
        [SerializeField] private float _rollSpeed;
        [SerializeField] private float _pitchSpeed;
        [SerializeField] private float _verticalSpeed;
        [SerializeField] private float _gorizontalSpeed;
        [SerializeField] private float _yawSpeed;

        [Header("Angles")]
        [SerializeField] private float _pitchAngle;
        [SerializeField] private float _rollAngle;

        private bool _movementLocked = true;

        private void OnEnable()
        {
            EventBus.OnMainPropellerReady += UnlockMovement;
        }

        private void OnDisable()
        {
            EventBus.OnMainPropellerReady -= UnlockMovement;
        }

        private void UnlockMovement()
        {
            _movementLocked = false;
            Debug.Log("Movement unlocked");
        }

        void Update()
        {
            if (_movementLocked)
                return;

            MoveUp();
            MoveDown();

            PitchUp();
            PitchDown();
            RollLeft();
            RollRight();

            if (!IsTiltInputActive())
            {
                YawLeft();
                YawRight();
            }
        }

        private void MoveUp()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                transform.Translate(Vector3.up * _verticalSpeed * Time.deltaTime, Space.Self);
            }
        }

        private void MoveDown()
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                transform.Translate(Vector3.down * _verticalSpeed * Time.deltaTime, Space.Self);
            }
        }

        private void YawLeft()
        {
            if (Input.GetKey(KeyCode.Q))
            {
                transform.Rotate(Vector3.up * -_yawSpeed * Time.deltaTime, Space.Self);
            }
        }

        private void YawRight()
        {
            if (Input.GetKey(KeyCode.E))
            {
                transform.Rotate(Vector3.up * _yawSpeed * Time.deltaTime, Space.Self);
            }
        }

        private void PitchUp()
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                float pitch = GetPitch();

                if (pitch > -_pitchAngle)
                {
                    float delta = -_pitchSpeed * Time.deltaTime;
                    transform.Rotate(Vector3.right * delta, Space.Self);
                }
                else
                {
                    Vector3 flatForward = transform.forward;
                    flatForward.y = 0f;
                    flatForward.Normalize();

                    transform.position -= flatForward * _gorizontalSpeed * Time.deltaTime;
                }
            }
            else
            {
                float pitch = GetPitch();
                if (pitch < 0f)
                {
                    float delta = _pitchSpeed * Time.deltaTime;
                    transform.Rotate(Vector3.right * delta, Space.Self);
                }
            }
        }

        private void PitchDown()
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                float pitch = GetPitch();

                if (pitch < _pitchAngle)
                {
                    float delta = _pitchSpeed * Time.deltaTime;
                    transform.Rotate(Vector3.right * delta, Space.Self);
                }
                else
                {
                    Vector3 flatForward = transform.forward;
                    flatForward.y = 0f;
                    flatForward.Normalize();

                    transform.position += flatForward * _gorizontalSpeed * Time.deltaTime;
                }
            }
            else
            {
                float pitch = GetPitch();
                if (pitch > 0f)
                {
                    float delta = -_pitchSpeed * Time.deltaTime;
                    transform.Rotate(Vector3.right * delta, Space.Self);
                }
            }
        }

        private void RollLeft()
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                float roll = GetRoll();

                if (roll < _rollAngle)
                {
                    float delta = _rollSpeed * Time.deltaTime;
                    transform.Rotate(Vector3.forward * delta, Space.Self);
                }
                else
                {
                    Vector3 flatRight = transform.right;
                    flatRight.y = 0f;
                    flatRight.Normalize();

                    transform.position -= flatRight * _gorizontalSpeed * Time.deltaTime;
                }
            }
            else
            {
                float roll = GetRoll();
                if (roll > 0f)
                {
                    float delta = -_rollSpeed * Time.deltaTime;
                    transform.Rotate(Vector3.forward * delta, Space.Self);
                }
            }
        }

        private void RollRight()
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                float roll = GetRoll();

                if (roll > -_rollAngle)
                {
                    float delta = -_rollSpeed * Time.deltaTime;
                    transform.Rotate(Vector3.forward * delta, Space.Self);
                }
                else
                {
                    Vector3 flatRight = transform.right;
                    flatRight.y = 0f;
                    flatRight.Normalize();

                    transform.position += flatRight * _gorizontalSpeed * Time.deltaTime;
                }
            }
            else
            {
                float roll = GetRoll();
                if (roll < 0f)
                {
                    float delta = _rollSpeed * Time.deltaTime;
                    transform.Rotate(Vector3.forward * delta, Space.Self);
                }
            }
        }

        private float GetPitch()
        {
            float pitch = transform.localEulerAngles.x;
            if (pitch > 180f)
                pitch -= 360f;
            return pitch;
        }

        private float GetRoll()
        {
            float roll = transform.localEulerAngles.z;
            if (roll > 180f)
                roll -= 360f;
            return roll;
        }

        private bool IsTiltInputActive()
        {
            return Input.GetKey(KeyCode.UpArrow)
                || Input.GetKey(KeyCode.DownArrow)
                || Input.GetKey(KeyCode.LeftArrow)
                || Input.GetKey(KeyCode.RightArrow);
        }
    }
}
