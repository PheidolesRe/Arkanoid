using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallUsePowerUp : MonoBehaviour
{
    private Rigidbody2D rb;
    private float GhostTime = 8f;
    private float speedBoostTime = 8f;
    private int ghostUsed = 0;
    private int speedUsed = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();  
    }

    private void OnEnable()
    {
        EventBus.OnUsedTwicePowerUp += TwiceBall;
        EventBus.OnUsedGhostPowerUp += MakeBallGhost;
        EventBus.OnIncreasedBallSpeed += IncreaseBallSpeed;
    }

    private void OnDisable()
    {
        EventBus.OnUsedTwicePowerUp -= TwiceBall;        
        EventBus.OnUsedGhostPowerUp -= MakeBallGhost;        
        EventBus.OnIncreasedBallSpeed -= IncreaseBallSpeed;
    }

    private void TwiceBall()
    {
        GameObject newball = Instantiate(gameObject, transform.position, Quaternion.identity);
        newball.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(0, 1f)).normalized * BallMovement.speed;
    }    

    private void MakeBallGhost()
    {
        StartCoroutine(GhostBallRoutine());
    }

    private IEnumerator GhostBallRoutine()
    {
        Physics2D.IgnoreLayerCollision(6, 7, true);        
        transform.GetChild(1).gameObject.SetActive(true);
        ghostUsed++;

        yield return new WaitForSeconds(GhostTime);

        ghostUsed--;

        if (ghostUsed == 0) 
        {
            transform.GetChild(1).gameObject.SetActive(false);
            Physics2D.IgnoreLayerCollision(6, 7, false);        
        }
    }

    private void IncreaseBallSpeed()
    {
        StartCoroutine(IncreaseSpeedRoutine());
    }

    private IEnumerator IncreaseSpeedRoutine()
    {
        if (speedUsed == 0)
        {
            rb.velocity = rb.velocity.normalized * BallMovement.speed;
        }

        speedUsed++;

        yield return new WaitForSeconds(speedBoostTime);

        speedUsed--;

        if (speedUsed == 0)
        { 
            EventBus.OnRestoredBallSpeed?.Invoke();
            rb.velocity = rb.velocity.normalized * BallMovement.speed;
        }
    }
}
