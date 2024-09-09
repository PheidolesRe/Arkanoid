using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitUI : MonoBehaviour
{
    private Button quitButton;

    private void Awake()
    {
        quitButton = GetComponent<Button>();

        quitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }


}
