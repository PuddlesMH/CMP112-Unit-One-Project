using UnityEngine;
using UnityEngine.SceneManagement;

public class lockedDoorScript : MonoBehaviour
{
    public string nextLevel; //enter the next level to be sent to in the Inspector
    public int keysRequired = 1; //enter the keys needed to unlock the door on this level, 1 is default
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) //runs if the player comes into contact with the door
        {
            if (KeyScript.keyCollect >= keysRequired)
            {
                KeyScript.keyCollect = 0; //resets keys
                SceneManager.LoadScene(nextLevel); //loads the next level to travel to
            }
            else
            {
                Debug.Log("Door is locked, need " + keysRequired + " more keys"); //incase the player hasn't met the win condition
            }
        }

    }

}