using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 lastVelocity;

    private float stackTime = 0;
    private float maxStackTime = 0.05f;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        lastVelocity = rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {   
        Bouncable bouncable = collision.gameObject.GetComponent<Bouncable>();

        if (bouncable) 
        {
            Vector3 reflectedDirection = Vector3.Reflect(lastVelocity.normalized, collision.GetContact(0).normal);
            rb.velocity = reflectedDirection * BallMovement.speed;
        }

        SquaresHP squaresHP = collision.gameObject.GetComponent<SquaresHP>();

        if (squaresHP)
        {
            stackTime = 0;
            squaresHP.TakeDamage(Ball.ballDamage);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Bouncable bouncable = collision.gameObject.GetComponent<Bouncable>();

        if (bouncable)
        {
            rb.velocity = rb.velocity.normalized * BallMovement.speed;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        SquaresHP squaresHP = collision.gameObject.GetComponent<SquaresHP>();

        if (squaresHP)
        {
            stackTime += Time.deltaTime;
            if (stackTime >= maxStackTime)
            {
                squaresHP.TakeDamage(Ball.ballDamage);
                rb.velocity = rb.velocity.normalized * BallMovement.speed;         
            }
        }
    }
}
