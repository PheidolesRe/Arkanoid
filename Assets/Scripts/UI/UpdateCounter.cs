using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateCounter : MonoBehaviour
{
    private TextMeshProUGUI m_TextMeshPro;

    private float countDown = 3;

    private void Awake()
    {
        m_TextMeshPro = GetComponent<TextMeshProUGUI>();
    }


    private void Update()
    {
        m_TextMeshPro.text = Mathf.Ceil(countDown).ToString();
        countDown -= Time.deltaTime;
    }
}
