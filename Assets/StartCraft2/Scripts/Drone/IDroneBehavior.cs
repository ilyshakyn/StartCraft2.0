using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.StartCraft2.Scripts.Drone
{
    public interface IDroneBehavior
    {
        void OnEnter(); 
        void Tick();    
        void OnExit();
    }
}
