using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed = 5f; //speed at which the player moves. can be changed here or directly in unity
    public float jumpHeight = 5f; //height the player can jump. can be changed here of directly in unity
    public JumpRaycastingScript groundRaycast; //allows for reading variables from raycasting script
    public SwapRaycastingScript swapRaycast;
    Rigidbody2D rb; //creates variable for storing rigidbody component
    float coyoteTime = 0.15f; //the time for which the player can be off the ground while still being allowed to jump (somewhere between 0.1 and 0.2 seems like the sweet spot)
    Vector2 moveDirection = Vector2.zero; //vector stores what direction the player should move
    int facingDirection = 1;
    public PlayerInputs playerControls;
    InputAction move;
    InputAction swap;
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

        swap = playerControls.Player.Swap;
        swap.Enable();
        swap.performed += Swap;

        jump = playerControls.Player.Jump;
        jump.Enable();
        jump.performed += Jump;
    }

    void OnDisable() //turns movement binds back off again. if any new ones are added they need to be here as well
    {
        move.Disable();
        swap.Disable();
        jump.Disable();
    }

    void Update() //runs every frame
    {
        moveDirection = move.ReadValue<Vector2>();
        facingDirection = FindFacingDirection(moveDirection, facingDirection);
        Debug.DrawRay(transform.position, new Vector3(facingDirection, 0, 0) * 20, Color.red);
    }

    int FindFacingDirection(Vector3 _movement, int _currentDirection)
    {
        if (_movement.x < 0)
        {
            return -1;
        }
        if (_movement.x > 0)
        {
            return 1;
        }
        return facingDirection;
    }

    void Swap(InputAction.CallbackContext context) //runs when the swap keybind is pressed
    {
        RaycastHit2D swapRay = swapRaycast.Raycast2D(facingDirection);
        if (swapRay == true) {
            if (swapRay.collider.name == "Crate")
            {
                CrateSwapScript Crate = swapRay.collider.GetComponent<CrateSwapScript>();
                Vector3 newPosition = Crate.CrateSwapPosition(transform.position);
                transform.position = newPosition;
            }
        }
    }

    bool CalculateCanJump() //uses raycast and coyote time to determine if the player can jump
    {
        if (groundRaycast.RaycastAll() == true)
        {
            coyoteTime = 0.15f;
            return true;
        }
        else
        {
            coyoteTime -= Time.deltaTime;
        }

        if (coyoteTime < 0)
        {
            return false;
        }
        return false;
    }

    void FixedUpdate() //runs every fixed frame, used for physics (movement mainly)
    {
        rb.linearVelocity = new Vector2(moveDirection.x * moveSpeed, rb.linearVelocityY);

    }
    void Jump(InputAction.CallbackContext context) //runs when the Jump keybind is pressed
    {
        if (CalculateCanJump() == true)
        {
            rb.linearVelocityY = jumpHeight;
        }
    }
}
