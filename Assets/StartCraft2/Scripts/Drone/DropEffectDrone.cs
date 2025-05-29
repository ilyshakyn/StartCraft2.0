using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.StartCraft2.Scripts.Drone
{
    public class DropEffectDrone:MonoBehaviour
    {
        [SerializeField] private DroneEventChannel channel;
        [SerializeField] private GameObject dropEffectPrefab;

        private void OnEnable()
        {
            channel.OnResourceDropped += PlayEffect;
        }

        private void OnDisable()
        {
            channel.OnResourceDropped -= PlayEffect;
        }

        private void PlayEffect()
        {
            var effect = Instantiate(dropEffectPrefab, transform.position, Quaternion.identity);
            var ps = effect.GetComponent<ParticleSystem>();
            ps?.Play();
            Destroy(effect, ps.main.duration); 
        }
    }
}