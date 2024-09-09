using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestInput : MonoBehaviour
{
    private PlayerInput plIn;

    public delegate void StartTouchEvent(Vector2 pos, float time);
    public event StartTouchEvent OnStartTouch;
    public delegate void EndTouchEvent(Vector2 pos, float time);
    public event EndTouchEvent OnEndTouch;

    private Touch touch;
    Rigidbody2D rb;

    private void Awake()
    {
        plIn = new PlayerInput();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        plIn.Player.TouchTap.started += ctx => StartTouch(ctx);
        plIn.Player.TouchTap.canceled += ctx => EndTouch(ctx);
    }

    

    private void StartTouch(InputAction.CallbackContext context)
    {
        //if (OnStartTouch != null)
        //{
        //    OnStartTouch(plIn.Player.TouchPos.ReadValue<Vector2>(), (float)context.startTime);
        //}
        //Vector2 worldPos = Camera.main.ScreenToWorldPoint(plIn.Player.TouchPos.ReadValue<Vector2>());
        float worldX = Camera.main.ScreenToWorldPoint(plIn.Player.TouchPos.ReadValue<Vector2>()).x;
        float deltaX = worldX - transform.position.x;
        rb.MovePosition(new Vector2 (worldX, transform.position.y));
        Debug.Log(worldX);
    }
    
    private void EndTouch(InputAction.CallbackContext context)
    {
        if (OnEndTouch != null)
        {
            OnEndTouch(plIn.Player.TouchPos.ReadValue<Vector2>(), (float)context.time);
        }
    }

    private void Move(Vector2 screenPos, float time)
    {        
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        transform.position = worldPos;
    }

    private void OnEnable()
    {
        plIn.Enable();
        OnStartTouch += Move;
    }

    private void OnDisable()
    {
        plIn.Disable();
        OnEndTouch -= Move;
    }
}

