using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CreateRow createRow;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private int maxCountToSpawnPowerUp = 13;
    [SerializeField] private TextMeshProUGUI textCurrentPoints;

    private float timer;
    private float maxTimer = 8f;

    public readonly string PLAYER_PREFS_BEST_SCORE = "BestScore";


    private int countToSpawnPowerUp = 13;


    private void Awake()
    {
        timer = maxTimer;
        countToSpawnPowerUp = maxCountToSpawnPowerUp;
        createRow.NewRow();      
        Physics2D.IgnoreLayerCollision(6, 6);
    }

    private void OnEnable()
    {
        EventBus.OnGameOver += GameOver;
    }

    private void OnDisable()
    {
        EventBus.OnGameOver -= GameOver;        
    }

    private void Start()
    {
        if (!PlayerPrefs.HasKey(PLAYER_PREFS_BEST_SCORE))
        {
            PlayerPrefs.SetString(PLAYER_PREFS_BEST_SCORE, "0000");
        }

        EventBus.OnRefreshedSquareHealthUI?.Invoke();
        EventBus.OnRefreshedDamageUI?.Invoke();
    }


    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            EventBus.OnMovedRow?.Invoke();
            createRow.NewRow();
            timer = maxTimer;
        }
    }

    public int GetCountToSpawnPowerUp()
    {
        countToSpawnPowerUp--;
        return countToSpawnPowerUp;
    }

    public void SetCountToMaxValue()
    {
        countToSpawnPowerUp = maxCountToSpawnPowerUp;
    }

    private void GameOver()
    {
        Time.timeScale = 0f;

        gameOverUI.SetActive(true);

        if (int.Parse(textCurrentPoints.text) > int.Parse(PlayerPrefs.GetString(PLAYER_PREFS_BEST_SCORE)))
        { 
            PlayerPrefs.SetString(PLAYER_PREFS_BEST_SCORE, textCurrentPoints.text);
            PlayerPrefs.Save();
        }
    }

}
