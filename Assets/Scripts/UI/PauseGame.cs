using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private Button gearButton;
    [SerializeField] private GameObject pauseUI;

    private bool isPaused = false;

    private void Awake()
    {
        gearButton.onClick.AddListener(() =>
        {
            TogglePauseUI();
        });
    }

    public void TogglePauseUI()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1f;
        }

        pauseUI.SetActive(isPaused);
    }

}
