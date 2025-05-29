using Assets.StartCraft2.Scripts.Pathfinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;


namespace Assets.StartCraft2.Scripts.Drone
{
    public class DroneController : MonoBehaviour
    {

        public IDroneEventChannel EventChannel => eventChannel;

        [SerializeField] private DroneEventChannel eventChannel;
     

        public Transform BasePoint;
        public DroneDataSO Data;

        [HideInInspector] public GameObject carriedResource;
        [HideInInspector] public Transform resourceTarget;

        private DroneStateMachine stateMachine;
        private Pathfinder.Pathfinder pathFollower;
        private AvoidanceSystem avoidanceSystem;

       
        

        private void Awake()
        {
            pathFollower = GetComponent<Pathfinder.Pathfinder>();
            avoidanceSystem = GetComponent<AvoidanceSystem>();
        }

        private void Start()
        {
            stateMachine = new DroneStateMachine();
            stateMachine.SetState(new DroneIdleState(this, stateMachine));
        }

        private void Update()
        {
            stateMachine.Tick();
            avoidanceSystem?.Tick();
            pathFollower?.Tick();
        }

        public void MoveTo(Vector3 destination)
        {
            pathFollower.SetTarget(destination);
        }

        public bool IsAt(Vector3 position)
        {
            return Vector3.Distance(transform.position, position) < Data.TargetReachThreshold;
        }

        public void DropOffResource()
        {
            carriedResource = null;

            if (EventChannel == null)
            {
                Debug.LogError("EventChannel is NULL!");
                return;
            }

            Debug.Log("Вызов RaiseResourceDropped");
            EventChannel.RaiseResourceDropped();

        }
    }
}
