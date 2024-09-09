using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRow : MonoBehaviour
{
    [SerializeField] private GameObject rowPrefab;

    private int RowToIncreaseHP = 3;

    public void NewRow()
    {
        RowToIncreaseHP--;
        if (RowToIncreaseHP == 0)
        {
            RowToIncreaseHP = 3;
            EventBus.OnSlightlyIncreasedBallSpeedAndSquaresHP?.Invoke();
        }

        Instantiate(rowPrefab, transform.position, Quaternion.identity);
    }
}
