using UnityEngine;
using TMPro;
public class keyScript : MonoBehaviour
{
    private int keyCollect; // to keep track of the key being collected
    public TextMeshProUGUI keyText; //for displaying if the player possesses the key
    void Start()
    {
        keyCollect = 0; 
        SetKeyText(); //prepares text at the start to show that the key hasn't been collected
    }
    
   
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) //runs if the player came into contact with the key
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
