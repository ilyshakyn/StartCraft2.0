using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.XR;

namespace Assets.StartCraft2.Scripts.Drone
{
    public class DroneMoveToResourceState : DroneStateBase
    {
        public DroneMoveToResourceState(DroneController drone, DroneStateMachine stateMachine)
        : base(drone, stateMachine) { }

        public override void OnEnter()
        {
            if (drone.resourceTarget != null)
            {
                drone.MoveTo(drone.resourceTarget.position);
            }
        }

        public override void Tick()
        {
            if (drone.resourceTarget == null || !drone.resourceTarget.gameObject.activeSelf)
            {
               
                stateMachine.SetState(new DroneIdleState(drone, stateMachine)); 
                return;
            }

            if (drone.IsAt(drone.resourceTarget.position))
            {
                stateMachine.SetState(new DroneCollectState(drone, stateMachine));
            }
        }
    }
}
