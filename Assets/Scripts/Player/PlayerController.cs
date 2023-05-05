using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5.0f;

    private PlayerAction controls;
    private InputAction move;
    private InputAction slow;

    Vector2 moveDirection = Vector2.zero;

    bool isSlow;

    void Awake()
    {
        controls = new PlayerAction();
    }

    private void OnEnable()
    {
        move = controls.Player.Move;
        move.Enable();
        slow = controls.Player.Slow;
        slow.performed += Slow;
        //slow.started += Slow;
        slow.Enable();

    }

    private void OnDisable()
    {
        move.Disable();
        slow.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = move.ReadValue<Vector2>();

        if (slow.IsPressed())
        {
            moveSpeed = 3.0f;
        }
        else if (slow.WasReleasedThisFrame())
        {
            moveSpeed = 7.0f;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    private void Slow(InputAction.CallbackContext context)
    {

    }
}
