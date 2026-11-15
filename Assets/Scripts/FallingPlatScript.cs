using UnityEngine;

public class FallingPlatScript : MonoBehaviour
{
    //creates the delay before the platform falls
    public float platFallDelay = 0.5f;
    //physics body
    Rigidbody2D rb;

    //gets the rigidbody2D physics component
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    //when something makes contact directly with the platform
    void OnCollisionEnter2D(Collision2D collision)
    {
       //The falling count begins if the player came into contact
       if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("platFall", platFallDelay);
        }

       //if the platform hits the floor it gets destroyed
       if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }

    //if something comes into contact with the platform
    void OnTriggerEnter2D(Collider2D other)
    {
        //if the platform touches the death zone it gets destroyed
        if (other.gameObject.CompareTag("Death Zone"))
        {
            Destroy(gameObject);
        }
    }

    //gives the platform gravity to make it fall whilst also deleting the platform if it falls for too long
    void platFall()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, 5f);
    }
}
