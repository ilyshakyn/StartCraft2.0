using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.StartCraft2.Scripts.Drone
{
    [CreateAssetMenu(fileName = "DroneData", menuName = "Drones/DroneData")]
    public class DroneDataSO : ScriptableObject, IDroneType
    {

        public bool ShowDronePaths = true;

        [Header("Движение")]
        [SerializeField] float speed = 5f;
        [SerializeField] private float targetReachThreshold = 0.75f;

        [Header("Сбор ресурсов")]
        [SerializeField] private float collectDuration = 2f;

        [Header("Избежание столкновений")]
        [SerializeField] private float avoidanceRadius = 2f;
        [SerializeField] private float avoidanceStrength = 1.5f;

    
        public  float Speed
        {
            get => speed;
            set => speed = value;
        }

        public float CollectDuration => collectDuration;
        public float TargetReachThreshold => targetReachThreshold;
        public float AvoidanceRadius => avoidanceRadius;
        public float AvoidanceStrength => avoidanceStrength;
       
        public void OnResourceCollected()
        {
            Debug.Log("Ресурс собран!");
        }
      
    }
}
