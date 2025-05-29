using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.XR;

namespace Assets.StartCraft2.Scripts.Drone
{
    public class DroneIdleState : DroneStateBase
    {

        public DroneIdleState(DroneController drone, DroneStateMachine stateMachine)
    : base(drone, stateMachine) { }

        public override void Tick()
        {
            var resource = ResourseSoawner.ResourceManager.Instance?.GetBestAvailableResource(drone.transform.position);

            if (resource != null)
            {
                
                drone.resourceTarget = resource.transform;

                stateMachine.SetState(new DroneMoveToResourceState(drone, stateMachine));
           
            }
            
        }
    }
    }

