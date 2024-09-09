using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SquareHealthUI : MonoBehaviour
{
    TextMeshProUGUI textMeshProUGUI;

    private void Awake()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        EventBus.OnRefreshedSquareHealthUI += RefreshSquareHealthUI;
    }

    private void OnDisable()
    {
        EventBus.OnRefreshedSquareHealthUI -= RefreshSquareHealthUI;
    }

    private void RefreshSquareHealthUI()
    {
        textMeshProUGUI.text = Squares.maxHealth.ToString("000");
    }
}
