using UnityEngine;
using TMPro;
public class KeyScript : MonoBehaviour
{
    public static int keyCollect; // to keep track of keys being collected, public for the locked door script
    public TextMeshProUGUI keyText; //for displaying how many keys the player has

    void Start()
    {
        keyCollect = 0; 
        SetKeyText(); //prepares text at the start to show that no keys have been collected
    }
    
   
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) //runs if the player came into contact with a key
        {
            gameObject.SetActive(false); //key disapears after being collected
            keyCollect = keyCollect + 1; 
            SetKeyText(); // updates text to show that the key was collected
        }

    }

    void SetKeyText()
    {
        keyText.text = "Key: " + keyCollect.ToString(); //updates the text on screen if key was collected
    }

}
