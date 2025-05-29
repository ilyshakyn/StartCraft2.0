using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.StartCraft2.Scripts.Drone
{
    public class DroneSpawnManager:MonoBehaviour
    {
        [SerializeField] private List<GameObject> dronePool; 

        private void Start()
        {
            int targetCount = GameManager.Instance.DroneCount;

            for (int i = 0; i < dronePool.Count; i++)
            {
                if (i < targetCount)
                    dronePool[i].SetActive(true);
                else
                    Destroy(dronePool[i]);
            }
        }
    }
}

