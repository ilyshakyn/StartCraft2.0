using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.StartCraft2.Scripts.ResourseSoawner
{
    static class ResourceSpawner
    {
        public static Transform[] spawnPoints;

        public static void Respawn(GameObject resource)
        {
        
            if (spawnPoints == null || spawnPoints.Length == 0) return;
            
            
            int index = UnityEngine.Random.Range(0, spawnPoints.Length);
            resource.transform.position = spawnPoints[index].position;
            resource.SetActive(true);
        }
    }
}
