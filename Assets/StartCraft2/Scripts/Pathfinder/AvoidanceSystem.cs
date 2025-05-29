using Assets.StartCraft2.Scripts.Drone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.StartCraft2.Scripts.Pathfinder
{
    public class AvoidanceSystem : MonoBehaviour
    {
        private DroneController drone;

        private void Awake() => drone = GetComponent<DroneController>();

        public void Tick()
        {
            Vector3 force = Vector3.zero;
            float radius = drone.Data.AvoidanceRadius;
            float strengthFactor = drone.Data.AvoidanceStrength;

            foreach (var other in FindObjectsOfType<DroneController>())
            {
                if (other == drone) continue;

                Vector3 diff = transform.position - other.transform.position;
                float dist = diff.magnitude;

                if (dist < radius)
                {
                    float strength = (radius - dist) / radius;
                    force += diff.normalized * strength;
                }
            }

            transform.position += force * strengthFactor * Time.deltaTime;
        }

        private void OnDrawGizmosSelected()
        {
            if (drone != null && drone.Data != null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(transform.position, drone.Data.AvoidanceRadius);
            }
        }
    }
}