using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SquaresHP squaresHP = collision.gameObject.GetComponent<SquaresHP>();

        if (squaresHP)
        {
            squaresHP.TakeDamage(Ball.ballDamage);
        }
    }
}
