using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.XR;

namespace Assets.StartCraft2.Scripts.Drone
{
    internal class DroneCollectState : DroneStateBase
    {
        private float timer;

        public DroneCollectState(DroneController drone, DroneStateMachine stateMachine)
            : base(drone, stateMachine) { }

        public override void OnEnter()
        {
            timer = drone.Data.CollectDuration;
            drone.carriedResource = drone.resourceTarget.gameObject;
            drone.resourceTarget.gameObject.SetActive(false);
            drone.EventChannel.OnResourceDropped += OnResourceDropped;
        }

        public override void Tick()
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                
                stateMachine.SetState(new DroneMoveToBaseState(drone, stateMachine));
            }
        }
        private void OnResourceDropped()
        {
            drone.EventChannel.OnResourceDropped -= OnResourceDropped;
        }
    }
}
