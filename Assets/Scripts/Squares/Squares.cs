using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squares : MonoBehaviour
{
    [SerializeField] private int amountIncreasingHP = 2;

    readonly int startmaxHealth = 5;

    public static int maxHealth { get; private set; } = 5;

    private void Awake()
    {
        maxHealth = startmaxHealth;
    }

    private void OnEnable()
    {
        EventBus.OnSlightlyIncreasedBallSpeedAndSquaresHP += IncreaseMaxHP;
    }

    private void OnDisable()
    {
        EventBus.OnSlightlyIncreasedBallSpeedAndSquaresHP -= IncreaseMaxHP;
    }

    private void IncreaseMaxHP()
    {
        maxHealth += amountIncreasingHP;
        EventBus.OnRefreshedSquareHealthUI?.Invoke();
    }
}
