using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public static float speed;
    public static float maxSpeed;
    public static float speedBeforeBoost;

    private const float defaultSpeed = 14;
    private const float defaultMaxSpeed = 28;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = defaultSpeed;
        maxSpeed = defaultMaxSpeed;
    }

    private void OnEnable()
    {
        EventBus.OnGameStrated += GiveBallVelocity;
    }

    private void OnDisable()
    {
        EventBus.OnGameStrated -= GiveBallVelocity;        
    }

    private void GiveBallVelocity()
    {
        rb.velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(0.3f, 1f)).normalized * speed; 
    }

}
