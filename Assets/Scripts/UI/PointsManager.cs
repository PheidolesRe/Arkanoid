using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    private  TextMeshProUGUI tMeshProUGUI;

    private void Awake()
    {
        tMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        EventBus.OnGainPoints += IncreasePoints;
    }

    private void OnDisable()
    {
        EventBus.OnGainPoints -= IncreasePoints;        
    }

    private void IncreasePoints(int poiontsAmount)
    {
        int currentPoints = int.Parse(tMeshProUGUI.text);
        currentPoints += poiontsAmount;
        tMeshProUGUI.text = currentPoints.ToString("0000");
    }
}
