using TMPro;
using UnityEngine;

public class LivesDisplay : MonoBehaviour
{
    public TextMeshProUGUI livesText;

    //Displays how many lives the player has left
    void Update()
    {
        livesText.text = "Lives: " + DeathZoneScript.lives;
    }
}