using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverScoreUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI pointsText;

    private TextMeshProUGUI m_TextMeshPro;

    private void Awake()
    {
        m_TextMeshPro = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        m_TextMeshPro.text = pointsText.text;
    }
}
