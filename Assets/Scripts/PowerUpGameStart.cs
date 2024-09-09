using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpGameStart : MonoBehaviour
{
    private PowerUpSpawn powerUpSpawn;

    private void Awake()
    {
        powerUpSpawn = GetComponent<PowerUpSpawn>();
        transform.position = transform.position + new Vector3(Random.Range(-8f, 8f), 0, 0);
    }

    private void OnEnable()
    {
        EventBus.OnGameStrated += SpawnBonusPowerUP;
    }

    private void OnDisable()
    {
        EventBus.OnGameStrated -= SpawnBonusPowerUP;        
    }

    private void SpawnBonusPowerUP()
    {
        powerUpSpawn.SpawnPowerUp();
    }
}
