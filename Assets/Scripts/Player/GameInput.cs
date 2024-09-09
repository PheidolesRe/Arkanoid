using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    private PlayerInput playerInput;
    private Rigidbody2D rb;
    private float deltaX;
    Touch touch;
    Touch touch1;

    private void Awake()
    {
        playerInput = new PlayerInput();
        rb = GetComponent<Rigidbody2D>();
        //touch1 = playerInput.Player.Move.ReadValue<Touch>();
        
    }

    private void Update()
    {
        MovePlayerTo();
    }

    private void MovePlayerTo()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            //touch = playerInput.Player.Move.ReadValue<Touch>();

            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            switch (touch.phase)
            {
                case UnityEngine.TouchPhase.Began:
                    deltaX = touchPos.x - transform.position.x;
                    break;

                case UnityEngine.TouchPhase.Moved:
                    rb.MovePosition(new Vector2((touchPos.x - deltaX), transform.position.y));
                    break;

                case UnityEngine.TouchPhase.Ended:
                    rb.velocity = Vector2.zero;
                    break;
            }
        }
        //movePosition = Camera.main.ScreenToWorldPoint(playerInput.Player.Move.ReadValue<Vector2>());
        ////movePosition = Camera.main.ScreenToWorldPoint(movePosition);
        //playerInput.Player.Move.
        //rb.MovePosition(movePosition);
        //Debug.Log(movePosition);
    }
}
