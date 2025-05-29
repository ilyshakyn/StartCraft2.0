using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.StartCraft2.Scripts.Drone
{
    public interface IDroneEventChannel
    {
        event Action OnResourceDropped;
        void RaiseResourceDropped();
    }
}
