using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PowerUpInfoSO;

public class UsedPowerUps : MonoBehaviour
{
    [SerializeField] private PowerUpInfoSO powerUpInfo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.transform.GetComponent<Player>();

        if (player)
        {
            if (powerUpInfo.powerUpType == PowerUpType.X2)
            {
                EventBus.OnUsedTwicePowerUp?.Invoke();                
            }
            
            if (powerUpInfo.powerUpType == PowerUpType.Ghost)
            {
                EventBus.OnUsedGhostPowerUp?.Invoke();
            } 
            
            if (powerUpInfo.powerUpType == PowerUpType.Speed)
            {
                EventBus.OnUsedSpeedPowerUp?.Invoke();
            } 
            
            if (powerUpInfo.powerUpType == PowerUpType.Damage)
            {
                EventBus.OnUsedDamagePowerUp?.Invoke();
            }            

            Destroy(transform.parent.gameObject);
        }
    }

    public void SetPowerUpType(PowerUpInfoSO type)
    {
        powerUpInfo = type;
    }
}
