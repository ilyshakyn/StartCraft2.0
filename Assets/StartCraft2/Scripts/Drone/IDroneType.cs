using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDroneType 
{
    float Speed { get; }
    float CollectDuration { get; }
    float TargetReachThreshold { get; }
    float AvoidanceRadius { get; }
    float AvoidanceStrength { get; }
    void OnResourceCollected();
   
}
