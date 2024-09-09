using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FelllDown : MonoBehaviour
{
    [SerializeField] Ball ballManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BallBounce ball = collision.GetComponent<BallBounce>();
        UsedPowerUps powerUp = collision.GetComponent<UsedPowerUps>();

        if (ball)
        {
            Destroy(collision.gameObject);
            ballManager.DecreaseBallAmount();
        }

        if (powerUp)
        {
            Destroy(collision.transform.parent.gameObject);
        }
    }
}
