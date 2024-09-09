using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private int amountIncreasingDamage = 3;
    [SerializeField] private float speedBounceIncrease = 0.05f;

    private bool isSpeedBoostActive;
    private int currentBallAmount;


    readonly int startDamage = 5;

    public static int ballDamage { get; private set; } = 5;

    private void Awake()
    {
        ballDamage = startDamage;
        currentBallAmount = 1;
    }

    private void OnEnable()
    {
        EventBus.OnUsedDamagePowerUp += IncreaseBallDamage;
        EventBus.OnUsedSpeedPowerUp += IncreaseBallSpeed;
        EventBus.OnRestoredBallSpeed += BringedBackBallSpeed;
        EventBus.OnSlightlyIncreasedBallSpeedAndSquaresHP += SlightlyIncreaseBallSpeed;
        EventBus.OnUsedTwicePowerUp += DoubledBallAmount;
    }

    private void OnDisable()
    {
        EventBus.OnUsedDamagePowerUp -= IncreaseBallDamage;
        EventBus.OnUsedSpeedPowerUp -= IncreaseBallSpeed;
        EventBus.OnRestoredBallSpeed -= BringedBackBallSpeed;
        EventBus.OnSlightlyIncreasedBallSpeedAndSquaresHP -= SlightlyIncreaseBallSpeed;
        EventBus.OnUsedTwicePowerUp -= DoubledBallAmount;
    }

    private void IncreaseBallDamage()
    {
        ballDamage += amountIncreasingDamage;
        EventBus.OnRefreshedDamageUI?.Invoke();
    }

    private void IncreaseBallSpeed()
    {
        if (!isSpeedBoostActive)
        { 
            BallMovement.speedBeforeBoost = BallMovement.speed;
            BallMovement.speed = BallMovement.maxSpeed;
            EventBus.OnIncreasedBallSpeed?.Invoke();
            isSpeedBoostActive = true;
        }
    }

    private void BringedBackBallSpeed()
    {
        BallMovement.speed = BallMovement.speedBeforeBoost;   
        isSpeedBoostActive = false;
    }

    private void SlightlyIncreaseBallSpeed()
    {
        BallMovement.speed += speedBounceIncrease;
        BallMovement.maxSpeed += speedBounceIncrease * 2;
        Debug.Log(BallMovement.speed);
    }

    private void DoubledBallAmount()
    {
        currentBallAmount *= 2;
    }

    public void DecreaseBallAmount()
    {
        currentBallAmount--;
        if (currentBallAmount <= 0)
        {
            EventBus.OnGameOver?.Invoke();
        }
        Debug.Log(currentBallAmount);
    }
}
