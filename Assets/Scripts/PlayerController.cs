using Mono.Cecil;
using System;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed = 5f; //speed at which the player moves. can be changed here or directly in unity
    public float jumpHeight = 5f; //height the player can jump. can be changed here of directly in unity
    public RaycastingScript groundRaycast; //allows for reading variables from raycasting script
    Rigidbody2D rb; //creates variable for storing rigidbody component
    bool isGrounded; //checks if the player is currently on the ground
    bool canJump; //checks if the player is able to jump (taking into account coyote time
    float coyoteTime = 0.15f; //the time for which the player can be off the ground while still being allowed to jump (somewhere between 0.1 and 0.2 seems like the sweet spot)
    Vector2 moveDirection = Vector2.zero; //vector stores what direction the player should move
    public PlayerInputs playerControls;
    InputAction move; 
    InputAction jump;

    void Awake()
    {
        playerControls = new PlayerInputs(); //allows for using new input system
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // stores rigidbody component in rb
    }

    void OnEnable() //enables all movement binds. if any new ones are added they need to be added here
    {
        move = playerControls.Player.Move;
        move.Enable();

        jump = playerControls.Player.Jump;
        jump.Enable();
        jump.performed += Jump;
    }

    void OnDisable() //turns movement binds back off again. if any new ones are added they need to be here as well
    {
        move.Disable();
        jump.Disable();
    }

    void Update() //runs every frame
    {
        isGrounded = groundRaycast.rayHit;
        moveDirection = move.ReadValue<Vector2>();
        CalculateCanJump();
    }

    void CalculateCanJump() //uses raycast and coyote time to determine if the player can jump
    {
        if (isGrounded)
        {
            coyoteTime = 0.15f;
            canJump = true;
        }
        else
        {
            coyoteTime -= Time.deltaTime;
        }

        if (coyoteTime < 0)
        {
            canJump = false;
        }
    }

    void FixedUpdate() //runs every fixed frame, used for physics (movement mainly)
    {
        rb.linearVelocity = new Vector2(moveDirection.x * moveSpeed, rb.linearVelocityY);

    }
    void Jump(InputAction.CallbackContext context) //runs when the Jump keybind is pressed
    {
        if (canJump)
        {
            rb.linearVelocityY = jumpHeight;
        }
    }
}
