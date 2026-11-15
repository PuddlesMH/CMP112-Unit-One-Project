using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelDisplay : MonoBehaviour
{
    public TextMeshProUGUI levelText;

    //gets the level/scene's name to display for the player
    void Start()
    {
        string levelName = SceneManager.GetActiveScene().name;
        levelText.text = "Level: " + levelName; 
    }
}
