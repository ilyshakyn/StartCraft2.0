using Assets.StartCraft2.Scripts.Drone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.StartCraft2.Scripts.Pathfinder
{
    public class Pathfinder : MonoBehaviour
    {
        private List<Vector3> path;
        private int index;
        private DroneController drone;

        private void Awake() => drone = GetComponent<DroneController>();

        public void SetTarget(Vector3 target)
        {
            NavMeshPath navPath = new NavMeshPath();
            if (NavMesh.CalculatePath(transform.position, target, NavMesh.AllAreas, navPath))
            {
                path = navPath.corners.ToList();
                index = 0;
            }
        }

        public void Tick()
        {
            if (path == null || index >= path.Count) return;

            Vector3 target = path[index];
            Vector3 dir = (target - transform.position).normalized;
            transform.position += dir * drone.Data.Speed * Time.deltaTime;

            if (Vector3.Distance(transform.position, target) < 0.1f)
            {
                index++;
            }
        }
    }
}