using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AvatarTutorial.Player
{
    public class Inputs : StateAction
    {
        #region Variales
        private PlayerManager _playerManager;
        private float _currentTimeBlock, _delayButton;
        #endregion

        public Inputs(PlayerManager playerManager)
        {
            _playerManager = playerManager;
            _currentTimeBlock = Time.timeSinceLevelLoad;
        }

        public override void Execute()
        {
            _playerManager.horizontal = Input.GetAxis("Horizontal");
            _playerManager.vertical = Input.GetAxis("Vertical");
            _playerManager.interactionButton = Input.GetButtonDown("Interaction");

            if (_currentTimeBlock < Time.timeSinceLevelLoad)
            {
                _playerManager.rightButton = (_playerManager.horizontal > 0f) ? true : false;
                _playerManager.leftButton = (_playerManager.horizontal < 0f) ? true : false;
                _playerManager.upButton = (_playerManager.vertical > 0f) ? true : false;
                _playerManager.downButton = (_playerManager.vertical < 0f) ? true : false;

                if (_playerManager.rightButton || _playerManager.leftButton
                    || _playerManager.upButton || _playerManager.downButton)
                    _currentTimeBlock = Time.timeSinceLevelLoad + _delayButton;
            }
            else
            {
                _playerManager.rightButton = false;
                _playerManager.leftButton = false;
                _playerManager.upButton = false;
                _playerManager.downButton = false;
            }
        }
    }
}