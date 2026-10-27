using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpHeight = 5f;
    private Rigidbody2D rb;
    public bool isGrounded;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocityX = moveInput * moveSpeed;
        if ((Input.GetKeyDown(KeyCode.Space)) && (isGrounded == true))
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
