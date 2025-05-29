using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.StartCraft2.Scripts.Drone
{
    public class DroneEventChannel : MonoBehaviour, IDroneEventChannel
    {

        public event Action OnResourceDropped;

        public void RaiseResourceDropped()
        {
            OnResourceDropped?.Invoke();
        }

    }
}
