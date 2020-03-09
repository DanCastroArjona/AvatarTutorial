using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AvatarTutorial.Player
{
    public class Interaction : StateAction
    {
        #region Variables
        private PlayerManager _playerManager;
        #endregion

        public Interaction(PlayerManager playerManager)
        {
            _playerManager = playerManager;
        }

        public override void Execute()
        {
            if (!_playerManager.isInteractionActived && _playerManager.interactionButton)
            {
                //Nueva interacción
                Debug.Log("Interaction");
            }
        }
    }
}