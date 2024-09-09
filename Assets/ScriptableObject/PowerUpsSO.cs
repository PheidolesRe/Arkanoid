using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PowerUps")]
public class PowerUpsSO : ScriptableObject
{
    public PowerUpInfoSO x2PowerUp;
    public PowerUpInfoSO ghostPowerUp;
    public PowerUpInfoSO speedPowerUp;
    public PowerUpInfoSO damagePowerUp;

    public List<PowerUpInfoSO> GetPowerUpList()
    {
        List<PowerUpInfoSO> listPowerUp = new List<PowerUpInfoSO>();
        listPowerUp.Add(x2PowerUp);
        listPowerUp.Add(ghostPowerUp);
        listPowerUp.Add(speedPowerUp);
        listPowerUp.Add(damagePowerUp);

        return listPowerUp;
    }
}
