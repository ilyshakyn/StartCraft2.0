using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.StartCraft2.Scripts.Drone
{
    public class BasePoint: MonoBehaviour
    {
        public void AcceptResource()
        {
            GameManager.Instance?.ResourceDelivered();
        }
    }
}
