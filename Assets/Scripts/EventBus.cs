using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public static class EventBus
{
    public static Action OnMovedRow;

    public static Action OnUsedTwicePowerUp;
    public static Action OnUsedGhostPowerUp;
    public static Action OnUsedSpeedPowerUp;
    public static Action OnUsedDamagePowerUp;

    public static Action OnRefreshedDamageUI;
    public static Action OnRefreshedSquareHealthUI;

    public static Action OnSlightlyIncreasedBallSpeedAndSquaresHP;

    public static Action OnIncreasedBallSpeed;
    public static Action OnRestoredBallSpeed;

    public static Action OnGameStrated;
    public static Action OnGameOver;


    public static Action<int> OnGainPoints;
    
}
