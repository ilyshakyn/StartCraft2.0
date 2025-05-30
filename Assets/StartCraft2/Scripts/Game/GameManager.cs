using Assets.StartCraft2.Scripts.Drone;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

   
    public int totalDelivered = 0;
    public int DroneCount { get; private set; } = 3; 
    private void Awake()    
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public void ResourceDelivered()
    {
        totalDelivered++;
        DroneGamesLogic.TextCount(totalDelivered);
    }

    public void SetDroneCount(int count)
    {
        DroneCount = count;
    }
    public void SetTimeScale(float scale)
    {
        Time.timeScale = scale;
    }
}
