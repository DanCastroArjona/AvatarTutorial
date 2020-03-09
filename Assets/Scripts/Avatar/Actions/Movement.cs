using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AvatarTutorial.Player
{
    public class Movement : StateAction
    {
        #region Variables
        private PlayerManager _playerManager;
        private Vector3 _scaleVector = new Vector3(1f,0f,1f);
        #endregion

        public Movement(PlayerManager playerManager)
        {
            _playerManager = playerManager;
        }

        public override void Execute()
        {
            JoystickControl();
        }

        private void JoystickControl()
        {
            _playerManager.moveAmount = Mathf.Clamp01(Mathf.Abs(_playerManager.horizontal) + Mathf.Abs(_playerManager.vertical));
            Vector3 camForward = Vector3.Scale(Camera.main.transform.forward, _scaleVector).normalized;

            _playerManager.moveDirection = (_playerManager.vertical * camForward)
                + (_playerManager.horizontal * Camera.main.transform.right);
            _playerManager.moveDirection.Normalize();

            if (_playerManager.moveAmount > 0.1f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(_playerManager.moveDirection);
                _playerManager.myTransform.rotation = Quaternion.Slerp(_playerManager.myTransform.rotation, targetRotation,
                    Time.deltaTime * _playerManager.rotationSpeedCamOriented);
            }

            Vector3 forward = _playerManager.myTransform.forward * _playerManager.moveAmount * _playerManager.movementSpeed;
            _playerManager.myRigidbody.velocity = forward;
        }
    }
}