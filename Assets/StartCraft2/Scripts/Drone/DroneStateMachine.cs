using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.StartCraft2.Scripts.Drone
{
    public class DroneStateMachine
    {
        private IDroneBehavior currentState;

        public void SetState(IDroneBehavior newState)
        {
            currentState?.OnExit();
            currentState = newState;
            currentState?.OnEnter();
        }

        public void Tick()
        {
            currentState?.Tick();
        }
    }
}
