using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed = 5f; //speed at which the player moves. can be changed here or directly in unity
    public float jumpHeight = 5f; //height the player can jump. can be changed here of directly in unity
    public JumpRaycastingScript groundRaycast; //allows for reading variables from raycasting script
    public SwapRaycastingScript swapRaycast;
    public DrawSwapLineScript swapLine;
    public Vector3[] swapLinePoints;
    Rigidbody2D rb; //creates variable for storing rigidbody component
    float coyoteTime = 0.15f; //the time for which the player can be off the ground while still being allowed to jump (somewhere between 0.1 and 0.2 seems like the sweet spot)
    Vector2 moveDirection = Vector2.zero; //vector stores what direction the player should move
    int facingDirection = 0;
    public PlayerInputs playerControls;
    InputAction move;
    InputAction swap;
    InputAction jump;

    void Awake() {
        playerControls = new PlayerInputs(); //allows for using new input system
    }

    void Start() {
        rb = GetComponent<Rigidbody2D>(); // stores rigidbody component in rb
        swapLinePoints = new Vector3[2];
    }

    void OnEnable() { //enables all movement binds. if any new ones are added they need to be added here
        move = playerControls.Player.Move;
        move.Enable();

        swap = playerControls.Player.Swap;
        swap.Enable();
        swap.performed += Swap;

        jump = playerControls.Player.Jump;
        jump.Enable();
        jump.performed += Jump;
    }

    void OnDisable() { //turns movement binds back off again. if any new ones are added they need to be here as well
        move.Disable();
        swap.Disable();
        jump.Disable();
    }

    void Update() {//runs every frame
        moveDirection = move.ReadValue<Vector2>();
        facingDirection = FindFacingDirection(moveDirection, facingDirection); 
        DrawSwapLine(); 
    }

    int FindFacingDirection(Vector3 _movement, int _currentDirection) { //find what direction the player is facing
        if (_movement.x < 0) {
            return -1;
        }
        if (_movement.x > 0) {
            return 1;
        }
        return facingDirection;
    }

    void Swap(InputAction.CallbackContext context) { //runs when the swap keybind is pressed
        RaycastHit2D swapRay = swapRaycast.Raycast2D(facingDirection);
        if (swapRay == true) {
            if (swapRay.collider.name == "Crate") {
                CrateSwapScript Crate = swapRay.collider.GetComponent<CrateSwapScript>();
                Vector3 newPosition = Crate.CrateSwapPosition(transform.position);
                transform.position = newPosition;
            }
        }
    }

    void DrawSwapLine() { //draw line representing players sightline for swapping
        swapLinePoints[0] = transform.position;
        swapLinePoints[1] = swapRaycast.Raycast2D(facingDirection).point;

        if (swapLinePoints[1] == Vector3.zero) { 
            swapLinePoints[1] = new Vector3(facingDirection * 20, transform.position.y, transform.position.z);
        }

        swapLine.SetUpLine(swapLinePoints); //run SetUpLine in DrawSwapLineScript
    }

    bool CalculateCanJump() { //uses raycast and coyote time to determine if the player can jump
        if (groundRaycast.RaycastAll() == true) {
            coyoteTime = 0.15f;
            return true;
        }
        else {
            coyoteTime -= Time.deltaTime;
        }

        if (coyoteTime < 0) {
            return false;
        }
        return false;
    }

    void FixedUpdate() { //runs every fixed frame, used for physics (movement mainly)
        rb.linearVelocity = new Vector2(moveDirection.x * moveSpeed, rb.linearVelocityY);
    }

    void Jump(InputAction.CallbackContext context) { //runs when the Jump keybind is pressed
        if (CalculateCanJump() == true) {
            rb.linearVelocityY = jumpHeight;
        }
    }
}
