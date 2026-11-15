using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FailMenu : MonoBehaviour
{
    public Button LevelSelectButton, MainMenuButton;
   
    //Creates the buttons in the game over screen
    private void Start()
    {
        LevelSelectButton.onClick.AddListener(delegate { failOptions(1); });
        MainMenuButton.onClick.AddListener(delegate { failOptions(2); });
    }

    //Uses a switch statement to load a different scene depending on what button was clicked
    void failOptions(int failMenu)
    {
        switch (failMenu)
        {
            case 1: SceneManager.LoadScene("LevelSelect"); break;
            case 2: SceneManager.LoadScene("MainMenu"); break;
        }

    }
}

