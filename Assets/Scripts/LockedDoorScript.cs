using UnityEngine;
using UnityEngine.SceneManagement;

public class lockedDoorScript : MonoBehaviour
{
  
  //How much keys are required to unlock the door on that level
    public int keysRequired = 1; 
  // The next scene to proceed to after winning that level  
    public string nextLevelName;
    
    //When something comes into contact with the door
    void OnTriggerEnter2D(Collider2D other)
    {
        //if the player was the one who came into contact
        if (other.gameObject.CompareTag("Player"))
        {
            //checks if the win condition is met
            if (KeyScript.keyCollect >= keysRequired)
            {
                //resets keys the player has
                KeyScript.keyCollect = 0; 
                //Tells the win screen what the next level is for the next level button
                WinMenu.nextLevel = nextLevelName;
                SceneManager.LoadScene("WinMenu");
                //reset lives for the next level
                DeathZoneScript.lives = 3;
            }
            else
            {
                Debug.Log("Door is locked, need " + keysRequired + " more keys"); 
            }
        }

    }

}