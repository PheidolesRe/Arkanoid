using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpFalliing : MonoBehaviour
{
    private float fallingSpeed = 10;
    private Rigidbody2D rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rb.velocity = Vector3.down * fallingSpeed;
    }
}
