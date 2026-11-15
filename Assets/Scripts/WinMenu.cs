using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinMenu : MonoBehaviour
{
    public Button NextLevelButton, LevelSelectButton, MainMenuButton;
    public static string nextLevel;

    //Hides the next level button on the last level
    private void Start()
    {   if (string.IsNullOrEmpty(nextLevel))
        {
            NextLevelButton.gameObject.SetActive(false);
        }
        else
        {
            //Next level button is created if there is a next level
            NextLevelButton.onClick.AddListener(delegate { Options(1); });
        }
        
        LevelSelectButton.onClick.AddListener(delegate { Options(2); });
        MainMenuButton.onClick.AddListener(delegate { Options(3); });
    }
    
    //Uses a switch statement to load a different scene depending on what button was clicked
    void Options(int winMenu) 
    {
        switch(winMenu)
        {
            case 1: SceneManager.LoadScene(nextLevel); break;
            case 2: SceneManager.LoadScene("LevelSelect"); break;
            case 3: SceneManager.LoadScene("MainMenu"); break;
        }

    }
}
