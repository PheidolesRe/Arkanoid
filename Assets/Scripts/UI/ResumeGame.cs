using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResumeGame : MonoBehaviour
{
    [SerializeField] private PauseGame gearUI;

    private Button resumeButton;

    private void Awake()
    {
        resumeButton = GetComponent<Button>();

        resumeButton.onClick.AddListener(() =>
        {
            gearUI.TogglePauseUI();
        });
    }
}
