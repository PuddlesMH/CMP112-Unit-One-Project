using TMPro;
using UnityEngine;

public class LivesDisplay : MonoBehaviour
{
    public TextMeshProUGUI livesText;

    //Displays the amount of keys the player has, calling in KeyScript to update the value
    void Update()
    {
        livesText.text = "Lives: " + DeathZoneScript.lives;
    }
}