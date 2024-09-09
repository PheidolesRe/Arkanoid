using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BestScoreUI : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    private TextMeshProUGUI textMeshProUGUI;

    private void Awake()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        textMeshProUGUI.text = PlayerPrefs.GetString(gameManager.PLAYER_PREFS_BEST_SCORE);
    }
}
