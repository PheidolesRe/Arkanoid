using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartGame : MonoBehaviour
{
    private Button restartButton;

    readonly string SceneName = "Main";

    private void Awake()
    {
        restartButton = GetComponent<Button>();

        restartButton.onClick.AddListener(() =>
        {
            Time.timeScale = 1f;
            Physics2D.IgnoreLayerCollision(6, 7, false);
            SceneManager.LoadScene(SceneName);
        });
    }
}
