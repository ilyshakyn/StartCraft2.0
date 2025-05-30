using Assets.StartCraft2.Scripts.Drone;
using Assets.StartCraft2.Scripts.ResourseSoawner;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DroneGamesLogic : MonoBehaviour
{
    [SerializeField] DroneDataSO droneData;
    [SerializeField] private Slider slider;
    [SerializeField] private  static Text count;
    [SerializeField] private TMP_InputField timeResourse;


    private void Start()
    {
        count = GetComponentInChildren<Text>();
        slider.onValueChanged.AddListener(OnSliderValueChanged);
        timeResourse.onEndEdit.AddListener(OnInputEditFinished);
       
       
    }

    public static void TextCount(int value)
    {
        count.text = "Фракции собрали " + value.ToString() + " монет";
    }

    private void OnInputEditFinished(string finalValue)
    {
        if (finalValue==null || finalValue =="") return;
        ResourceManager.timeForSpawn = int.Parse(finalValue);
    }
    private void OnSliderValueChanged(float newValue)
    {
        droneData.Speed = newValue;

    }

}