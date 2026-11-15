using UnityEngine;
using TMPro;
public class KeyScript : MonoBehaviour
{
    //static so the counter is shared
    public static int keyCollect;
    
    void Start()
    {
        keyCollect = 0;
    }
    
    //When something makes contact with the key
    void OnTriggerEnter2D(Collider2D other)
    {   
        //runs if the player was the one who came into contact
        if (other.gameObject.CompareTag("Player")) 
        {
            //key is gone and add to the counter
            gameObject.SetActive(false); 
            keyCollect = keyCollect + 1;
        }

    }

}
