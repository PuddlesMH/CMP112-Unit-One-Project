using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZoneScript : MonoBehaviour
{
    //static for shared lives for the whole game so it keeps a change in value rather than defaulting to 3 after death
    public static int lives = 3;

    //When something makes contact with the death zone
    void OnTriggerEnter2D(Collider2D other)
    {
        //The player loses a life and the scene/level restarts
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Debug.Log("You Died! Try again.");
            lives = lives - 1;

            //lose condition, if all lives are lost its game over
            if(lives <= 0)
            {
                SceneManager.LoadScene("FailMenu");
                lives = 3;
            }
        }
    }
}
    