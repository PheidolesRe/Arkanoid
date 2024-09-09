using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PowerUpInfoSO;

public class PowerUpSpawn : MonoBehaviour
{
    [SerializeField] private PowerUpsSO powerUpsSO;

    private PowerUpInfoSO powerUpType;

    public void SpawnPowerUp()
    {        
        GameObject newPowerUp = Instantiate(GetRandomPowerUp(), transform.position, Quaternion.identity); 
        newPowerUp.transform.GetChild(0).GetComponent<UsedPowerUps>().SetPowerUpType(powerUpType);
        
    }

    private GameObject GetRandomPowerUp()
    {
        List<PowerUpInfoSO> listPowerUp = powerUpsSO.GetPowerUpList();
        powerUpType = listPowerUp[Random.Range(0, listPowerUp.Count)];
        return powerUpType.powerUpPrefab;
    }
}
