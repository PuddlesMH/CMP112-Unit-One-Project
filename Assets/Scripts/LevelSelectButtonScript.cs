using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectButtonScript : MonoBehaviour
{
    public Button LevelOneButton, LevelTwoButton, LevelThreeButton, LevelFourButton, LevelFiveButton, LevelSelectButton, MainMenuButton, ExitButton;
    private void Start() { //each button is set to return a different value
        LevelOneButton.onClick.AddListener(delegate { LoadLevel(1); }) ;
        LevelTwoButton.onClick.AddListener(delegate { LoadLevel(2); });
        LevelThreeButton.onClick.AddListener(delegate { LoadLevel(3); });
        LevelFourButton.onClick.AddListener(delegate { LoadLevel(4); });
        LevelFiveButton.onClick.AddListener(delegate { LoadLevel(5); });
        LevelSelectButton.onClick.AddListener(delegate { LoadLevel(6); });
        MainMenuButton.onClick.AddListener(delegate { LoadLevel(7); });
        ExitButton.onClick.AddListener(delegate { LoadLevel(8); });
    }

    public void LoadLevel(int _level) { //depending on what button was pressed, loads a certain scene
        switch(_level) {
            case 1: SceneManager.LoadScene("Level1"); break;
            case 2: SceneManager.LoadScene("Level2"); break;
            case 3: SceneManager.LoadScene("Level3"); break;
            case 4: SceneManager.LoadScene("Level4"); break;
            case 5: SceneManager.LoadScene("Level5"); break;
            case 6: SceneManager.LoadScene("LevelSelect"); break;
            case 7: SceneManager.LoadScene("MainMenu"); break;
            case 8: Application.Quit(); break;
        }
    }
}