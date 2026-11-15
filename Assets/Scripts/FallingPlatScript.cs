using UnityEngine;

public class FallingPlatScript : MonoBehaviour
{
    public float platFallDelay = 0.5f;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("platFall", platFallDelay);
        }

       if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Death Zone"))
        {
            Destroy(gameObject);
        }
    }
    void platFall()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, 5f);
    }
}
