using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AvatarTutorial
{
    public abstract class StateManager : MonoBehaviour
    {
        #region States
        private State _currentState;
        private Dictionary<string, State> _allStates = new Dictionary<string, State>();
        #endregion

        protected void RegisterState(string id, State state)
        {
            _allStates.Add(id, state);
        }

        protected void UpdateState()
        {
            if (_currentState != null)
                _currentState.UpdateActionList();
        }

        protected abstract void Init();

        private void Start()
        {
            Init();
        }

        public State GetState(string id)
        {
            State value = null;
            _allStates.TryGetValue(id, out value);
            return value;
        }

        public void SetState(string id)
        {
            _currentState = GetState(id);
        }
    }
}