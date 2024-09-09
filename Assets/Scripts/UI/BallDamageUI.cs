using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallDamageUI : MonoBehaviour
{
    private TextMeshProUGUI m_TextMeshProUGUI;

    private void Awake()
    {
        m_TextMeshProUGUI = GetComponent<TextMeshProUGUI>();    
    }

    private void OnEnable()
    {
        EventBus.OnRefreshedDamageUI += RefreshDamageUI;
    }

    private void OnDisable()
    {
        EventBus.OnRefreshedDamageUI -= RefreshDamageUI;        
    }

    private void RefreshDamageUI()
    {
        //int damageUI = int.Parse(m_TextMeshProUGUI.text);
        //damageUI = Ball.ballDamage;
        m_TextMeshProUGUI.text = Ball.ballDamage.ToString("000");
    }
}
