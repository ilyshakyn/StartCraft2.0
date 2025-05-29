using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DroneCountSelector : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Text valueText;

    private void Start()
    {
        slider.onValueChanged.AddListener(UpdateValue);
        UpdateValue(slider.value);
    }

    private void UpdateValue(float value)
    {
        int droneCount = Mathf.RoundToInt(value);
        valueText.text = $"Дронов: {droneCount}";
        GameManager.Instance.SetDroneCount(droneCount);
    }
}