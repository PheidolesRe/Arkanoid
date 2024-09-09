using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SquaresHP : MonoBehaviour
{
    [SerializeField] private int pointsForSquare = 1;
    [SerializeField] private int pointsForRow = 5;
    [SerializeField] private GameManager gameManager;

    private PowerUpSpawn spawnPowerUp;    
    private int currentSquareHealth;

    private void Awake()
    {
        spawnPowerUp = GetComponent<PowerUpSpawn>();
    }

    private void Start()
    {
        currentSquareHealth = Squares.maxHealth;        
    }


    public void TakeDamage(int damage)
    { 
        currentSquareHealth -= damage;
        CheckDeathAndHalfHP();
    }

    private void CheckDeathAndHalfHP()
    {
        if (currentSquareHealth <= 0)
        {
            if (gameManager.GetCountToSpawnPowerUp() == 0)
            {
                gameManager.SetCountToMaxValue();
                spawnPowerUp.SpawnPowerUp();
            }

            if (transform.parent.childCount == 1) 
            {
                EventBus.OnGainPoints?.Invoke(pointsForSquare);
                EventBus.OnGainPoints?.Invoke(pointsForRow);
                Destroy(transform.parent.gameObject);
            }

            EventBus.OnGainPoints?.Invoke(pointsForSquare); 

            Destroy(gameObject);
        }

        if (currentSquareHealth <= Squares.maxHealth / 2)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }

}
