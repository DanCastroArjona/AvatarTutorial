using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AvatarTutorial
{
    public class State
    {
        private List<StateAction> _updateActions;

        public State(List<StateAction> actions)
        {
            _updateActions = actions;
        }

        public void UpdateActionList()
        {
            ExecuteActionList(_updateActions);
        }

        private void ExecuteActionList(List<StateAction> list)
        {
            foreach (StateAction i in list)
            {
                i.Execute();
            }
        }
    }
}