using Mono.Cecil;
using System;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpHeight = 5f;
    public PlayerInputs playerControls;
    private Rigidbody2D rb;
    public bool isGrounded;
    private Vector2 moveDirection = Vector2.zero;
    private InputAction move;
    private InputAction jump;

    private void Awake()
    {
        playerControls = new PlayerInputs();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();

        jump = playerControls.Player.Jump;
        jump.Enable();
        jump.performed += Jump;
    }

    private void OnDisable()
    {
        move.Disable();
        jump.Disable();
    }

    void Update()
    {
        moveDirection = move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveDirection.x * moveSpeed, rb.linearVelocityY);

    }
    private void Jump(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            rb.linearVelocityY = jumpHeight;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
