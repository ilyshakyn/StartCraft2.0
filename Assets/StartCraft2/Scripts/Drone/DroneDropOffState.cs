using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.XR;

namespace Assets.StartCraft2.Scripts.Drone
{
    public class DroneDropOffState : DroneStateBase
    {
        public DroneDropOffState(DroneController drone, DroneStateMachine stateMachine)
         : base(drone, stateMachine) { }

        public override void OnEnter()
        {
            if (drone.carriedResource != null)
            {
                GameManager.Instance.ResourceDelivered();
                ResourseSoawner.ResourceManager.Instance.RespawnResource(drone.carriedResource);
                drone.carriedResource = null;
                drone.DropOffResource();
            }

        }

        public override void Tick()
        {
            stateMachine.SetState(new DroneIdleState(drone, stateMachine));
        }
    }
}
