using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverSquares : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SquaresHP square = collision.GetComponent<SquaresHP>();

        if (square)
        {
            EventBus.OnGameOver?.Invoke();
        }
    }
}
