using Assets.StartCraft2.Scripts.Pathfinder;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.StartCraft2.Scripts.ResourseSoawner
{
    public class ResourceManager : MonoBehaviour
    {
        public static ResourceManager Instance;

        [SerializeField] private GameObject resourcePrefab;
        [SerializeField] private Transform[] spawnPoints;

        private List<GameObject> activeResources = new List<GameObject>();

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);

          
            ResourceSpawner.spawnPoints = spawnPoints;
        }

        private void Start()
        {
            SpawnInitialResources();
        }

        public void SpawnInitialResources()
        {
            foreach (var point in spawnPoints)
            {
                GameObject res = Instantiate(resourcePrefab, point.position, Quaternion.identity);
                activeResources.Add(res);
            }
        }

        public GameObject GetBestAvailableResource(Vector3 position)
        {
            GameObject fallback = null;
            float fallbackDist = float.MaxValue;

            GameObject best = null;
            float bestDist = float.MaxValue;

            foreach (var res in activeResources)
            {
                if (!res.activeSelf) continue;

                float dist = Vector3.Distance(position, res.transform.position);

                
                var navPath = new NavMeshPath();
                bool hasPath = NavMesh.CalculatePath(position, res.transform.position, NavMesh.AllAreas, navPath);

                if (hasPath && navPath.status == NavMeshPathStatus.PathComplete && navPath.corners.Length > 1)
                {
                    if (dist < bestDist)
                    {
                        bestDist = dist;
                        best = res;
                    }
                }

                
                if (dist < fallbackDist)
                {
                    fallbackDist = dist;
                    fallback = res;
                }

                Debug.DrawLine(position, res.transform.position, Color.cyan, 1.5f);
            }

            return best ?? fallback;
        }

        public void RespawnResource(GameObject resource)
        {
            StartCoroutine(SpawnPoTime(resource));
          
        }

        private IEnumerator SpawnPoTime(GameObject resource)
        {
            yield return new WaitForSeconds(2);
            ResourceSpawner.Respawn(resource);
        }
        
    }
}

