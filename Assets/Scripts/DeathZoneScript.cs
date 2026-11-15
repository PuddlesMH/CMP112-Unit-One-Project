using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZoneScript : MonoBehaviour
{
    public static int lives = 3;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Debug.Log("You Died! Try again.");
            lives = lives - 1;

            if(lives <= 0)
            {
                SceneManager.LoadScene("FailMenu");
                lives = 3;
            }
        }
    }
}
    