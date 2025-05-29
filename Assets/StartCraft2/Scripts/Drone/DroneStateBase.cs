using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.StartCraft2.Scripts.Drone
{
    public  abstract class DroneStateBase : IDroneBehavior
    {
        protected DroneController drone;
        protected DroneStateMachine stateMachine;

        protected DroneStateBase(DroneController drone, DroneStateMachine stateMachine)
        {
            this.drone = drone;
            this.stateMachine = stateMachine;
        }

        public virtual void OnEnter() { }
        public virtual void OnExit() { }
        public abstract void Tick();
    }
}
