using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.XR;

namespace Assets.StartCraft2.Scripts.Drone
{
    public class DroneMoveToBaseState : DroneStateBase
    {
        public DroneMoveToBaseState(DroneController drone, DroneStateMachine stateMachine)
         : base(drone, stateMachine) { }

        public override void OnEnter()
        {
          
            drone.MoveTo(drone.BasePoint.position);
         
        }

        public override void Tick()
        {
           
            if (drone.IsAt(drone.BasePoint.position))
            {
              
                stateMachine.SetState(new DroneDropOffState(drone, stateMachine));
            }
        }
    }
}
