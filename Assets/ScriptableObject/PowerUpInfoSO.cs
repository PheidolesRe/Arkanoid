using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUpInfo")]
public class PowerUpInfoSO : ScriptableObject
{
    public GameObject powerUpPrefab;
    public PowerUpType powerUpType;

    public enum PowerUpType
    {
        X2,
        Ghost,
        Speed,
        Damage,
    }
}
